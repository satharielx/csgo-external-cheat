using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace whelper
{
    public enum classes : int
    {
        /*NextBotCombatCharacter = 0,
        CAK47 = 1,
        CBaseAnimating = 2,
        CBaseAnimatingOverlay = 3,
        CBaseAttributableItem = 4,
        CBaseButton = 5,
        CBaseCombatCharacter = 6,
        CBaseCombatWeapon = 7,
        CBaseCSGrenade = 8,
        CBaseCSGrenadeProjectile = 9,
        CBaseDoor = 10,
        CBaseEntity = 11,
        CBaseFlex = 12,
        CBaseGrenade = 13,
        CBaseParticleEntity = 14,
        CBasePlayer = 15,
        CBasePropDoor = 16,
        CBaseTeamObjectiveResource = 17,
        CBaseTempEntity = 18,
        CBaseToggle = 19,
        CBaseTrigger = 20,
        CBaseViewModel = 21,
        CBaseVPhysicsTrigger = 22,
        CBaseWeaponWorldModel = 23,
        CBeam = 24,
        CBeamSpotlight = 25,
        CBoneFollower = 26,
        CBreakableProp = 27,
        CBreakableSurface = 28,
        CC4 = 29,
        CCascadeLight = 30,
        CChicken = 31,
        CColorCorrection = 32,
        CColorCorrectionVolume = 33,
        CCSGameRulesProxy = 34,
        CCSPlayer = 35,
        CCSPlayerResource = 36,
        CCSRagdoll = 37,
        CCSTeam = 38,
        CDEagle = 39,
        CDecoyGrenade = 40,
        CDecoyProjectile = 41,
        CDynamicLight = 42,
        CDynamicProp = 43,
        CEconEntity = 44,
        CEmbers = 45,
        CEntityDissolve = 46,
        CEntityFlame = 47,
        CEntityFreezing = 48,
        CEntityParticleTrail = 49,
        CEnvAmbientLight = 50,
        CEnvDetailController = 51,
        CEnvDOFController = 52,
        CEnvParticleScript = 53,
        CEnvProjectedTexture = 54,
        CEnvQuadraticBeam = 55,
        CEnvScreenEffect = 56,
        CEnvScreenOverlay = 57,
        CEnvTonemapController = 58,
        CEnvWind = 59,
        CFireCrackerBlast = 60,
        CFireSmoke = 61,
        CFireTrail = 62,
        CFish = 63,
        CFlashbang = 64,
        CFogController = 65,
        CFootstepControl = 66,
        CFunc_Dust = 67,
        CFunc_LOD = 68,
        CFuncAreaPortalWindow = 69,
        CFuncBrush = 70,
        CFuncConveyor = 71,
        CFuncLadder = 72,
        CFuncMonitor = 73,
        CFuncMoveLinear = 74,
        CFuncOccluder = 75,
        CFuncReflectiveGlass = 76,
        CFuncRotating = 77,
        CFuncSmokeVolume = 78,
        CFuncTrackTrain = 79,
        CGameRulesProxy = 80,
        CHandleTest = 81,
        CHEGrenade = 82,
        CHostage = 83,
        CHostageCarriableProp = 84,
        CIncendiaryGrenade = 85,
        CInferno = 86,
        CInfoLadderDismount = 87,
        CInfoOverlayAccessor = 88,
        CKnife = 89,
        CKnifeGG = 90,
        CLightGlow = 91,
        CMaterialModifyControl = 92,
        CMolotovGrenade = 93,
        CMolotovProjectile = 94,
        CMovieDisplay = 95,
        CParticleFire = 96,
        CParticlePerformanceMonitor = 97,
        CParticleSystem = 98,
        CPhysBox = 99,
        CPhysBoxMultiplayer = 100,
        CPhysicsProp = 101,
        CPhysicsPropMultiplayer = 102,
        CPhysMagnet = 103,
        CPlantedC4 = 104,
        CPlasma = 105,
        CPlayerResource = 106,
        CPointCamera = 107,
        CPointCommentaryNode = 108,
        CPoseController = 109,
        CPostProcessController = 110,
        CPrecipitation = 111,
        CPrecipitationBlocker = 112,
        CPredictedViewModel = 113,
        CProp_Hallucination = 114,
        CPropDoorRotating = 115,
        CPropJeep = 116,
        CPropVehicleDriveable = 117,
        CRagdollManager = 118,
        CRagdollProp = 119,
        CRagdollPropAttached = 120,
        CRopeKeyframe = 121,
        CSCAR17 = 122,
        CSceneEntity = 123,
        CShadowControl = 124,
        CSlideshowDisplay = 125,
        CSmokeGrenade = 126,
        CSmokeGrenadeProjectile = 127,
        CSmokeStack = 128,
        CSpatialEntity = 129,
        CSpotlightEnd = 130,
        CSprite = 131,
        CSpriteOriented = 132,
        CSpriteTrail = 133,
        CStatueProp = 134,
        CSteamJet = 135,
        CSun = 136,
        CSunlightShadowControl = 137,
        CTeam = 138,
        CTeamplayRoundBasedRulesProxy = 139,
        CTEArmorRicochet = 140,
        CTEBaseBeam = 141,
        CTEBeamEntPoint = 142,
        CTEBeamEnts = 143,
        CTEBeamFollow = 144,
        CTEBeamLaser = 145,
        CTEBeamPoints = 146,
        CTEBeamRing = 147,
        CTEBeamRingPoint = 148,
        CTEBeamSpline = 149,
        CTEBloodSprite = 150,
        CTEBloodStream = 151,
        CTEBreakModel = 152,
        CTEBSPDecal = 153,
        CTEBubbles = 154,
        CTEBubbleTrail = 155,
        CTEClientProjectile = 156,
        CTEDecal = 157,
        CTEDust = 158,
        CTEDynamicLight = 159,
        CTEEffectDispatch = 160,
        CTEEnergySplash = 161,
        CTEExplosion = 162,
        CTEFireBullets = 163,
        CTEFizz = 164,
        CTEFootprintDecal = 165,
        CTEFoundryHelpers = 166,
        CTEGaussExplosion = 167,
        CTEGlowSprite = 168,
        CTEImpact = 169,
        CTEKillPlayerAttachments = 170,
        CTELargeFunnel = 171,
        CTEMetalSparks = 172,
        CTEMuzzleFlash = 173,
        CTEParticleSystem = 174,
        CTEPhysicsProp = 175,
        CTEPlantBomb = 176,
        CTEPlayerAnimEvent = 177,
        CTEPlayerDecal = 178,
        CTEProjectedDecal = 179,
        CTERadioIcon = 180,
        CTEShatterSurface = 181,
        CTEShowLine = 182,
        CTesla = 183,
        CTESmoke = 184,
        CTESparks = 185,
        CTESprite = 186,
        CTESpriteSpray = 187,
        CTest_ProxyToggle_Networkable = 188,
        CTestTraceline = 189,
        CTEWorldDecal = 190,
        CTriggerPlayerMovement = 191,
        CTriggerSoundOperator = 192,
        CVGuiScreen = 193,
        CVoteController = 194,
        CWaterBullet = 195,
        CWaterLODControl = 196,
        CWeaponAug = 197,
        CWeaponAWP = 198,
        CWeaponBizon = 199,
        CWeaponCSBase = 200,
        CWeaponCSBaseGun = 201,
        CWeaponCycler = 202,
        CWeaponElite = 203,
        CWeaponFamas = 204,
        CWeaponFiveSeven = 205,
        CWeaponG3SG1 = 206,
        CWeaponGalil = 207,
        CWeaponGalilAR = 208,
        CWeaponGlock = 209,
        CWeaponHKP2000 = 210,
        CWeaponM249 = 211,
        CWeaponM3 = 212,
        CWeaponM4A1 = 213,
        CWeaponMAC10 = 214,
        CWeaponMag7 = 215,
        CWeaponMP5Navy = 216,
        CWeaponMP7 = 217,
        CWeaponMP9 = 218,
        CWeaponNegev = 219,
        CWeaponNOVA = 220,
        CWeaponP228 = 221,
        CWeaponP250 = 222,
        CWeaponP90 = 223,
        CWeaponSawedoff = 224,
        CWeaponSCAR20 = 225,
        CWeaponScout = 226,
        CWeaponSG550 = 227,
        CWeaponSG552 = 228,
        CWeaponSG556 = 229,
        CWeaponSSG08 = 230,
        CWeaponTaser = 231,
        CWeaponTec9 = 232,
        CWeaponTMP = 233,
        CWeaponUMP45 = 234,
        CWeaponUSP = 235,
        CWeaponXM1014 = 236,
        CWorld = 237,
        DustTrail = 238,
        MovieExplosion = 239,
        ParticleSmokeGrenade = 240,
        RocketTrail = 241,
        SmokeTrail = 242,
        SporeExplosion = 243,
        SporeTrail = 244*/
        CTestTraceline = 223,
        CTEWorldDecal = 224,
        CTESpriteSpray = 221,
        CTESprite = 220,
        CTESparks = 219,
        CTESmoke = 218,
        CTEShowLine = 216,
        CTEProjectedDecal = 213,
        CFEPlayerDecal = 71,
        CTEPlayerDecal = 212,
        CTEPhysicsProp = 209,
        CTEParticleSystem = 208,
        CTEMuzzleFlash = 207,
        CTELargeFunnel = 205,
        CTEKillPlayerAttachments = 204,
        CTEImpact = 203,
        CTEGlowSprite = 202,
        CTEShatterSurface = 215,
        CTEFootprintDecal = 199,
        CTEFizz = 198,
        CTEExplosion = 196,
        CTEEnergySplash = 195,
        CTEEffectDispatch = 194,
        CTEDynamicLight = 193,
        CTEDecal = 191,
        CTEClientProjectile = 190,
        CTEBubbleTrail = 189,
        CTEBubbles = 188,
        CTEBSPDecal = 187,
        CTEBreakModel = 186,
        CTEBloodStream = 185,
        CTEBloodSprite = 184,
        CTEBeamSpline = 183,
        CTEBeamRingPoint = 182,
        CTEBeamRing = 181,
        CTEBeamPoints = 180,
        CTEBeamLaser = 179,
        CTEBeamFollow = 178,
        CTEBeamEnts = 177,
        CTEBeamEntPoint = 176,
        CTEBaseBeam = 175,
        CTEArmorRicochet = 174,
        CTEMetalSparks = 206,
        CSteamJet = 167,
        CSmokeStack = 157,
        DustTrail = 275,
        CFireTrail = 74,
        SporeTrail = 281,
        SporeExplosion = 280,
        RocketTrail = 278,
        SmokeTrail = 279,
        CPropVehicleDriveable = 144,
        ParticleSmokeGrenade = 277,
        CParticleFire = 116,
        MovieExplosion = 276,
        CTEGaussExplosion = 201,
        CEnvQuadraticBeam = 66,
        CEmbers = 55,
        CEnvWind = 70,
        CPrecipitation = 137,
        CPrecipitationBlocker = 138,
        CBaseTempEntity = 18,
        NextBotCombatCharacter = 0,
        CEconWearable = 54,
        CBaseAttributableItem = 4,
        CEconEntity = 53,
        CWeaponXM1014 = 272,
        CWeaponTaser = 267,
        CTablet = 171,
        CSnowball = 158,
        CSmokeGrenade = 155,
        CWeaponShield = 265,
        CWeaponSG552 = 263,
        CSensorGrenade = 151,
        CWeaponSawedoff = 259,
        CWeaponNOVA = 255,
        CIncendiaryGrenade = 99,
        CMolotovGrenade = 112,
        CMelee = 111,
        CWeaponM3 = 247,
        CKnifeGG = 108,
        CKnife = 107,
        CHEGrenade = 96,
        CFlashbang = 77,
        CFists = 76,
        CWeaponElite = 238,
        CDecoyGrenade = 47,
        CDEagle = 46,
        CWeaponUSP = 271,
        CWeaponM249 = 246,
        CWeaponUMP45 = 270,
        CWeaponTMP = 269,
        CWeaponTec9 = 268,
        CWeaponSSG08 = 266,
        CWeaponSG556 = 264,
        CWeaponSG550 = 262,
        CWeaponScout = 261,
        CWeaponSCAR20 = 260,
        CSCAR17 = 149,
        CWeaponP90 = 258,
        CWeaponP250 = 257,
        CWeaponP228 = 256,
        CWeaponNegev = 254,
        CWeaponMP9 = 253,
        CWeaponMP7 = 252,
        CWeaponMP5Navy = 251,
        CWeaponMag7 = 250,
        CWeaponMAC10 = 249,
        CWeaponM4A1 = 248,
        CWeaponHKP2000 = 245,
        CWeaponGlock = 244,
        CWeaponGalilAR = 243,
        CWeaponGalil = 242,
        CWeaponG3SG1 = 241,
        CWeaponFiveSeven = 240,
        CWeaponFamas = 239,
        CWeaponBizon = 234,
        CWeaponAWP = 232,
        CWeaponAug = 231,
        CAK47 = 1,
        CWeaponCSBaseGun = 236,
        CWeaponCSBase = 235,
        CC4 = 34,
        CBumpMine = 32,
        CBumpMineProjectile = 33,
        CBreachCharge = 28,
        CBreachChargeProjectile = 29,
        CWeaponBaseItem = 233,
        CBaseCSGrenade = 8,
        CSnowballProjectile = 160,
        CSnowballPile = 159,
        CSmokeGrenadeProjectile = 156,
        CSensorGrenadeProjectile = 152,
        CMolotovProjectile = 113,
        CItem_Healthshot = 104,
        CItemDogtags = 106,
        CDecoyProjectile = 48,
        CPhysPropRadarJammer = 126,
        CPhysPropWeaponUpgrade = 127,
        CPhysPropAmmoBox = 124,
        CPhysPropLootCrate = 125,
        CItemCash = 105,
        CEnvGasCanister = 63,
        CDronegun = 50,
        CParadropChopper = 115,
        CSurvivalSpawnChopper = 170,
        CBRC4Target = 27,
        CInfoMapRegion = 102,
        CFireCrackerBlast = 72,
        CInferno = 100,
        CChicken = 36,
        CDrone = 49,
        CFootstepControl = 79,
        CCSGameRulesProxy = 39,
        CWeaponCubemap = 0,
        CWeaponCycler = 237,
        CTEPlantBomb = 210,
        CTEFireBullets = 197,
        CTERadioIcon = 214,
        CPlantedC4 = 128,
        CCSTeam = 43,
        CCSPlayerResource = 41,
        CCSPlayer = 40,
        CPlayerPing = 130,
        CCSRagdoll = 42,
        CTEPlayerAnimEvent = 211,
        CHostage = 97,
        CHostageCarriableProp = 98,
        CBaseCSGrenadeProjectile = 9,
        CHandleTest = 95,
        CTeamplayRoundBasedRulesProxy = 173,
        CSpriteTrail = 165,
        CSpriteOriented = 164,
        CSprite = 163,
        CRagdollPropAttached = 147,
        CRagdollProp = 146,
        CPropCounter = 141,
        CPredictedViewModel = 139,
        CPoseController = 135,
        CGrassBurn = 94,
        CGameRulesProxy = 93,
        CInfoLadderDismount = 101,
        CFuncLadder = 85,
        CTEFoundryHelpers = 200,
        CEnvDetailController = 61,
        CDangerZone = 44,
        CDangerZoneController = 45,
        CWorldVguiText = 274,
        CWorld = 273,
        CWaterLODControl = 230,
        CWaterBullet = 229,
        CVoteController = 228,
        CVGuiScreen = 227,
        CPropJeep = 143,
        CPropVehicleChoreoGeneric = 0,
        CTriggerSoundOperator = 226,
        CBaseVPhysicsTrigger = 22,
        CTriggerPlayerMovement = 225,
        CBaseTrigger = 20,
        CTest_ProxyToggle_Networkable = 222,
        CTesla = 217,
        CBaseTeamObjectiveResource = 17,
        CTeam = 172,
        CSunlightShadowControl = 169,
        CSun = 168,
        CParticlePerformanceMonitor = 117,
        CSpotlightEnd = 162,
        CSpatialEntity = 161,
        CSlideshowDisplay = 154,
        CShadowControl = 153,
        CSceneEntity = 150,
        CRopeKeyframe = 148,
        CRagdollManager = 145,
        CPhysicsPropMultiplayer = 122,
        CPhysBoxMultiplayer = 120,
        CPropDoorRotating = 142,
        CBasePropDoor = 16,
        CDynamicProp = 52,
        CProp_Hallucination = 140,
        CPostProcessController = 136,
        CPointWorldText = 134,
        CPointCommentaryNode = 133,
        CPointCamera = 132,
        CPlayerResource = 131,
        CPlasma = 129,
        CPhysMagnet = 123,
        CPhysicsProp = 121,
        CStatueProp = 166,
        CPhysBox = 119,
        CParticleSystem = 118,
        CMovieDisplay = 114,
        CMaterialModifyControl = 110,
        CLightGlow = 109,
        CItemAssaultSuitUseable = 0,
        CItem = 0,
        CInfoOverlayAccessor = 103,
        CFuncTrackTrain = 92,
        CFuncSmokeVolume = 91,
        CFuncRotating = 90,
        CFuncReflectiveGlass = 89,
        CFuncOccluder = 88,
        CFuncMoveLinear = 87,
        CFuncMonitor = 86,
        CFunc_LOD = 81,
        CTEDust = 192,
        CFunc_Dust = 80,
        CFuncConveyor = 84,
        CFuncBrush = 83,
        CBreakableSurface = 31,
        CFuncAreaPortalWindow = 82,
        CFish = 75,
        CFireSmoke = 73,
        CEnvTonemapController = 69,
        CEnvScreenEffect = 67,
        CEnvScreenOverlay = 68,
        CEnvProjectedTexture = 65,
        CEnvParticleScript = 64,
        CFogController = 78,
        CEnvDOFController = 62,
        CCascadeLight = 35,
        CEnvAmbientLight = 60,
        CEntityParticleTrail = 59,
        CEntityFreezing = 58,
        CEntityFlame = 57,
        CEntityDissolve = 56,
        CDynamicLight = 51,
        CColorCorrectionVolume = 38,
        CColorCorrection = 37,
        CBreakableProp = 30,
        CBeamSpotlight = 25,
        CBaseButton = 5,
        CBaseToggle = 19,
        CBasePlayer = 15,
        CBaseFlex = 12,
        CBaseEntity = 11,
        CBaseDoor = 10,
        CBaseCombatCharacter = 6,
        CBaseAnimatingOverlay = 3,
        CBoneFollower = 26,
        CBaseAnimating = 2,
        CAI_BaseNPC = 0,
        CBeam = 24,
        CBaseViewModel = 21,
        CBaseParticleEntity = 14,
        CBaseGrenade = 13,
        CBaseCombatWeapon = 7,
        CBaseWeaponWorldModel = 23
    }
    public static class Statics
    {

        public const Int32 timestamp = 1640707526;
        public static class netvars
        {
            public static Int32 cs_gamerules_data = 0x0;
            public static Int32 m_ArmorValue = 0x117CC;
            public static Int32 m_Collision = 0x320;
            public static Int32 m_CollisionGroup = 0x474;
            public static Int32 m_Local = 0x2FCC;
            public static Int32 m_MoveType = 0x25C;
            public static Int32 m_OriginalOwnerXuidHigh = 0x31D4;
            public static Int32 m_OriginalOwnerXuidLow = 0x31D0;
            public static Int32 m_SurvivalGameRuleDecisionTypes = 0x1328;
            public static Int32 m_SurvivalRules = 0xD00;
            public static Int32 m_aimPunchAngle = 0x303C;
            public static Int32 m_aimPunchAngleVel = 0x3048;
            public static Int32 m_angEyeAnglesX = 0x117D0;
            public static Int32 m_angEyeAnglesY = 0x117D4;
            public static Int32 m_bBombDefused = 0x29C0;
            public static Int32 m_bBombPlanted = 0x9A5;
            public static Int32 m_bBombTicking = 0x2990;
            public static Int32 m_bFreezePeriod = 0x20;
            public static Int32 m_bGunGameImmunity = 0x9990;
            public static Int32 m_bHasDefuser = 0x117DC;
            public static Int32 m_bHasHelmet = 0x117C0;
            public static Int32 m_bInReload = 0x32B5;
            public static Int32 m_bIsDefusing = 0x997C;
            public static Int32 m_bIsQueuedMatchmaking = 0x74;
            public static Int32 m_bIsScoped = 0x9974;
            public static Int32 m_bIsValveDS = 0x7C;
            public static Int32 m_bSpotted = 0x93D;
            public static Int32 m_bSpottedByMask = 0x980;
            public static Int32 m_bStartedArming = 0x3400;
            public static Int32 m_bUseCustomAutoExposureMax = 0x9D9;
            public static Int32 m_bUseCustomAutoExposureMin = 0x9D8;
            public static Int32 m_bUseCustomBloomScale = 0x9DA;
            public static Int32 m_clrRender = 0x70;
            public static Int32 m_dwBoneMatrix = 0x26A8;
            public static Int32 m_fAccuracyPenalty = 0x3340;
            public static Int32 m_fFlags = 0x104;
            public static Int32 m_flC4Blow = 0x29A0;
            public static Int32 m_flCustomAutoExposureMax = 0x9E0;
            public static Int32 m_flCustomAutoExposureMin = 0x9DC;
            public static Int32 m_flCustomBloomScale = 0x9E4;
            public static Int32 m_flDefuseCountDown = 0x29BC;
            public static Int32 m_flDefuseLength = 0x29B8;
            public static Int32 m_flFallbackWear = 0x31E0;
            public static Int32 m_flFlashDuration = 0x10470;
            public static Int32 m_flFlashMaxAlpha = 0x1046C;
            public static Int32 m_flLastBoneSetupTime = 0x2928;
            public static Int32 m_flLowerBodyYawTarget = 0x9ADC;
            public static Int32 m_flNextAttack = 0x2D80;
            public static Int32 m_flNextPrimaryAttack = 0x3248;
            public static Int32 m_flSimulationTime = 0x268;
            public static Int32 m_flTimerLength = 0x29A4;
            public static Int32 m_hActiveWeapon = 0x2F08;
            public static Int32 m_hBombDefuser = 0x29C4;
            public static Int32 m_hMyWeapons = 0x2E08;
            public static Int32 m_hObserverTarget = 0x339C;
            public static Int32 m_hOwner = 0x29DC;
            public static Int32 m_hOwnerEntity = 0x14C;
            public static Int32 m_hViewModel = 0x3308;
            public static Int32 m_iAccountID = 0x2FD8;
            public static Int32 m_iClip1 = 0x3274;
            public static Int32 m_iCompetitiveRanking = 0x1A84;
            public static Int32 m_iCompetitiveWins = 0x1B88;
            public static Int32 m_iCrosshairId = 0x11838;
            public static Int32 m_iDefaultFOV = 0x333C;
            public static Int32 m_iEntityQuality = 0x2FBC;
            public static Int32 m_iFOV = 0x31F4;
            public static Int32 m_iFOVStart = 0x31F8;
            public static Int32 m_iGlowIndex = 0x10488;
            public static Int32 m_iHealth = 0x100;
            public static Int32 m_iItemDefinitionIndex = 0x2FBA;
            public static Int32 m_iItemIDHigh = 0x2FD0;
            public static Int32 m_iMostRecentModelBoneCounter = 0x2690;
            public static Int32 m_iObserverMode = 0x3388;
            public static Int32 m_iShotsFired = 0x103E0;
            public static Int32 m_iState = 0x3268;
            public static Int32 m_iTeamNum = 0xF4;
            public static Int32 m_lifeState = 0x25F;
            public static Int32 m_nBombSite = 0x2994;
            public static Int32 m_nFallbackPaintKit = 0x31D8;
            public static Int32 m_nFallbackSeed = 0x31DC;
            public static Int32 m_nFallbackStatTrak = 0x31E4;
            public static Int32 m_nForceBone = 0x268C;
            public static Int32 m_nTickBase = 0x3440;
            public static Int32 m_nViewModelIndex = 0x29D0;
            public static Int32 m_rgflCoordinateFrame = 0x444;
            public static Int32 m_szCustomName = 0x304C;
            public static Int32 m_szLastPlaceName = 0x35C4;
            public static Int32 m_thirdPersonViewAngles = 0x31E8;
            public static Int32 m_vecOrigin = 0x138;
            public static Int32 m_vecVelocity = 0x114;
            public static Int32 m_vecViewOffset = 0x108;
            public static Int32 m_viewPunchAngle = 0x3030;
            public static Int32 m_zoomLevel = 0x33E0;
        }
        public static class signatures
        {
            public static Int32 anim_overlays = 0x2990;
            public static Int32 clientstate_choked_commands = 0x4D30;
            public static Int32 clientstate_delta_ticks = 0x174;
            public static Int32 clientstate_last_outgoing_command = 0x4D2C;
            public static Int32 clientstate_net_channel = 0x9C;
            public static Int32 convar_name_hash_table = 0x2F0F8;
            public static Int32 dwClientState = 0x58CFBC;
            public static Int32 dwClientState_GetLocalPlayer = 0x180;
            public static Int32 dwClientState_IsHLTV = 0x4D48;
            public static Int32 dwClientState_Map = 0x28C;
            public static Int32 dwClientState_MapDirectory = 0x188;
            public static Int32 dwClientState_MaxPlayer = 0x388;
            public static Int32 dwClientState_PlayerInfo = 0x52C0;
            public static Int32 dwClientState_State = 0x108;
            public static Int32 dwClientState_ViewAngles = 0x4D90;
            public static Int32 dwEntityList = 0x4DD345C;
            public static Int32 dwForceAttack = 0x3203904;
            public static Int32 dwForceAttack2 = 0x3203910;
            public static Int32 dwForceBackward = 0x3203934;
            public static Int32 dwForceForward = 0x3203928;
            public static Int32 dwForceJump = 0x527D370;
            public static Int32 dwForceLeft = 0x3203940;
            public static Int32 dwForceRight = 0x320394C;
            public static Int32 dwGameDir = 0x62B900;
            public static Int32 dwGameRulesProxy = 0x52F0B9C;
            public static Int32 dwGetAllClasses = 0xDE177C;
            public static Int32 dwGlobalVars = 0x58CCC0;
            public static Int32 dwGlowObjectManager = 0x531C048;
            public static Int32 dwInput = 0x5224A30;
            public static Int32 dwInterfaceLinkList = 0x9697B4;
            public static Int32 dwLocalPlayer = 0xDB75DC;
            public static Int32 dwMouseEnable = 0xDBD2E8;
            public static Int32 dwMouseEnablePtr = 0xDBD2B8;
            public static Int32 dwPlayerResource = 0x3201CC0;
            public static Int32 dwRadarBase = 0x52081D4;
            public static Int32 dwSensitivity = 0xDBD184;
            public static Int32 dwSensitivityPtr = 0xDBD158;
            public static Int32 dwSetClanTag = 0x8A3A0;
            public static Int32 dwViewMatrix = 0x4DC4D74;
            public static Int32 dwWeaponTable = 0x52254F4;
            public static Int32 dwWeaponTableIndex = 0x326C;
            public static Int32 dwYawPtr = 0xDBCF48;
            public static Int32 dwZoomSensitivityRatioPtr = 0xDC31B0;
            public static Int32 dwbSendPackets = 0xD96A2;
            public static Int32 dwppDirect3DDevice9 = 0xA5050;
            public static Int32 find_hud_element = 0x58D85200;
            public static Int32 force_update_spectator_glow = 0x3BB99A;
            public static Int32 interface_engine_cvar = 0x3E9EC;
            public static Int32 is_c4_owner = 0x3C8A10;
            public static Int32 m_bDormant = 0xED;
            public static Int32 m_flSpawnTime = 0x103C0;
            public static Int32 m_pStudioHdr = 0x2950;
            public static Int32 m_pitchClassPtr = 0x5208470;
            public static Int32 m_yawClassPtr = 0xDBCF48;
            public static Int32 model_ambient_min = 0x590034;
            public static Int32 set_abs_angles = 0x1E5570;
            public static Int32 set_abs_origin = 0x1E53B0;
        }
        public class Offset
        {
            public Int32 Address;
            public string Name;
            public Offset(string name, Int32 addresss)
            {
                Address = addresss;
                Name = name;
            }
            public void Print()
            {
                Console.WriteLine($"{Name} = 0x{Address.ToString("X2")}");
            }
        }
        public class OffsetScanner
        {
            public Dictionary<string, List<Offset>> collectedOffsets = new Dictionary<string, List<Offset>>();
            private List<string> rawInfo = new List<string>();
            public OffsetScanner() { }
            public void Start()
            {
                DownloadInfo();
            }
            public bool IsOperationFinished = false;
            public void GetOffsets()
            {
                if (rawInfo.Count > 0)
                {
                    int idx = 0;
                    foreach (string line in rawInfo)
                    {
                        Thread.Sleep(0);
                        
                        if (IsClass(line))
                        {
                            List<string> classMembers = new List<string>();
                            string className = ClassName(line);
                            collectedOffsets.Add(className, new List<Offset>());
                            string temp = string.Join("\n", rawInfo);
                            string[] members = temp.Split(new string[] { "public static class" }, StringSplitOptions.None);
                   
                            foreach (string segment in members)
                            {
                                foreach (string line2 in segment.Split('\n')) {
                                    Thread.Sleep(0);
                                    Console.WriteLine(line);
                                    if (IsField(line2))
                                    {
                                        string vName = ValueName(line2);
                                        int val = Value(line2);
                                        collectedOffsets[className].Add(new Offset(vName, val));
                                    }
                                    else continue;
                                }
                            }
                        }
                        
                    }
                    AssignOffsets();
                }

            }
            public void AssignOffsets()
            {
                foreach (string line in collectedOffsets.Keys)
                {
                    List<Offset> offsets = collectedOffsets[line];
                    
                    string assemblyName = "Statics";
                    string typeName = $"{assemblyName}.{line}";
                    string qualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
                    Console.WriteLine($"Class Name: {line}");
                    
                    if (line == "netvars")
                    {
                        Type classF = null;
                        classF = typeof(netvars);
                        Console.WriteLine($"Class Found: {classF.FullName}");
                        FieldInfo[] offs = classF.GetFields();
                        foreach (Offset o in offsets)
                        {

                            foreach (FieldInfo f in offs)
                            {

                                if (f.Name == o.Name)
                                {
                                    o.Print();
                                    f.SetValue(null, o.Address);
                                    Console.WriteLine($"{f.Name} -> {f.GetValue(classF)}");
                                }
                            }
                        }
                    }
                    else if (line == "signatures") {
                        Type classF = null;
                        classF = typeof(signatures);
                        Console.WriteLine($"Class Found: {classF.FullName}");
                        FieldInfo[] offs = classF.GetFields();
                        foreach (Offset o in offsets)
                        {

                            foreach (FieldInfo f in offs)
                            {

                                if (f.Name == o.Name)
                                {
                                    o.Print();
                                    f.SetValue(null, o.Address);
                                    Console.WriteLine($"{f.Name} -> {f.GetValue(classF)}");
                                }
                            }
                        }
                    } 
                    
                   
                }
                IsOperationFinished = true;
            }
            private void DownloadInfo()
            {
                string url = "https://raw.githubusercontent.com/frk1/hazedumper/master/csgo.cs";
                WebClient engine = new WebClient();
                rawInfo = engine.DownloadString(url).Split('\n').Skip(7).ToList();
                Console.WriteLine(string.Join("\n", rawInfo));
                Thread.Sleep(300);
                GetOffsets();
            }
            private bool IsClass(string line)
            {
                return (line.Contains("public static class"));
            }
            private bool IsField(string line)
            {
                return (line.Contains("public const Int32"));
            }
            private string ClassName(string line)
            {
                Console.WriteLine(line.Substring(line.IndexOf("public static class") + "public static class".Length + 1).Trim());
                return line.Substring(line.IndexOf("public static class") + "public static class".Length + 1).Trim();
            }
            private string ValueName(string line)
            {
                return line.Substring(line.IndexOf("public const Int32") +
                    "public const Int32".Length + 1,
                    line.IndexOf("=") - (line.IndexOf("public const Int32") +
                    "public const Int32".Length + 1)).Trim();
            }
            private Int32 Value(string line)
            {
                //Console.WriteLine(line.Substring(line.IndexOf("=") + "=".Length + 1, line.IndexOf(';') - (line.IndexOf("=") + 1) - 1).Trim());
                return Convert.ToInt32(line.Substring(line.IndexOf("=") + "=".Length + 1, line.IndexOf(';') - (line.IndexOf("=") + 1) - 1).Trim(), 16);
            }
        }
    }
    
}