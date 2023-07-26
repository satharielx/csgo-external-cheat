using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Threading;
using System.Linq;

namespace whelper.Data {
   
    internal class Math
    {
        public static float M_PI_F = (180.0f / Convert.ToSingle(System.Math.PI));

        public static int GetInt(byte[] bytes, int offset) => (bytes[offset] | bytes[++offset] << 8 | bytes[++offset] << 16 | bytes[++offset] << 24);

        public static float GetDistance3D(Vector3 playerPosition, Vector3 enemyPosition) => Convert.ToSingle(System.Math.Sqrt(System.Math.Pow(enemyPosition.X - playerPosition.X, 2f) + System.Math.Pow(enemyPosition.Y - playerPosition.Y, 2f) + System.Math.Pow(enemyPosition.Z - playerPosition.Z, 2f)));

        public static Vector3 SmoothAim(Vector3 viewAngle, Vector3 destination, float smoothAmount)
        {
            Vector3 smoothedAngle = destination - viewAngle;

            smoothedAngle /= smoothAmount;
            smoothedAngle += viewAngle;

            smoothedAngle = NormalizeAngle(smoothedAngle);
            smoothedAngle = ClampAngle(smoothedAngle);

            return smoothedAngle;
        }

        public static Vector3 ClampAngle(Vector3 angle)
        {
            while (angle.Y > 180) angle.Y -= 360;
            while (angle.Y < -180) angle.Y += 360;

            if (angle.X > 89.0f) angle.X = 89.0f;
            if (angle.X < -89.0f) angle.X = -89.0f;

            angle.Z = 0f;

            return angle;
        }

        public static Vector3 NormalizeAngle(Vector3 angle)
        {
            while (angle.X < -180.0f) angle.X += 360.0f;
            while (angle.X > 180.0f) angle.X -= 360.0f;

            while (angle.Y < -180.0f) angle.Y += 360.0f;
            while (angle.Y > 180.0f) angle.Y -= 360.0f;

            while (angle.Z < -180.0f) angle.Z += 360.0f;
            while (angle.Z > 180.0f) angle.Z -= 360.0f;

            return angle;
        }

        public static Vector3 CalcAngle(Vector3 playerPosition, Vector3 enemyPosition, Vector3 aimPunch, Vector3 vecView, float yawRecoilReductionFactory, float pitchRecoilReductionFactor)
        {
            Vector3 delta = new Vector3(playerPosition.X - enemyPosition.X, playerPosition.Y - enemyPosition.Y, (playerPosition.Z + vecView.Z) - enemyPosition.Z);

            Vector3 tmp = Vector3.Zero;
            tmp.X = Convert.ToSingle(System.Math.Atan(delta.Z / System.Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y))) * 57.295779513082f - aimPunch.X * yawRecoilReductionFactory;
            tmp.Y = Convert.ToSingle(System.Math.Atan(delta.Y / delta.X)) * M_PI_F - aimPunch.Y * pitchRecoilReductionFactor;
            tmp.Z = 0;

            if (delta.X >= 0.0) tmp.Y += 180f;

            tmp = NormalizeAngle(tmp);
            tmp = ClampAngle(tmp);

            return tmp;
        }
    }

    /// <summary>
    /// Class keeping preset data!
    /// </summary>
    /*public class Params {
        public struct Aimlock {
            public static bool Enabled = true;
            public static float Fov = 10f;
            public static int Bone = 8;
            public static float Smooth = 15f;
            public static bool RecoilControl = true;
            public static float YawRecoilReductionFactory = 2f;
            public static float PitchRecoilReductionFactory = 2f;
            public static bool Curve = false;
            public static float CurveY = 0.5f;
            public static float CurveX = 10f;
        }
    }
    public enum Team { 
        Spectator = 0,
        Terrorists = 1,
        CounterTerrorists = 2
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct LocalPlayer_t
    {
        [FieldOffset(Statics.netvars.m_lifeState)]
        public int LifeState;

        [FieldOffset(Statics.netvars.m_iHealth)]
        public int Health;

        [FieldOffset(Statics.netvars.m_fFlags)]
        public int Flags;

        [FieldOffset(Statics.netvars.m_iTeamNum)]
        public int Team;

        [FieldOffset(Statics.netvars.m_iShotsFired)]
        public int ShotsFired;

        [FieldOffset(Statics.netvars.m_iCrosshairId)]
        public int CrosshairID;

        [FieldOffset(Statics.netvars.m_MoveType)]
        public int MoveType;

        [FieldOffset(Statics.netvars.m_vecOrigin)]
        public Vector3 Position;

        [FieldOffset(Statics.netvars.m_aimPunchAngle)]
        public Vector3 AimPunch;

        [FieldOffset(Statics.netvars.m_vecViewOffset)]
        public Vector3 VecView;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Enemy_Crosshair_t
    {
        [FieldOffset(Statics.netvars.m_iHealth)]
        public int Health;

        [FieldOffset(Statics.netvars.m_iTeamNum)]
        public int Team;

    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Enemy_t
    {
        [FieldOffset(Statics.netvars.m_iHealth)]
        public int Health;

        [FieldOffset(Statics.netvars.m_iTeamNum)]
        public int Team;

        [FieldOffset(Statics.netvars.m_bSpotted)]
        public bool Spotted;

        [FieldOffset(Statics.netvars.m_vecOrigin)]
        public Vector3 Position;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ClientState_t
    {
        [FieldOffset(Statics.signatures.dwClientState_State)]
        public int GameState;

        [FieldOffset(Statics.signatures.dwClientState_MaxPlayer)]
        public int MaxPlayers;

        [FieldOffset(Statics.signatures.dwClientState_ViewAngles)]
        public Vector3 ViewAngles;
    }

    public struct Base
    {
        public static IntPtr Client { get; set; }
        public static IntPtr Engine { get; set; }
    }

    public struct LocalPlayer
    {
        public static int Base { get; set; }
        public static int LifeState { get; set; }
        public static int Health { get; set; }
        public static int Flags { get; set; }
        public static int MoveType { get; set; }
        public static int Team { get; set; }
        public static int ShotsFired { get; set; }
        public static int CrosshairID { get; set; }
        public static Vector3 Position { get; set; }
        public static Vector3 AimPunch { get; set; }
        public static Vector3 VecView { get; set; }
    }

    public struct Enemy_Crosshair
    {
        public static int Base { get; set; }
        public static int Health { get; set; }
        public static int Team { get; set; }
    }

    public struct Enemy
    {
        public int Base { get; set; }
        public int Health { get; set; }
        public int Team { get; set; }
        public bool Spotted { get; set; }
        public Vector3 Position { get; set; }
    }

    public struct ClientState
    {
        public static int Base { get; set; }
        public static int GameState { get; set; }
        public static int MaxPlayers { get; set; }
        public static Vector3 ViewAngles { get; set; }
    }

    public class Aimlock
    {
        private LocalPlayer_t localPlayerStruct;
        private ClientState_t clientStateStruct;

        public static Vector3 GetBonePos(int entity, int targetBone)
        {
            int boneMatrix = Program.m.DeployRope<int>((IntPtr)entity + Statics.netvars.m_dwBoneMatrix);

            if (boneMatrix == 0) return Vector3.Zero;

            float[] position = Program.m.ReadMatrix<float>((IntPtr)boneMatrix + 0x30 * targetBone + 0x0C, 9);

            if (!position.Any()) return Vector3.Zero;

            return new Vector3(position[0], position[4], position[8]);
        }

        public void Read() {
            while (true) {
                LocalPlayer.Base = Program.m.DeployRope<int>(Program.module + Statics.signatures.dwLocalPlayer);
                localPlayerStruct = Program.m.DeployRope<LocalPlayer_t>((IntPtr)LocalPlayer.Base);
                LocalPlayer.LifeState = localPlayerStruct.LifeState;
                LocalPlayer.Health = localPlayerStruct.Health;
                LocalPlayer.Flags = localPlayerStruct.Flags;
                LocalPlayer.MoveType = localPlayerStruct.MoveType;
                LocalPlayer.Team = localPlayerStruct.Team;
                LocalPlayer.ShotsFired = localPlayerStruct.ShotsFired;
                LocalPlayer.CrosshairID = localPlayerStruct.CrosshairID;
                LocalPlayer.Position = localPlayerStruct.Position;
                LocalPlayer.AimPunch = localPlayerStruct.AimPunch;
                LocalPlayer.VecView = localPlayerStruct.VecView;
                clientStateStruct = Program.m.DeployRope<ClientState_t>(Program.enginestate);
                ClientState.GameState = clientStateStruct.GameState;
                ClientState.ViewAngles = clientStateStruct.ViewAngles;
                ClientState.MaxPlayers = clientStateStruct.MaxPlayers;
                Thread.Sleep(1);
            }
            
        }
        public void Run() {
            while (true) {
               
                if (!(Program.GetAsyncKeyState(System.Windows.Forms.Keys.LButton) != 0)
                    || LocalPlayer.Health < 1) continue;
                int mPlaya = ClientState.MaxPlayers;
                byte[] entities = Program.m.DeployRope(Program.module + Statics.signatures.dwEntityList, mPlaya * 0x10);
                Dictionary<float, Vector3> possibilities = new Dictionary<float, Vector3>();
                for (int i = 0; i < mPlaya; i++) {
                    int cEntity = Math.GetInt(entities, i * 0x10);
                    Enemy_t entityStruct = Program.m.DeployRope<Enemy_t>((IntPtr)cEntity);
                    if (entityStruct.Team < 1
                        || entityStruct.Team == LocalPlayer.Team
                        || entityStruct.Health < 1) continue;
                    Vector3 bonePosition = GetBonePos(cEntity, Params.Aimlock.Bone);

                    if (bonePosition == Vector3.Zero) continue;

                    Vector3 destination = Params.Aimlock.RecoilControl
                       ? Math.CalcAngle(LocalPlayer.Position, bonePosition, LocalPlayer.AimPunch, LocalPlayer.VecView, Params.Aimlock.YawRecoilReductionFactory, Params.Aimlock.PitchRecoilReductionFactory)
                       : Math.CalcAngle(LocalPlayer.Position, bonePosition, LocalPlayer.AimPunch, LocalPlayer.VecView, 0f, 0f);
                    if (destination == Vector3.Zero) continue;

                    float distance = Math.GetDistance3D(destination, ClientState.ViewAngles);

                    if (!(distance <= Params.Aimlock.Fov)) continue;

                    possibilities.Add(distance, destination);
                }
                if (!possibilities.Any()) continue;

                Vector3 aimAngle = possibilities.OrderByDescending(x => x.Key).LastOrDefault().Value;

                if (Params.Aimlock.Curve)
                {
                    Vector3 qDelta = aimAngle - ClientState.ViewAngles;
                    qDelta += new Vector3(qDelta.Y / Params.Aimlock.CurveY, qDelta.X / Params.Aimlock.CurveX, qDelta.Z);

                    aimAngle = ClientState.ViewAngles + qDelta;
                }
                aimAngle = Math.NormalizeAngle(aimAngle);
                aimAngle = Math.ClampAngle(aimAngle);
                Program.m.CraftRope<Vector3>(Program.enginestate + Statics.signatures.dwClientState_ViewAngles, Params.Aimlock.Smooth == 0f
                    ? aimAngle
                    : Math.SmoothAim(ClientState.ViewAngles, aimAngle, Params.Aimlock.Smooth));
                Program.Print("Locked!");
                Thread.Sleep(Params.Aimlock.Smooth == 0f ? 1 : 45);
            }
        }
    }*/
}
