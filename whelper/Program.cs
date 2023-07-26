using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SharpDX;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace whelper
{
    public struct Position {
        public float X;
        public float Y;
        public float Z;
    }
    public struct AngleRotation {
        public float X;
        public float Y;
        public float Z;
    }
    public struct ViewMatrix {
        public float[] Value;
    }
    public struct Vector3D {
        public float X;
        public float Y;
        public float Z;

        public Vector3D(params float[] vals)
        {
            X = vals[0];
            Y = vals[1];
            Z = vals[2];
        }
        public float this[int idx]
        {
            get
            {
                switch (idx)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default: throw new ArgumentOutOfRangeException("Index out of range!");
                }
            }
            set
            {
                switch (idx)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: throw new ArgumentOutOfRangeException("Index out of range!");
                }
            }
        }
        public static Vector3D operator +(Vector3D me, Vector3D you)
        {
            return new Vector3D(me.X + you.X, me.Y + you.Y, me.Z + you.Z);
        }
        public static Vector3D operator -(Vector3D me, Vector3D you)
        {
            return new Vector3D(me.X - you.X, me.Y - you.Y, me.Z - you.Z);
        }
        public static Vector3D operator *(Vector3D me, float factor)
        {
            return new Vector3D(me.X * factor, me.Y * factor, me.Z * factor);
        }
        public static Vector3D operator *(Vector3D me, Vector3D u)
        {
            return new Vector3D(me.X * u.X, me.Y * u.Y, me.Z * u.Z);
        }
        public static float[] Clamp(Vector3D Angle)
        {
            if (Angle[0] > 89.0f)
                Angle[0] = 89.0f;

            if (Angle[0] < -89.0f)
                Angle[0] = -89.0f;

            while (Angle[1] > 180)
                Angle[1] -= 360;

            while (Angle[1] < -180)
                Angle[1] += 360;

            Angle.Z = 0;

            return ToFloat(Angle);
        }
        public static float[] ToFloat(Vector3D v)
        {
            return new float[] { v.X, v.Y, v.Z };
        }
    }
    public static class Ares {
        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }
        public enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }
        public static PointF Center = new PointF(Screen.PrimaryScreen.Bounds.Width * 0.5f, Screen.PrimaryScreen.Bounds.Height * 0.5f);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        public static float AimFOV = 0.0f;
        public static void AimAtPos(float x, float y, bool smooth) {
            float scepterPower = 5f;
            float destX = 0;
            float destY = 0;
            if (x != 0) {
                if (x > Center.X) {
                    destX = -(Center.X - x);
                    destX /= scepterPower;
                    if (destX + Center.X > 2 * Center.X) destX = 0;
                }
                if (x < Center.X) {
                    destX = x - Center.X;
                    destX /= scepterPower;
                    if (destX + Center.X < 0) destX = 0;
                }
            }
            if (y != 0) {
                if (y > Center.Y) {
                    destY = -(Center.Y - y);
                    destY /= scepterPower;
                    if (destY + Center.Y > Center.Y * 2) destY = 0;
                }
                if (y > Center.Y) {
                    destY = y - Center.Y;
                    destY /= scepterPower;
                    if (destY + Center.Y < 0) destY = 0;
                }
            }
            if (!smooth) mouse_event((uint)MouseEventFlags.MOVE, (int)destX, (int)destY, 0, UIntPtr.Zero);
            else
            {
                destX /= 10;
                destY /= 10;
                if (Math.Abs(destX) < 1) {
                    if (destX > 0) destX = 1;
                    if (destX < 0) destX = -1;
                }
                if (Math.Abs(destY) < 1) {
                    if (destY > 0) destY = 1;
                    if (destY < 0) destY = -1;
                }
                mouse_event((uint)MouseEventFlags.MOVE, (int)destX, (int)destY, 0, (UIntPtr)0);
            }

        }
        public static bool IsShooting() {
            return (GetAsyncKeyState(Keys.LButton) != 0);
        }
        public static void WorldToScreen(Vector3D source, out Vector3D screen, float[] viewMatix) {
            // vecScreen[ 0 ] = pflViewMatrix[ 0 ] * vecOrigin[ 0 ] + pflViewMatrix[ 1 ] * vecOrigin[ 1 ] + pflViewMatrix[ 2 ] * vecOrigin[ 2 ] + pflViewMatrix[ 3 ];
            //  vecScreen[1] = pflViewMatrix[4] * vecOrigin[0] + pflViewMatrix[5] * vecOrigin[1] + pflViewMatrix[6] * vecOrigin[2] + pflViewMatrix[7];
            screen = new Vector3D(0f, 0f, 0f);
            screen[0] = viewMatix[0] * source[0] + viewMatix[1] * source[1] + viewMatix[2] * source[2] + viewMatix[3];
            screen[1] = viewMatix[4] * source[0] + viewMatix[5] * source[1] + viewMatix[6] * source[2] + viewMatix[7];
            float temp = viewMatix[12] * source[0] + viewMatix[13] * source[1] + viewMatix[14] * source[2] + viewMatix[15];
            if (temp < 0.01f) {
                return;
            }
            float temp2 = 1f / temp;
            screen[0] *= temp2;
            screen[1] *= temp2;
            float x = Center.X;
            float y = Center.Y;
            screen[0] = x;
            screen[1] = y;
        }

        public static float DistanceBetweenCross(float X, float Y) {
            float yd = (Y - Center.Y);
            float xd = (X - Center.X);
            float hyp0 = (float)Math.Sqrt(Math.Pow(yd, 2) + Math.Pow(xd, 2));
            return hyp0;
        }
        public static IntPtr ConsiderClosest(IntPtr currentEntity, ref float maxDist, float fov) {
            IntPtr closest = IntPtr.Zero;

            if (!IsShooting()) {
                if (currentEntity != IntPtr.Zero) {
                    Vector3D HeadPos = Program.GetBonePos((int)currentEntity, 8).ToVector3();
                    Vector3D Head = new Vector3D(0f, 0f, 0f);
                    WorldToScreen(HeadPos, out Head, Program.GetViewMatrix());
                    float dist = DistanceBetweenCross(Head.X, Head.Y);
                    if (dist < maxDist) {
                        maxDist = dist;
                        closest = currentEntity;
                        AimFOV = fov;
                    }
                }
            }
            return closest;
        }
        public static void AimAtPlayer(IntPtr entity) {
            if (entity != IntPtr.Zero) {
                if (!Program.IsAlive(entity)) {
                    return;
                }
                Vector3D HeadPos = Program.GetBonePos((int)entity, 8).ToVector3();
                Vector3D Head = new Vector3D(0f, 0f, 0f);
                WorldToScreen(HeadPos, out Head, Program.GetViewMatrix());
                if (Head.X != 0 && Head.Y != 0) {
                    if ((DistanceBetweenCross(Head.X, Head.Y)) <= AimFOV * 8) {
                        AimAtPos(Head.X, Head.Y, true);
                    }
                }
            }
        }
    }

    public static class MouseController {

        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    public class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "ReadProcessMemory")]
        public static extern bool DistinctAll(
                                        IntPtr hProcess,
                                        IntPtr lpBaseAddress,
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
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        public static Items m;
        public static Stats stats;
        static bool flag = false;
        public static IntPtr module = IntPtr.Zero;
        public static IntPtr enginestate = IntPtr.Zero;
        static Dictionary<IntPtr, IntPtr> EnemyPlayersGlow = new Dictionary<IntPtr, IntPtr>();
        static List<IntPtr> Weapons = new List<IntPtr>();
        static List<IntPtr> Friends = new List<IntPtr>();
        static Settings settingPreset;
        static Vector3D OldAngles;
        static Vector3D Punch;
        static Color GlowEsp = Color.Red;
        static float recoilSuppress = 2.0f;
       public static void ChangeGlowColor(Color theDesiredColor) {
            if (theDesiredColor == GlowEsp) Console.WriteLine("Its the same color!");
            else
            {
                GlowEsp = theDesiredColor; Console.WriteLine($"The Glow color has been changed to {theDesiredColor.Name}");
            }
        }
       public static void ChangeRecoilSuppress(float recoil) {
            if (recoil > 2.0f || recoil < 0.0f) Console.WriteLine("The smooth factor exceeds the limit, or it has negative value!");
            else recoilSuppress = recoil; 
        }
        public static float[] GetViewMatrix() {
            int player = m.DeployRope<int>(module + Statics.signatures.dwLocalPlayer);
            ViewMatrix v = m.DeployRope<ViewMatrix>(enginestate + Statics.signatures.dwViewMatrix);
            return v.Value;
        }
        public static bool IsAlive(IntPtr entity) {
            int health = m.DeployRope<int>(entity + Statics.netvars.m_iHealth);
            return health > 0 && health <= 100;
        }
        public static void AimbotLoop() {

        }
        static void Main(string[] args)
        {  
            
            bool helperOn = false;
            bool fOn = false;
            bool kPressed = false;
            bool aOn = false;
            bool bnwOn = false;
            bool bOn = false;
            bool saOn = false;
            Statics.OffsetScanner offsetEngine = new Statics.OffsetScanner();
            offsetEngine.Start();
            License l = new License();
            l.ShowDialog();
            while (!l.isLoggedIn) {
                Thread.Sleep(1);
            }
            
               try { m = new Items(Process.GetProcessesByName("csgo")[0]); }
               catch (Exception ex) { Console.WriteLine("Game not found!"); }
            
                Console.Title = "";
                Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(100);
                Console.WriteLine($"Counter-Strike Global Offensive found! ID: {m.Current.Id}");
                IntPtr moduleAddr = m.GetInsufficentMaterials("client.dll");
                module = moduleAddr;
                enginestate = m.DeployRope<IntPtr>(m.GetInsufficentMaterials("engine.dll") + Statics.signatures.dwClientState);
                Console.WriteLine($"Module Address: 0x{moduleAddr.ToString("X")}");
                Console.WriteLine($"Engine Address: 0x{enginestate.ToString("X")}");
                //Console.WriteLine("Press NUMPAD9 for the preset settings!");
                Console.WriteLine("You can support us by leaving a feed on our site!");
                Console.WriteLine("(c) 2022 *GOD BLEESED*. All Rights Reserved!");
            
                while (true)
                {
                    
                    if (GetAsyncKeyState(System.Windows.Forms.Keys.NumPad9) != 0 && !helperOn && !aOn && !bnwOn && !bOn)
                    {
                        kPressed = true;
                        settingPreset = new Settings();
                        Application.Run(settingPreset);
                    }
                    Thread.Sleep(100);
               
                }
        }
        public static void Print(string message) {
            Console.Clear();
            Console.WriteLine(message);
        }
        public static void ACircle(IntPtr moduleAddr) {
            
                if (moduleAddr != null && moduleAddr != IntPtr.Zero) //ако модулът е открит в паметта на процеса!
                {
                    int pAddress = 0;
                    int fAttack = 0;
                    int myTeam = 0;
                    int h = 0;
                    int eAddress = 0;
                    int eHealth = 0;
                    int eTeam = 0;
                    int addr = (int)moduleAddr + Statics.signatures.dwLocalPlayer;
                    int crosshairId = 0;
                    pAddress = m.DeployRope<int>((IntPtr)addr); //нашият играч - 0xCFE9D34A
                    fAttack = (int)moduleAddr + Statics.signatures.dwForceAttack;
                    addr = pAddress + Statics.netvars.m_iHealth;
                    h = m.DeployRope<int>((IntPtr)addr);
                    addr = pAddress + Statics.netvars.m_iTeamNum;
                    myTeam = m.DeployRope<int>((IntPtr)addr);
                    bool isScoped = m.DeployRope<bool>((IntPtr)pAddress + Statics.netvars.m_bIsScoped);
                    
                
                m.CraftRope<float>((IntPtr)(pAddress + Statics.netvars.m_flFlashMaxAlpha), 0.0f); //No Flash Module
                addr = pAddress + Statics.netvars.m_iCrosshairId;
                    crosshairId = m.DeployRope<int>((IntPtr)addr);

                    if (crosshairId > 0 && crosshairId < 65 && h > 0)
                    {
                       
                        addr = (int)moduleAddr + Statics.signatures.dwEntityList + (crosshairId - 1) * 0x10;
                        eAddress = m.DeployRope<int>((IntPtr)addr);
                      
                        addr = eAddress + Statics.netvars.m_iHealth;
                        eHealth = m.DeployRope<int>((IntPtr)addr);

                       
                        addr = eAddress + Statics.netvars.m_iTeamNum;
                        eTeam = m.DeployRope<int>((IntPtr)addr);
                     

                        if (eTeam != myTeam && eTeam > 1 && eHealth > 0)
                        {
                        
                            m.CraftRope<int>((IntPtr)fAttack, 1);
                            Console.WriteLine("[EVENT] MouseClickEvent was triggered.");
                            Thread.Sleep(4);
                            m.CraftRope<int>((IntPtr)fAttack, 2);

                        }
                    }
                }
            
            
        }
        public static void LifeCheck() {
            int pl = m.DeployRope<int>(module + Statics.signatures.dwLocalPlayer);
            int t = m.DeployRope<int>((IntPtr)pl + Statics.netvars.m_iTeamNum);
         
            
                for (int i = 0; i < 65; i++)
                {

                    int e = m.DeployRope<int>(module + Statics.signatures.dwEntityList + (i - 1) * 0x10);
                    int opT = m.DeployRope<int>((IntPtr)e + Statics.netvars.m_iTeamNum);
                    int tH = m.DeployRope<int>((IntPtr)e + Statics.netvars.m_iHealth);

                    int gIndex = m.DeployRope<int>((IntPtr)e + Statics.netvars.m_iGlowIndex);
                   
                    
                    if (!m.DeployRope<bool>((IntPtr)e + Statics.signatures.m_bDormant))
                    {
                        
                        if (opT != t && tH > 0)
                        {
                            gIndex = m.DeployRope<int>((IntPtr)e + Statics.netvars.m_iGlowIndex);
                            Glow(gIndex, GlowEsp);
                        }

                    }
                    T
                }
        
        }
        public static void UtilityGlow() {
            Color glowColor = Color.Transparent;
            IntPtr currentAddress = module + Statics.signatures.dwGlowObjectManager;
            int glowObjectManager = m.DeployRope<int>(currentAddress);
            int glowObjectsAmount = m.DeployRope<int>(currentAddress + 0xC);
            int player = m.DeployRope<int>(module + Statics.signatures.dwLocalPlayer);
            
            for (int i = 0; i < glowObjectsAmount; i++) {
                Console.Clear();
                Console.WriteLine("Entity Info");
                
                int entityV2 = m.DeployRope<int>(module + Statics.signatures.dwEntityList + (i - 1) * 0x10);
                bool dormant = m.DeployRope<bool>((IntPtr)entityV2 + Statics.signatures.m_bDormant);
                int myteam = m.DeployRope<int>((IntPtr)player + Statics.netvars.m_iTeamNum);
                int clId = GetClassId(entityV2);
                if (dormant) continue;
                Console.WriteLine($"Entity Address: 0x{(module + Statics.signatures.dwEntityList + (i - 1) * 0x10):X2}");
                
                Console.WriteLine($"Class ID: {clId}");
                
                int health = m.DeployRope<int>((IntPtr)entityV2 + Statics.netvars.m_iHealth);
                int team = m.DeployRope<int>((IntPtr)entityV2 + Statics.netvars.m_iTeamNum);
                int glowIdx = m.DeployRope<int>((IntPtr)entityV2 + Statics.netvars.m_iGlowIndex);
                if (clId == 40)
                {
                    Console.WriteLine($"Team: {team}");
                    Console.WriteLine($"Health: {health}");
                    if (myteam != team)
                    {
                        if (health > 0)
                        {

                            glowColor = Color.Red;

                        }
                    }
                    else if (myteam == team)
                    {
                        if (health > 0)
                        {

                            glowColor = Color.Green;

                        }
                    }
                    Glow(glowIdx, glowColor);

                }
                else
                {
                    if (clId != 0) {
                        glowColor = Color.Blue;
                        Glow(i, glowColor);
                    }
                    
                }
            }
            
        }
        public static bool IsPlayer(int entity) {
            uint icliennet = m.DeployRope<UInt32>((IntPtr)entity + 0x8);
            uint clientclass = m.DeployRope<UInt32>((IntPtr)icliennet + 2 * 0x4);
            uint ptrclass = m.DeployRope<UInt32>((IntPtr)clientclass + 1);
            int clId = m.DeployRope<int>((IntPtr)ptrclass + 20);
            return (clId == (int)classes.CCSPlayer);
        }
        public static bool IsBomb(int entity) {

            uint icliennet = m.DeployRope<UInt32>((IntPtr)entity + 0x8);
            uint clientclass = m.DeployRope<UInt32>((IntPtr)icliennet + 2 * 0x4);
            uint ptrclass = m.DeployRope<UInt32>((IntPtr)clientclass + 1);
            int clId = m.DeployRope<int>((IntPtr)ptrclass + 20);
            if (clId == (int)classes.CC4 || clId == (int)classes.CPlantedC4) return true;
            else return false;
        }

        public static int GetClassId(int entity) {
            uint icliennet = m.DeployRope<UInt32>((IntPtr)entity + 0x8);
            uint clientclass = m.DeployRope<UInt32>((IntPtr)icliennet + 2 * 0x4);
            uint ptrclass = m.DeployRope<UInt32>((IntPtr)clientclass + 1);
            int clId = m.DeployRope<int>((IntPtr)ptrclass + 20);
            return clId;
        }

        public static int GetClassId(ulong entity)
        {
            uint icliennet = m.DeployRope<UInt32>((UIntPtr)entity + 0x8);
            uint clientclass = m.DeployRope<UInt32>((UIntPtr)icliennet + 2 * 0x4);
            uint ptrclass = m.DeployRope<UInt32>((UIntPtr)clientclass + 1);
            int clId = m.DeployRope<int>((IntPtr)ptrclass + 20);
            return clId;
        }
        public static bool IsWeapon(int entity) {

            uint icliennet = m.DeployRope<UInt32>((IntPtr)entity + 0x8);
            uint clientclass = m.DeployRope<UInt32>((IntPtr)icliennet + 2 * 0x4);
            uint ptrclass = m.DeployRope<UInt32>((IntPtr)clientclass + 1);
            int clId = m.DeployRope<int>((IntPtr)ptrclass + 20);
            if ((classes)clId == classes.CAK47 ||
                (classes)clId == classes.CWeaponM4A1 ||
                (classes)clId == classes.CWeaponGlock ||
                (classes)clId == classes.CWeaponGalil ||
                (classes)clId == classes.CWeaponGalilAR ||
                (classes)clId == classes.CWeaponHKP2000 ||
                (classes)clId == classes.CWeaponMag7 ||
                (classes)clId == classes.CWeaponMP5Navy ||
                (classes)clId == classes.CWeaponMP9 ||
                (classes)clId == classes.CWeaponNegev ||
                (classes)clId == classes.CWeaponP250 ||
                (classes)clId == classes.CWeaponSawedoff ||
                (classes)clId == classes.CWeaponSCAR20 ||
                (classes)clId == classes.CWeaponScout ||
                (classes)clId == classes.CWeaponSG552 ||
                (classes)clId == classes.CWeaponSSG08 ||
                (classes)clId == classes.CWeaponTaser ||
                (classes)clId == classes.CWeaponUMP45 ||
                (classes)clId == classes.CWeaponUSP ||
                (classes)clId == classes.CWeaponXM1014 ||
                (classes)clId == classes.CDecoyGrenade ||
                (classes)clId == classes.CHEGrenade ||
                (classes)clId == classes.CMolotovGrenade ||
                (classes)clId == classes.CSmokeGrenade ||
                (classes)clId == classes.CWeaponAug ||
                (classes)clId == classes.CWeaponAWP ||
                (classes)clId == classes.CWeaponBizon ||
                (classes)clId == classes.CWeaponElite ||
                (classes)clId == classes.CWeaponFamas ||
                (classes)clId == classes.CWeaponFiveSeven) return true;
            else return false;
        }
        public static void BunnyNWall() {
            int player = m.DeployRope<int>(module + Statics.signatures.dwLocalPlayer);
            LifeCheck();
            while (GetAsyncKeyState(Keys.Space) != 0) {
                int flags = m.DeployRope<int>((IntPtr)player + Statics.netvars.m_fFlags);
                 if (!(flags == 256 || flags == 258 || flags == 260 || flags == 262)) //if not in air 
                 {
                     m.CraftRope<int>(module + Statics.signatures.dwForceJump, 5);
                 }
                 else if ((flags == 256 || flags == 258 || flags == 260 || flags == 262))
                 {
                     m.CraftRope<int>(module + Statics.signatures.dwForceJump, 4);
                     m.CraftRope<int>(module + Statics.signatures.dwForceJump, 5);
                     m.CraftRope<int>(module + Statics.signatures.dwForceJump, 4);
                 }
                 else {
                     m.CraftRope<int>(module + Statics.signatures.dwForceJump, 4);
                 }
               
                LifeCheck();
            }
            
        }
        public static void Bunny() {
            int player = m.DeployRope<int>(module + Statics.signatures.dwLocalPlayer);
            
            while (GetAsyncKeyState(Keys.Space) != 0)
            {
                int flags = m.DeployRope<int>((IntPtr)player + Statics.netvars.m_fFlags);
                if (!(flags == 256 || flags == 258 || flags == 260 || flags == 262)) //if not in air 
                {
                    m.CraftRope<int>(module + Statics.signatures.dwForceJump, 5);
                }
                else if ((flags == 256 || flags == 258 || flags == 260 || flags == 262))
                {
                    m.CraftRope<int>(module + Statics.signatures.dwForceJump, 4);
                    m.CraftRope<int>(module + Statics.signatures.dwForceJump, 5);
                    m.CraftRope<int>(module + Statics.signatures.dwForceJump, 4);
                }
                else
                {
                    m.CraftRope<int>(module + Statics.signatures.dwForceJump, 4);
                }
               
                Thread.Sleep(new TimeSpan(10000));
            }
        }
        public static void NRec()
        {
            IntPtr offset = (IntPtr)m.DeployRope<int>(module + Statics.signatures.dwLocalPlayer);
            int sFired = m.DeployRope<int>(offset + Statics.netvars.m_iShotsFired);
            Vector3D AimAngle = new Vector3D(0f, 0f, 0f);

            if (sFired > 1)
            {
                AimAngle = new Vector3D(m.DeployRopes<float>(offset + Statics.netvars.m_aimPunchAngle, 3));
                Punch = OldAngles - AimAngle * 2f;
                Vector3D.Clamp(Punch);
                m.CraftRope<float>(enginestate + Statics.netvars.m_viewPunchAngle, Vector3D.ToFloat(Punch), 0);
            }
            else
            {
                OldAngles = new Vector3D(m.DeployRopes<float>(enginestate + Statics.netvars.m_viewPunchAngle, 3));
            }
        }
        public static void BCircle() {
            int currentTarget = 0x420;
            IntPtr moduleAddr = module;
            int entity = 0;
            
                entity = m.DeployRope<int>((moduleAddr + Statics.signatures.dwLocalPlayer));
                int addr = (int)moduleAddr + Statics.signatures.dwEntityList;
                int team = 0;
                int ourTeam = m.DeployRope<int>((IntPtr)(entity + Statics.netvars.m_iTeamNum));
                int closest = 0;
                float cDist = 0.0f;
                int cId = 0; int addrTemp = entity + 0x302C;
            int engineState = (int)m.GetInsufficentMaterials("engine.dll");
            float[] punch = SimpleMath.Multiply(m.DeployRopes<float>((IntPtr)addrTemp, 3), 2);
            Console.WriteLine("Punch: " + string.Join("; ", punch));
            addrTemp = entity + Statics.netvars.m_vecOrigin;
            float[] eyePos = m.DeployRopes<float>((IntPtr)addrTemp, Marshal.SizeOf<float>());
            eyePos[2] += m.DeployRope<float>((IntPtr)(entity + Statics.netvars.m_vecViewOffset + 0x8));
            
            int clientState = m.DeployRope<int>((IntPtr)engineState + Statics.signatures.dwClientState);
           
            if (GetAsyncKeyState(Keys.LButton) != 0) {
               
                int health = 0;
                if (currentTarget == 0x420)
                {
                    cId = m.DeployRope<int>((IntPtr)(entity + Statics.netvars.m_iCrosshairId));
                    currentTarget = m.DeployRope<int>((IntPtr)(addr + (cId - 1) * 0x10));
                    team = m.DeployRope<int>((IntPtr)(currentTarget + Statics.netvars.m_iTeamNum));
                }

                health = m.DeployRope<int>((IntPtr)(currentTarget + Statics.netvars.m_iHealth));
                if (ourTeam != team && health > 0 && cId >= 0 && cId < 65 && currentTarget != 0x420) //ako celta ima validni parametri za igrach
                {
                    float[] oAng = m.DeployRopes<float>((IntPtr)clientState + Statics.signatures.dwClientState_ViewAngles, 3);
                    Console.WriteLine("" + string.Join("; ", oAng));
                    float[] newAngles = SimpleMath.Normalized(
                    SimpleMath.SmoothnNormalize(oAng,
                    SimpleMath.DifferenceBetween(punch,
                    SimpleMath.Normalized(SimpleMath.CalculateAngles(eyePos, GetBonePos(entity, 8))
                     )), 20));
                    float[] calcAng = SimpleMath.CalculateAngles(eyePos, GetBonePos(currentTarget, 8));
                    float[] normalized = SimpleMath.Normalized(calcAng);
                    float[] diff = SimpleMath.DifferenceBetween(punch, normalized);
                    float[] smth = SimpleMath.SmoothnNormalize(oAng, diff, 20);
                    float[] norm2 = SimpleMath.Normalized(smth);
                    float[] nAng = norm2;


                    m.CraftRope<float>((IntPtr)(clientState + Statics.netvars.m_viewPunchAngle), nAng, 0);
                    Console.WriteLine("" + string.Join("; ", nAng));
                  
                    

                }
                else if ((cId < 1 || cId >= 65))
                {
                    currentTarget = 0x00;
                }
            }
            else {
                currentTarget = 0x00;
            }
                
           
        }
        public static void BAlternate() {
            IntPtr moduleAddr = module;
            IntPtr Offset = module + Statics.signatures.dwLocalPlayer;
            int player = m.DeployRope<int>(Offset);
            int current = 0x420;
            Offset = (IntPtr)player + Statics.netvars.m_vecOrigin;
            float[] pos = m.DeployRopes<float>(Offset, 3);
            pos[2] += m.DeployRope<float>((IntPtr)player + Statics.netvars.m_vecViewOffset + 0x8);
            
                Offset = (IntPtr)player + Statics.netvars.m_aimPunchAngle;
                float[] punch = m.DeployRopes<float>(Offset, 3);
                float[] angles = new float[3];
                int cId = m.DeployRope<int>((IntPtr)player + Statics.netvars.m_iCrosshairId);
                int team = 0;
                int h = 0;
                int myTeam = m.DeployRope<int>((IntPtr)player + Statics.netvars.m_iTeamNum);
                
            while (GetAsyncKeyState(Keys.LButton) != 0) {
                if (cId >= 0 && cId >= 65)
                {
                    double dist = 999999.0f;
                    current = m.DeployRope<int>(moduleAddr + Statics.signatures.dwEntityList + (cId - 1) * 0x10);
                    
                    team = m.DeployRope<int>((IntPtr)current + Statics.netvars.m_iTeamNum);
                    h = m.DeployRope<int>((IntPtr)current + Statics.netvars.m_iHealth);

                    if (h > 0 && team != myTeam)
                    {
                        float[] bonePos = GetBonePos(current, 8);
                        SimpleMath.CalcAngles(pos, bonePos, angles);
                        angles[0] -= punch[0] * 2.0f;
                        angles[1] -= punch[1] * 2.0f;
                        SimpleMath.ClampAngles(angles);
                        int fAttack = (int)moduleAddr + Statics.signatures.dwForceAttack;
                        IntPtr engineState = m.GetInsufficentMaterials("engine.dll");
                        int clientState = m.DeployRope<int>((IntPtr)engineState + Statics.signatures.dwClientState);
                        m.CraftRope<float>((IntPtr)clientState + Statics.signatures.dwClientState_ViewAngles, angles, 0);
                      
                        
                    }

                }
            }
                
        }
        public static void AimAt(int entity, int boneId, int pEntity, int moduleAddr)
        {
            int addrTemp = pEntity + Statics.netvars.m_aimPunchAngle;
            int engineState = (int)m.GetInsufficentMaterials("engine.dll");
            float[] punch = SimpleMath.Multiply(m.DeployRopes<float>((IntPtr)addrTemp, Marshal.SizeOf<float>()), 2);
            addrTemp = pEntity + Statics.netvars.m_vecOrigin;
            float[] eyePos = m.DeployRopes<float>((IntPtr)addrTemp, Marshal.SizeOf<float>());
            eyePos[2] += m.DeployRope<float>((IntPtr)(pEntity + Statics.netvars.m_vecViewOffset + 0x8));
            int clientState = m.DeployRope<int>((IntPtr)engineState + Statics.signatures.dwClientState);
            float[] oAng = m.DeployRopes<float>((IntPtr)clientState + Statics.signatures.dwClientState_ViewAngles, 0);
            Console.WriteLine("" + string.Join("; ", oAng));
            float[] newAngles = SimpleMath.Normalized(
                SimpleMath.SmoothnNormalize(oAng,
                SimpleMath.DifferenceBetween(punch,
                SimpleMath.Normalized(SimpleMath.CalculateAngles(eyePos, GetBonePos(entity, boneId))
                )), 20));
            Console.WriteLine("" + string.Join("; ", newAngles));
            float[] nAng = newAngles;
           
            m.CraftRope<float>((IntPtr)(clientState + Statics.signatures.dwClientState_ViewAngles), nAng, 0);
           
        }
        public static void Glow(int gEnt, Color c) {
            int gObj = m.DeployRope<int>(module + Statics.signatures.dwGlowObjectManager);
            int calc = gEnt * 0x38 + 0x8;
            int current = gObj + calc;
            m.CraftRope<float>((IntPtr)current, (float)c.R / 255); // c.R / 255);
            calc = gEnt * 0x38 + 0xC;
            current = gObj + calc;
            m.CraftRope<float>((IntPtr)current, (float)c.G / 255); //c.G / 255);
            calc = gEnt * 0x38 + 0x10;
            current = gObj + calc;
            m.CraftRope<float>((IntPtr)current, (float)c.B / 255); //c.B / 255);
            calc = gEnt * 0x38 + 0x14;
            current = gObj + calc;
            m.CraftRope<float>((IntPtr)current, (float)c.A / 255);
            calc = gEnt * 0x38 + 0x25;
            current = gObj + calc;
            m.CraftRope<bool>((IntPtr)current, true);
            calc = gEnt * 0x38 + 0x29;
            current = gObj + calc;
            m.CraftRope<bool>((IntPtr)current, true);
            calc = gEnt * 0x38 + 0x28;
            current = gObj + calc;
            m.CraftRope<bool>((IntPtr)current, true);
        }
        public static float[] GetBonePos(int entity, int boneId)
        {
            int boneMatrix = m.DeployRope<int>((IntPtr)entity + Statics.netvars.m_dwBoneMatrix);
            float[] result = new float[3];
            result[0]= m.DeployRope<float>((IntPtr)boneMatrix + (0x30 * boneId) + 0x0c);
            result[1] = m.DeployRope<float>((IntPtr)boneMatrix + (0x30 * boneId) + 0x1c);
            result[2] = m.DeployRope<float>((IntPtr)boneMatrix + (0x30 * boneId) + 0x2c);
            return result;
        }
        /// <summary>
        /// Getting each element which is member of the current byte array, by shifting with 3 bytes.
        /// Result is Position struct.
        /// </summary>
        /// <param name="pEntity">Our memory address base</param>
        /// <param name="entity">Already initialized memory opcode constructor</param>
        /// <returns></returns>
        public static Position GetMyPosition(int pEntity, Items entity) {
            Position result = new Position();
            float[] pos = new float[sizeof(float) * 3];
            int addrPos = pEntity + Statics.netvars.m_vecOrigin;
            IntPtr dRead = IntPtr.Zero;
            pos = entity.DeployRopes<float>((IntPtr)addrPos, 3);
            result.X = pos[0];
            result.Y = pos[1];
            result.Z = pos[2];
            result.Z += entity.DeployRope<float>((IntPtr)(pEntity + Statics.netvars.m_vecViewOffset + 0x8)); //head pos 4 bytes away
            return result;
        }
        public static Position GetAngle(int pEntity, Items entity) {
            Position result = new Position();
            result.X = entity.DeployRope<float>((IntPtr)(pEntity + Statics.netvars.m_angEyeAnglesX));
            result.Y = entity.DeployRope<float>((IntPtr)(pEntity + Statics.netvars.m_angEyeAnglesY));
            result.Z = 0.0f;
            return result;
        }
        public static void NoFlash(int pEntity, Items entity, float maxAlpha) {
            if (!flag)
            {
                if (maxAlpha > -1.0f && maxAlpha < 100.1f)
                {
                    int precalculatedAddress = pEntity + Statics.netvars.m_flFlashMaxAlpha;
                    entity.CraftRope<float>((IntPtr)precalculatedAddress, maxAlpha);
                }
            }
            else Console.WriteLine("NoFlash is already toggled ON!");
        }
        public static float[] ByteArrayToFloat(byte[] source) {
            if (source.Length % 4 != 0) throw new ArgumentException();
            float[] r = new float[source.Length / sizeof(float)];
            for (int i = 0; i < r.Length; i++) {
                r[i] = BitConverter.ToSingle(source, i * sizeof(float));
            }
            return r;
        }
        public static bool IsValidHex(string hex) {
            bool finalRes = false;
            if (!hex.Contains("0x")) finalRes = false;
            else
            {
                foreach (char c in hex) {
                    if (c >= 'A' &&
                        c <= 'F' &&
                        c >= 'a' &&
                        c <= 'f' &&
                        c >= '0' &&
                        c <= '9') finalRes = true;
                }

            }
            return hex.Length >= 1 ? finalRes : false;
        }
        public static int Closest(Position pos, int maxPlayers, int moduleAddr, int myTeam, ref double distance) {
            double closestd = 9999999.0f;
            int closest = 0;
            for (int i = 0; i < maxPlayers; i++)
            {
                int entity = (int)moduleAddr + Statics.signatures.dwEntityList + (maxPlayers - 1) * 0x10;
                int address = m.DeployRope<int>((IntPtr)entity);
                int team = m.DeployRope<int>((IntPtr)(entity + Statics.netvars.m_iTeamNum));
                Position p = GetMyPosition(address, m);
                
                if (AsmMath.DistanceBetween(pos, p) < closestd && team != myTeam)
                {
                    closest = address;
                    closestd = AsmMath.DistanceBetween(pos, p);
                    distance = closestd;
                    
                }
            }
            return closest;
        }
        public void Init() {
           
        }
        public static void WriteMessage(string message) {
            Console.WriteLine(message);
        }
        public static void LaunchTrigger() {
            for(; ; ) {
                ACircle(module);
                Thread.Sleep(10);
            }
        }
        public static void LaunchGlow() {
           for(; ; ) {
                LifeCheck();
                Thread.Sleep(10);
            }
        }
        public static void LaunchUtilityGlow() {
            for (; ; )
            {
                UtilityGlow();
                Thread.Sleep(10);
            }
        }
        public static void LaunchTriggerandGlow() {
            while (settingPreset.TriggerOn && settingPreset.GlowEspOn) {
                ACircle(module);
                Thread.Sleep(10);
                LifeCheck();
            }
        }
        public static void LaunchBunny() {
            for(; ; ) {
                Bunny();
                Thread.Sleep(40);
            }
        }
        public static void LaunchNoRec()
        {
            while (true)
            {
                
                while (GetAsyncKeyState(Keys.LButton) != 0)
                {
                    NRec();
                    Thread.Sleep(40);
                }
                
            }
        }
    }
    static class Extension {
        public static float[] ToFloat(this Vector3D v)
        {
            return new float[] {
                v.X,
                v.Y,
                v.Z
            };
        }
        public static Vector3D ToVector3(this float[] arr)
        {
            Vector3D v = new Vector3D();
            v.X = arr[0];
            v.Y = arr[1];
            v.Z = arr[2];
            return v;
        }
    }
}  
    

