using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace whelper
{
    public enum CodeResult
    {
        Failed = 1,
        Success = 2,
        FileNotFound = 3,
        ProcessNotFound = 4
    }

    public unsafe class UnmanagedProcedures
    {
        public delegate void memcpyf(void* des, void* src, uint bytes);

        public static readonly memcpyf memcpy;
        static UnmanagedProcedures()
        {
            var dynamicMtd = new DynamicMethod(
                "memcpy",
                typeof(void),
                new [] {typeof(void*), typeof(void*), typeof(uint)},
                typeof(UnmanagedProcedures)
                );
            var gen = dynamicMtd.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Ldarg_2);
            gen.Emit(OpCodes.Cpblk);
            gen.Emit(OpCodes.Ret);
            memcpy = (memcpyf) dynamicMtd.CreateDelegate(typeof(memcpyf));
        }
    }

    public class Dll
    {
        // Fields
        private static readonly IntPtr ZeroValue = IntPtr.Zero;
        private static Dll status;

        // Methods
        public Dll()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", EntryPoint = "RtlCopyMemory")]
        public static extern void CopyMeSomeMemory(IntPtr Destination,
            IntPtr Source, uint Length);
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

        public unsafe CodeResult Bypass()
        {
            IntPtr ntdPtr = GetProcAddress(LoadLibrary("ntdll"), "NtOpenFile");
            if (ntdPtr != IntPtr.Zero)
            {
                char[] unmanagedChars = new char[5];
                IntPtr chPtr = IntPtr.Zero;
                fixed (char* p = unmanagedChars)
                {
                    chPtr = (IntPtr) p;
                }

                try
                {
                    Buffer.MemoryCopy(chPtr.ToPointer(), ntdPtr.ToPointer(), 5, 5);
                    WriteProcessMemory(Program.m.Handle, ntdPtr, unmanagedChars, 5, out IntPtr written);
                    Program.Print("Trusted Launch: Bypassed! Code 0xB0");
                    return CodeResult.Success;
                }
                catch (Exception ex)
                {
                    Program.Print(ex.Message);
                    return CodeResult.Failed;
                }
            }
            else return CodeResult.Failed;
        }

        public CodeResult Inject(string processName, string dllName)
        {
            CodeResult fileNotFound;
            if (!File.Exists(dllName))
            {
                fileNotFound = CodeResult.FileNotFound;
            }
            else
            {
                Bypass();
                uint pToBeInjected = 0;
                Process[] processes = Process.GetProcesses();
                int index = 0;
                while (true)
                {
                    if (index < processes.Length)
                    {
                        if (processes[index].ProcessName != processName)
                        {
                            index++;
                            continue;
                        }
                        pToBeInjected = (uint)processes[index].Id;
                    }
                    fileNotFound = (pToBeInjected != 0) ? (this.injectBase(Program.m.Handle, dllName) ? CodeResult.Success : CodeResult.Failed) : CodeResult.ProcessNotFound;
                    break;
                }
            }
            return fileNotFound;
        }

        private bool injectBase(IntPtr handle, string dllName)
        {
            bool flag2;
            IntPtr hProcess = handle;
            if (hProcess == ZeroValue)
            {
                flag2 = false;
            }
            else
            {
                IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                if (procAddress == ZeroValue)
                {
                    flag2 = false;
                }
                else
                {
                    IntPtr lpBaseAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)dllName.Length, 0x3000, 0x40);
                    if (lpBaseAddress == ZeroValue)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(dllName);
                        if (!WriteProcessMemory(hProcess, lpBaseAddress, bytes, bytes.Length, out var written))
                        {
                            flag2 = false;
                        }
                        else if (CreateRemoteThread(hProcess, IntPtr.Zero, ZeroValue, procAddress, lpBaseAddress, 0, IntPtr.Zero) == ZeroValue)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            CloseHandle(hProcess);
                            flag2 = true;
                        }
                    }
                }
            }
            return flag2;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesWritten);

        // Properties
        public static Dll GetInstance
        {
            get
            {
                if (ReferenceEquals(status, null))
                {
                    status = new Dll();
                }
                return status;
            }
        }
    }


}
