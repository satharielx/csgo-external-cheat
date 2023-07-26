using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace whelper
{
    [Serializable]
    public class Items
    {
        public IntPtr Handle;
        public Process Current;
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }
        
        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "ReadProcessMemory")]
        public static extern bool DistinctAll(
                                        IntPtr hProcess,
                                        IntPtr lpBaseAddress,
                                        [Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
                                        int dwSize,
                                        out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "ReadProcessMemory")]
        public static extern bool DistinctAll(
                                        IntPtr hProcess,
                                        UIntPtr lpBaseAddress,
                                        [Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
                                        int dwSize,
                                        out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "WriteProcessMemory")]
        static extern bool SendMessage(
                            IntPtr hProcess,
                            IntPtr lpBaseAddress,
                            [MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
                            int dwSize,
                            out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "OpenProcess")]
        static extern IntPtr OP(
                            ProcessAccessFlags processAccess,
                            bool bInheritHandle,
                            int processId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        bool injected = false;
        public Items(Process p) {
            if (p == null) Console.WriteLine("No valid process found! Please launch csgo.exe!");
            Current = p;
            Handle = OP(ProcessAccessFlags.All, false, p.Id);
        }
        public bool Inject(string dllName) {
            if (injected) return false;
            if (!File.Exists(dllName)) return false;
            if (!Incarnate(Current.Id, dllName)) return false;
            Console.WriteLine("Skin Changer on! USE Insert Key!");
            return true;
        }
        public bool Incarnate(int pid, string dllname) {
            if (injected) return false;
            
            IntPtr handl = Handle;
            if (handl == IntPtr.Zero) return false;
            IntPtr lpAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (lpAddr == IntPtr.Zero) return false;
            IntPtr lpAddress = VirtualAllocEx(handl, (IntPtr)null, (IntPtr)dllname.Length, (0x1000 | 0x2000), 0X40);
            if (lpAddress == IntPtr.Zero) return false;
            byte[] data = Encoding.UTF8.GetBytes(dllname);
            if (!SendMessage(handl, lpAddress, data, data.Length, out var written)) {
                return false;
            }
            if (CreateRemoteThread(handl, (IntPtr)null, IntPtr.Zero, lpAddr, lpAddress, 0, (IntPtr)null) == IntPtr.Zero) {
                return false;
            }
            CloseHandle(handl);
            return true;
        }
        public T btos<T>(byte[] data) where T : struct {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally {
                handle.Free();
            }
        }
        private static byte[] stob(object obj)
        {
            int length = Marshal.SizeOf(obj);

            byte[] array = new byte[length];

            IntPtr pointer = Marshal.AllocHGlobal(length);

            Marshal.StructureToPtr(obj, pointer, true);
            Marshal.Copy(pointer, array, 0, length);
            Marshal.FreeHGlobal(pointer);

            return array;
        }

        public T DeployRope<T>(IntPtr address) where T : struct {
            int blenght = Marshal.SizeOf(typeof(T));
            byte[] temp = new byte[blenght];
            DistinctAll(Handle, address, temp, temp.Length, out var read);
            return btos<T>(temp);
        }

        public T DeployRope<T>(UIntPtr address) where T : struct
        {
            int blenght = Marshal.SizeOf(typeof(T));
            byte[] temp = new byte[blenght];
            DistinctAll(Handle, address, temp, temp.Length, out var read);
            return btos<T>(temp);
        }

        public byte[] DeployRope(IntPtr address, int sz) {
            byte[] buff = new byte[sz];
            DistinctAll(Handle, address, buff, buff.Length, out var read);
            return buff;
        }
        public T[] DeployRopes<T>(IntPtr address, int length) where T : struct {
            T[] data = new T[Marshal.SizeOf<T>() * length];
            IntPtr read = IntPtr.Zero;
            for (int i = 0; i < length; i++) {
                data[i] = DeployRope<T>(address + i * length);
            }
            return data;
        }
        public float[] ReadMatrix<T>(IntPtr address, int mLenght) {
            int sz = Marshal.SizeOf(typeof(T));
            byte[] temp = new byte[sz * mLenght];
            DistinctAll(Handle, address, temp, temp.Length, out var read);
            return ctof(temp);
        }
        public float[] ctof(byte[] data) {
            if (data.Length % 4 != 0) throw new ArgumentException();

            float[] floats = new float[data.Length / 4];

            for (int i = 0; i < floats.Length; i++) floats[i] = BitConverter.ToSingle(data, i * 4);

            return floats;

        }
        public byte[] ReadMulti(IntPtr address, int length) {
            byte[] data = new byte[length];
            IntPtr read = IntPtr.Zero;
            DistinctAll(Handle, address, data, data.Length, out read);
            return data;
        }
        public unsafe bool CraftRope<T>(IntPtr address, object value) where T: struct {
            byte[] data = stob(value);


            return SendMessage(Handle, address, data, data.Length, out var read);
        }
        public unsafe bool CraftRope<T>(IntPtr address, T[] value, int startIndex) { 
            byte[] buffer = new byte[sizeof(byte)];
            bool result = false;
            for (int i = startIndex; i < value.Length; i++) {
                T[] data = new T[Marshal.SizeOf<T>()];
                data[0] = value[i];
                result = SendMessage(Handle, address + i * value.Length, data, data.Length, out var read);
                
            }
            return result;
        }
        public IntPtr GetInsufficentMaterials(string module) {
            if (Current == null) return IntPtr.Zero;
            IntPtr baseAddress = IntPtr.Zero;
            for (int i = 0; i < Current.Modules.Count; i++) {
                if (Current.Modules[i].ModuleName == module) baseAddress = Current.Modules[i].BaseAddress;
            }
            return baseAddress;
        }
    }
}
