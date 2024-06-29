using Terraria;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Linq;
using System;
using System.Threading;

//this is my own libary that I use to store snipits. I don't want it to be it's own mod, so I'll use copy and paste this file when needed.
namespace RainRandomEnemies
{
    public class ffVar
    {
        //list of all the boss parts
        public static int[] BossParts = { NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.Creeper,
            NPCID.SkeletronHand, NPCID.WallofFleshEye, NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PlanterasHook, NPCID.PlanterasTentacle,
            NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistBossClone, NPCID.MoonLordCore,
            NPCID.MoonLordHand, NPCID.MoonLordHead, NPCID.MoonLordFreeEye, NPCID.MoonLordLeechBlob };

        public static int[] MiniBosses = {NPCID.BloodNautilus, NPCID.DD2DarkMageT1, NPCID.DD2DarkMageT3, NPCID.DD2OgreT2, NPCID.DD2OgreT3, NPCID.DD2Betsy,
            NPCID.PirateShip, NPCID.MourningWood, NPCID.Pumpking, NPCID.Everscream, NPCID.SantaNK1, NPCID.IceQueen, NPCID.MartianSaucer,
            NPCID.LunarTowerSolar, NPCID.LunarTowerVortex, NPCID.LunarTowerNebula, NPCID.LunarTowerStardust};

        public class Slimes
        {
            //list of all  the normal slimes
            public static int[] normalSlimes = { NPCID.GreenSlime, NPCID.BlueSlime, NPCID.RedSlime,
                NPCID.PurpleSlime, NPCID.YellowSlime, NPCID.BlackSlime };

            //list of all slimes that can only be found in certain biomes
            public static int[] biomeSlimes = { NPCID.IceSlime, NPCID.SpikedIceSlime, NPCID.SandSlime,
                NPCID.JungleSlime, NPCID.JungleSlime, NPCID.MotherSlime, NPCID.BabySlime, NPCID.LavaSlime, NPCID.ShimmerSlime};

            //list of all slimes that can only be found in hardmode
            public static int[] hardmodeSlimes = { NPCID.ToxicSludge, NPCID.CorruptSlime, NPCID.Slimeling,
                NPCID.Slimer, NPCID.Slimer2,  NPCID.Crimslime, NPCID.Gastropod, NPCID.IlluminantSlime};

            //list of all slimes that are special/rare
            public static int[] specialSlimes = { NPCID.Pinky, NPCID.GoldenSlime, NPCID.UmbrellaSlime,
                NPCID.WindyBalloon, NPCID.DungeonSlime};

            //list of all slimes that are a part of a hoilday
            public static int[] festiveSlimes = { NPCID.SlimeMasked, NPCID.SlimeRibbonGreen, NPCID.SlimeRibbonRed,
                NPCID.SlimeRibbonYellow, NPCID.SlimeRibbonWhite };

            //list of all slimes that are bosses
            public static int[] bossSlime = { NPCID.KingSlime, NPCID.QueenSlimeBoss };

            //list of all slimes that are boss minions
            public static int[] bossMinionSlimes = { NPCID.SlimeSpiked, NPCID.QueenSlimeMinionBlue, NPCID.QueenSlimeMinionPink,
                NPCID.QueenSlimeMinionPurple };

            //list of all slimes in vanilla
            public static int[] allSlimes = normalSlimes.Concat(biomeSlimes).ToArray().Concat(hardmodeSlimes).ToArray()
                .Concat(specialSlimes).ToArray().Concat(festiveSlimes).ToArray()
                .Concat(bossSlime).ToArray().Concat(bossMinionSlimes).ToArray();
        }

        public class Zombies
        {
            //list of all the different types of zombies in vanilla
            public static int[] normalZombies = {NPCID.Zombie, NPCID.SmallZombie, NPCID.BigZombie, NPCID.ArmedZombie,
            NPCID.BaldZombie, NPCID.SmallBaldZombie, NPCID.BigBaldZombie,
            NPCID.PincushionZombie, NPCID.SmallPincushionZombie, NPCID.BigPincushionZombie, NPCID.ArmedZombiePincussion,
            NPCID.SlimedZombie, NPCID.SmallSlimedZombie, NPCID.BigSlimedZombie, NPCID.ArmedZombieSlimed,
            NPCID.SwampZombie, NPCID.SmallSwampZombie, NPCID.BigSwampZombie, NPCID.ArmedZombieSwamp,
            NPCID.TwiggyZombie, NPCID.SmallTwiggyZombie, NPCID.BigTwiggyZombie, NPCID.ArmedZombieTwiggy,
            NPCID.FemaleZombie, NPCID.SmallFemaleZombie, NPCID.BigFemaleZombie, NPCID.ArmedZombieCenx,
            NPCID.TorchZombie, NPCID.ArmedTorchZombie};

            //list of all the variant zombies in vanilla
            public static int[] variantZombies = {NPCID.ZombieDoctor, NPCID.ZombieSuperman, NPCID.ZombiePixie,
            NPCID.ZombieXmas, NPCID.ZombieSweater,
            NPCID.ZombieEskimo, NPCID.ArmedZombieEskimo,
            NPCID.ZombieRaincoat, NPCID.SmallRainZombie, NPCID.BigRainZombie,
            NPCID.MaggotZombie};

            //list of all the blood moon zombies in vanilla
            public static int[] bloodZombies = { NPCID.BloodZombie, NPCID.TheBride, NPCID.TheGroom };

            //list of all the special zombies in vanilla
            public static int[] specialZombies = { NPCID.DoctorBones, NPCID.ZombieMerman };

            //list of all the hardmode zombies in vanilla
            public static int[] hardmodeZombies = { NPCID.ZombieMushroom, NPCID.ZombieMushroomHat, NPCID.Eyezor };

            //list of all zombies in vanilla
            public static int[] allZombies = normalZombies.Concat(variantZombies).ToArray()
                .Concat(bloodZombies).ToArray()
                .Concat(specialZombies).ToArray()
                .Concat(hardmodeZombies).ToArray();
        }

        public class Hornets
        {
            public static int[] normalHornets = { NPCID.Hornet, NPCID.BigStinger, NPCID.LittleStinger, NPCID.HornetFatty,
                NPCID.LittleHornetFatty, NPCID.BigHornetFatty, NPCID.HornetHoney, NPCID.LittleHornetFatty, NPCID.BigHornetFatty,
                NPCID.HornetLeafy, NPCID.BigHornetLeafy, NPCID.LittleHornetLeafy, NPCID.HornetSpikey, NPCID.LittleHornetSpikey,
                NPCID.BigHornetSpikey, NPCID.BigHornetStingy, NPCID.LittleHornetStingy, NPCID.HornetStingy};

            public static int[] mossHornets = { NPCID.MossHornet, NPCID.TinyMossHornet, NPCID.LittleMossHornet, 
                NPCID.BigMossHornet, NPCID.GiantMossHornet };
        }

        public class FloatingEyes
        {
            public static int[] DemonEyes = { NPCID.DemonEye, NPCID.DemonEye2, NPCID.CataractEye, NPCID.CataractEye2,
                NPCID.SleepyEye, NPCID.SleepyEye2, NPCID.DialatedEye, NPCID.DialatedEye2, NPCID.GreenEye, NPCID.GreenEye2,
                NPCID.PurpleEye, NPCID.PurpleEye2};

            public static int[] DemonEyeHalloween = { NPCID.DemonEyeOwl, NPCID.DemonEyeSpaceship };

            public static int[] BloodEyes = { NPCID.EyeballFlyingFish, NPCID.Drippler };

            public static int[] Bosses = { NPCID.EyeofCthulhu, NPCID.Spazmatism, NPCID.Retinazer };

            public static int[] HardDemonEyes = { NPCID.WanderingEye };

            public static int[] BossesMinions = { NPCID.ServantofCthulhu };
        }

        public class Skeleton
        {
            public static int[] normalSkeletons = {NPCID.Skeleton, NPCID.BoneThrowingSkeleton, NPCID.SmallSkeleton,
                NPCID.BigSkeleton, NPCID.HeadacheSkeleton, NPCID.SmallHeadacheSkeleton, NPCID.BigHeadacheSkeleton,
                NPCID.MisassembledSkeleton, NPCID.BigMisassembledSkeleton, NPCID.SmallMisassembledSkeleton,
                NPCID.PantlessSkeleton, NPCID.SmallPantlessSkeleton, NPCID.BigPantlessSkeleton};

            public static int[] speicalSkeletons = { NPCID.UndeadMiner, NPCID.UndeadViking, NPCID.Tim, NPCID.GreekSkeleton };

            public static int[] halloweenSkeletons = { NPCID.SkeletonTopHat, NPCID.SkeletonAstonaut, NPCID.SkeletonAlien };

            public static int[] hardmodeSekeltons = { NPCID.SkeletonArcher, NPCID.RuneWizard };

            public static int[] dungeonSkeletons = { NPCID.AngryBones, NPCID.ShortBones, NPCID.BigBoned,
                NPCID.AngryBonesBig, NPCID.AngryBonesBigHelmet, NPCID.AngryBonesBigMuscle, NPCID.DarkCaster, NPCID.CursedSkull };

            public static int[] ppDungeonSkeletons = { NPCID.RustyArmoredBonesAxe, NPCID.RustyArmoredBonesSword,
                NPCID.RustyArmoredBonesFlail, NPCID.RustyArmoredBonesSwordNoArmor, NPCID.BlueArmoredBones,
                NPCID.BlueArmoredBonesMace, NPCID.BlueArmoredBonesSword, NPCID.BlueArmoredBonesNoPants, NPCID.HellArmoredBones,
                NPCID.HellArmoredBonesMace, NPCID.HellArmoredBonesSword, NPCID.HellArmoredBonesSpikeShield, NPCID.Necromancer,
                NPCID.NecromancerArmored, NPCID.RaggedCaster, NPCID.RaggedCasterOpenCoat, NPCID.DiabolistRed,
                NPCID.DiabolistWhite, NPCID.SkeletonCommando, NPCID.SkeletonSniper, NPCID.TacticalSkeleton,
                NPCID.GiantCursedSkull, NPCID.BoneLee, NPCID.Paladin};

            public static int[] bosses = { NPCID.SkeletronHead, NPCID.SkeletronPrime, NPCID.DungeonGuardian };
            public static int[] bossesMinions = { NPCID.SkeletronHand, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw,
            NPCID.PrimeVice };
        }

        public class Worms
        {
            public static int[] normalWorms = { NPCID.GiantWormHead, NPCID.DevourerHead, NPCID.TombCrawlerHead,
                NPCID.BoneSerpentHead};

            public static int[] minionsWorms = { NPCID.LeechHead };

            public static int[] hardmodeWorms = { NPCID.DiggerHead, NPCID.SeekerHead, NPCID.DuneSplicerHead };

            public static int[] speicalWorms = { NPCID.WyvernHead, NPCID.BloodEelHead };

            public static int[] pillarsWorms = { NPCID.CultistDragonHead, NPCID.SolarCrawltipedeHead, NPCID.StardustWormHead };

            public static int[] bossWorms = { NPCID.EaterofWorldsHead, NPCID.TheDestroyer };
        }

        public class Bats
        {
            public static int[] normalBats = { NPCID.CaveBat, NPCID.JungleBat, NPCID.Hellbat, NPCID.IceBat, NPCID.SporeBat };
            public static int[] hardmodeBats = { NPCID.GiantBat, NPCID.IlluminantBat, NPCID.Lavabat };
            public static int[] speicalBats = { NPCID.VampireBat };
        }

        public class BloodMoons
        {
            public static int[] preHardmode = { NPCID.TheGroom, NPCID.TheBride, NPCID.BloodZombie, NPCID.Drippler };
            public static int[] corruptionEnemies = { NPCID.CorruptBunny, NPCID.CorruptGoldfish, NPCID.CorruptPenguin };
            public static int[] crimsonEnemies = { NPCID.CrimsonBunny, NPCID.CrimsonGoldfish, NPCID.CrimsonPenguin };
            public static int[] preHardmodeFishing = { NPCID.WanderingEye, NPCID.ZombieMerman };

            public static int[] Hardmode = { NPCID.Clown, NPCID.ChatteringTeethBomb };
            public static int[] HardmodeFishing = { NPCID.GoblinShark, NPCID.BloodEelHead, NPCID.BloodSquid };
            public static int[] Boss = { NPCID.BloodNautilus };
        }

        public class GoblinArmy
        {
            public static int[] preHardmode = { NPCID.GoblinPeon, NPCID.GoblinSorcerer, NPCID.GoblinThief, NPCID.GoblinWarrior,
                NPCID.GoblinArcher};
            public static int[] hardmode = { NPCID.GoblinSummoner, NPCID.ShadowFlameApparition };
        }

        public class OOA 
        { 
            public static int[] Tier1 = {NPCID.DD2GoblinT1, NPCID.DD2GoblinBomberT1, NPCID.DD2JavelinstT1, NPCID.DD2WyvernT1, NPCID.DD2SkeletonT1};
            public static int[] Tier2 = { NPCID.DD2GoblinT2, NPCID.DD2GoblinBomberT2, NPCID.DD2JavelinstT2, NPCID.DD2WyvernT2, NPCID.DD2KoboldWalkerT2,
                NPCID.DD2KoboldWalkerT2, NPCID.DD2DrakinT2, NPCID.DD2WitherBeastT2};
            public static int[] Tier3 = { NPCID.DD2GoblinT3, NPCID.DD2GoblinBomberT3, NPCID.DD2JavelinstT3, NPCID.DD2WyvernT3, NPCID.DD2KoboldWalkerT3,
                NPCID.DD2KoboldWalkerT3, NPCID.DD2DrakinT3, NPCID.DD2WitherBeastT3, NPCID.DD2LightningBugT3, NPCID.DD2SkeletonT3 };
            public static int[] Bosses = { NPCID.DD2DarkMageT1, NPCID.DD2DarkMageT3, NPCID.DD2OgreT2, NPCID.DD2OgreT3, NPCID.DD2Betsy };
        }

        public static int[] FrostLegion = { NPCID.MisterStabby, NPCID.SnowmanGangsta, NPCID.SnowBalla };

        public class SolarEclipse
        {
            public static int[] always = { NPCID.SwampThing, NPCID.Frankenstein, NPCID.Eyezor, NPCID.Vampire, NPCID.ThePossessed,
            NPCID.Fritz, NPCID.CreatureFromTheDeep, NPCID.Reaper };

            public static int[] postPlantera = { NPCID.Butcher, NPCID.Nailhead, NPCID.DeadlySphere, NPCID.Psycho, NPCID.DrManFly,
            NPCID.Mothron, NPCID.MothronEgg, NPCID.MothronSpawn };
        }

        public class PirateInvasion
        {
            public static int[] normalEnemies = {NPCID.Parrot, NPCID.PirateCrossbower, NPCID.PirateCorsair, NPCID.PirateDeadeye,
            NPCID.PirateDeckhand};
            public static int[] miniBoss = { NPCID.PirateCaptain, NPCID.PirateGhost };
            public static int[] Boss = { NPCID.PirateShip };
        }

        public class PumpkinMoon
        {
            public static int[] normalEnemies = { NPCID.Scarecrow1, NPCID.Scarecrow2, NPCID.Scarecrow3, NPCID.Scarecrow4, NPCID.Scarecrow5,
                NPCID.Scarecrow6, NPCID.Scarecrow7, NPCID.Scarecrow8, NPCID.Scarecrow9, NPCID.Scarecrow10,  NPCID.Splinterling, NPCID.Poltergeist, 
                NPCID.HeadlessHorseman};

            public static int[] miniBoss = { NPCID.MourningWood, NPCID.Pumpking };
        }

        public class FrostMoon
        {
            public static int[] normalEnemies = { NPCID.PresentMimic, NPCID.Flocko, NPCID.GingerbreadMan, NPCID.ZombieElf, NPCID.ElfArcher,
                NPCID.Nutcracker, NPCID.Yeti, NPCID.ElfCopter, NPCID.Krampus };

            public static int[] miniBoss = { NPCID.Everscream, NPCID.SantaNK1, NPCID.IceQueen };
        }

        public class  MartianMadness
        {
            public static int[] normalEnemies = {NPCID.Scutlix, NPCID.ScutlixRider, NPCID.MartianDrone, NPCID.MartianOfficer, NPCID.MartianWalker,
                NPCID.MartianTurret, NPCID.MartianDrone, NPCID.MartianEngineer, NPCID.RayGunner, NPCID.GrayGrunt, NPCID.BrainScrambler};

            public static int[] miniBoss = { NPCID.MartianSaucer };
        }

        public class LunarEvents
        {
            public static int[] solarEnemies = { NPCID.SolarCorite, NPCID.SolarCrawltipedeHead, NPCID.SolarDrakomire, 
                NPCID.SolarDrakomireRider, NPCID.SolarSroller, NPCID.SolarSpearman, NPCID.SolarSolenian};

            public static int[] vortexEnemies = { NPCID.VortexHornet, NPCID.VortexHornetQueen, NPCID.VortexLarva, 
                NPCID.VortexRifleman, NPCID.VortexSoldier };

            public static int[] nebulaEnemies = { NPCID.NebulaBeast, NPCID.NebulaBrain, NPCID.NebulaHeadcrab, 
                NPCID.NebulaSoldier };

            public static int[] stardustEnemies = { NPCID.StardustCellBig, NPCID.StardustCellSmall, NPCID.StardustJellyfishBig, 
                NPCID.StardustJellyfishSmall, NPCID.StardustSoldier, NPCID.StardustSpiderBig, NPCID.StardustSpiderSmall, 
                NPCID.StardustWormHead};

            public static int[] pillars = { NPCID.LunarTowerSolar, NPCID.LunarTowerVortex, NPCID.LunarTowerNebula, 
                NPCID.LunarTowerStardust };
        }

        public class Forest
        {
            public static int[] dayTime = { NPCID.GreenSlime, NPCID.BlueSlime, NPCID.PurpleSlime, NPCID.Pinky, NPCID.GoblinScout };
            public static int[] nightTime = { NPCID.Zombie, NPCID.Raven, NPCID.DemonEye, NPCID.DemonEye2, NPCID.CataractEye, 
                NPCID.CataractEye2, NPCID.SleepyEye, NPCID.SleepyEye2, NPCID.DialatedEye, NPCID.DialatedEye2, NPCID.GreenEye, 
                NPCID.GreenEye2, NPCID.PurpleEye, NPCID.PurpleEye2 };
            public static int[] nightTimeHardmode = { NPCID.PossessedArmor, NPCID.WanderingEye, NPCID.Wraith, NPCID.Werewolf };
        }

        public class Snow
        {
            public static int[] dayTime = { NPCID.IceSlime };
            public static int[] nightTime = { NPCID.ZombieEskimo, NPCID.CorruptPenguin, NPCID.CrimsonPenguin };
            public static int[] hardmode = { NPCID.IceElemental, NPCID.Wolf, NPCID.IceGolem};

            public static int[] boss = { NPCID.Deerclops, };
        }

        public class Desert
        {
            public static int[] preHardmode = { NPCID.Vulture, NPCID.Antlion, NPCID.Tumbleweed};
            public static int[] hardmode = { NPCID.Mummy, NPCID.LightMummy, NPCID.DarkMummy, NPCID.BloodMummy, NPCID.SandElemental,
                NPCID.SandShark, NPCID.SandsharkCorrupt, NPCID.SandsharkCrimson, NPCID.SandsharkHallow};
        }

        public class Corruption
        {
            public static int[] preHardmode = { NPCID.EaterofSouls, NPCID.CorruptGoldfish, NPCID.DevourerHead };
            public static int[] hardmode = { NPCID.Corruptor, NPCID.CorruptSlime, NPCID.DarkMummy, NPCID.Slimeling,
                NPCID.Slimer, NPCID.Slimer2, NPCID.SeekerHead, NPCID.CursedHammer, NPCID.Clinger, NPCID.Corruptor,
                NPCID.CorruptSlime, NPCID.BigMimicCorruption, NPCID.DesertGhoulCorruption, NPCID.PigronCorruption, 
                NPCID.SandsharkCorrupt};

            public static int[] boss = { NPCID.EaterofWorldsHead };
        }

        public class Crimson
        {
            public static int[] preHardmode = { NPCID.BloodCrawler, NPCID.BloodCrawlerWall, NPCID.CrimsonGoldfish, 
                NPCID.FaceMonster, NPCID.BigCrimera, NPCID.Crimera, NPCID.LittleCrimera};
            public static int[] hardmode = { NPCID.Herpling, NPCID.Crimslime, NPCID.BloodMummy, NPCID.BloodJelly,
                NPCID.BloodFeeder, NPCID.CrimsonAxe, NPCID.IchorSticker, NPCID.FloatyGross, NPCID.BigMimicCrimson, 
                NPCID.DesertGhoulCrimson, NPCID.PigronCrimson, NPCID.SandsharkCrimson};

            public static int[] boss = { NPCID.BrainofCthulhu };
        }

        public class Jungle
        {
            public static int[] dayTime = { NPCID.JungleSlime, NPCID.JungleBat, NPCID.Piranha, NPCID.Snatcher };
            public static int[] nightTime = { NPCID.Zombie, NPCID.DoctorBones, NPCID.DemonEye, NPCID.DemonEye2, NPCID.CataractEye,
                NPCID.CataractEye2, NPCID.SleepyEye, NPCID.SleepyEye2, NPCID.DialatedEye, NPCID.DialatedEye2, NPCID.GreenEye,
                NPCID.GreenEye2, NPCID.PurpleEye, NPCID.PurpleEye2 };
            public static int[] Hardmode = { NPCID.Derpling, NPCID.GiantTortoise, NPCID.GiantFlyingFox, NPCID.AnglerFish,
                NPCID.Arapaima, NPCID.AngryTrapper};
        }

        public class Ocean
        {
            public static int[] enemies = { NPCID.PinkJellyfish, NPCID.Crab, NPCID.Squid, NPCID.SeaSnail, NPCID.Shark,
                NPCID.SleepingAngler};

            public static int[] boss = { NPCID.DukeFishron };
        }

        public class GlowingMushroom
        {
            public static int[] preHardmode = { NPCID.SporeBat, NPCID.SporeSkeleton};
            public static int[] hardmode = { NPCID.AnomuraFungus, NPCID.FungiBulb, NPCID.MushiLadybug, NPCID.ZombieMushroom,
                NPCID.ZombieMushroomHat, NPCID.FungoFish, NPCID.GiantFungiBulb};
        }

        public class Ice
        {
            public static int[] preHardmode = { NPCID.IceBat, NPCID.SnowFlinx, NPCID.SpikedIceSlime, NPCID.UndeadViking,
                NPCID.CyanBeetle};
            public static int[] hardmode = { NPCID.ArmoredViking, NPCID.IceTortoise, NPCID.IceElemental, NPCID.IcyMerman,
                NPCID.IceMimic, NPCID.PigronCorruption, NPCID.PigronCrimson, NPCID.PigronHallow};
        }

        public class UndergroundDesert
        {
            public static int[] preHardmode = { NPCID.Antlion, NPCID.WalkingAntlion, NPCID.LarvaeAntlion, NPCID.GiantWalkingAntlion,
                NPCID.FlyingAntlion, NPCID.GiantFlyingAntlion, NPCID.SandSlime,  NPCID.TombCrawlerHead};
            public static int[] hardmode = { NPCID.DesertBeast, NPCID.DesertScorpionWalk, NPCID.DesertScorpionWall, 
                NPCID.DesertLamiaLight, NPCID.DesertLamiaDark, NPCID.DuneSplicerHead, NPCID.DesertGhoul, 
                NPCID.DesertGhoulCorruption, NPCID.DesertGhoulCrimson, NPCID.DesertGhoulHallow, NPCID.DesertDjinn};
        }

        public class UndergroundJungle
        {
            public static int[] preHardmode = { NPCID.Hornet, NPCID.BigStinger, NPCID.LittleStinger, NPCID.HornetFatty,
                NPCID.LittleHornetFatty, NPCID.BigHornetFatty, NPCID.HornetHoney, NPCID.LittleHornetFatty, NPCID.BigHornetFatty,
                NPCID.HornetLeafy, NPCID.BigHornetLeafy, NPCID.LittleHornetLeafy, NPCID.HornetSpikey, NPCID.LittleHornetSpikey,
                NPCID.BigHornetSpikey, NPCID.BigHornetStingy, NPCID.LittleHornetStingy, NPCID.HornetStingy, NPCID.ManEater,
                NPCID.JungleBat, NPCID.SpikedJungleSlime, NPCID.Piranha, NPCID.LacBeetle};
            public static int[] hardmode = { NPCID.JungleCreeper, NPCID.JungleCreeperWall, NPCID.Moth,
                NPCID.MossHornet, NPCID.TinyMossHornet, NPCID.LittleMossHornet, NPCID.BigMossHornet, NPCID.GiantMossHornet,
                NPCID.AngryTrapper, NPCID.Arapaima, NPCID.GiantTortoise};

            public static int[] boss = { NPCID.Plantera };
        }

        public class Underworld
        {
            public static int[] preHardmode = { NPCID.Hellbat, NPCID.LavaSlime, NPCID.FireImp, NPCID.Demon, NPCID.VoodooDemon,
                NPCID.BoneSerpentHead};
            public static int[] hardmode = { NPCID.Mimic, NPCID.DemonTaxCollector, NPCID.Lavabat, NPCID.RedDevil};

            public static int[] boss = { NPCID.WallofFlesh };
        }

        public class Hallow
        {
            public static int[] dayTime = { NPCID.Pixie, NPCID.Unicorn, NPCID.RainbowSlime, NPCID.LightMummy, 
                NPCID.SandsharkHallow };
            public static int[] nightTime = { NPCID.Gastropod };
            public static int[] bosses = { NPCID.QueenSlimeBoss, NPCID.HallowBoss};
            public static int[] underground = { NPCID.IlluminantBat, NPCID.IlluminantSlime, NPCID.ChaosElemental, 
                NPCID.EnchantedSword, NPCID.BigMimicHallow, NPCID.DesertGhoulHallow, NPCID.PigronHallow};
        }


        public class MiniBiomes
        {
            public static int[] granite = { NPCID.GraniteGolem, NPCID.GraniteFlyer };
            public static int[] marable = { NPCID.GreekSkeleton };
            public static int[] marableHM = { NPCID.Medusa };
            public static int[] spider = { NPCID.WallCreeper, NPCID.WallCreeperWall };
            public static int[] spiderHM = { NPCID.BlackRecluse, NPCID.BlackRecluseWall };
            public static int[] beehive = { NPCID.Bee, NPCID.BeeSmall, NPCID.Hornet, NPCID.BigStinger, NPCID.LittleStinger, NPCID.HornetFatty,
                NPCID.LittleHornetFatty, NPCID.BigHornetFatty, NPCID.HornetHoney, NPCID.LittleHornetFatty, NPCID.BigHornetFatty,
                NPCID.HornetLeafy, NPCID.BigHornetLeafy, NPCID.LittleHornetLeafy, NPCID.HornetSpikey, NPCID.LittleHornetSpikey,
                NPCID.BigHornetSpikey, NPCID.BigHornetStingy, NPCID.LittleHornetStingy, NPCID.HornetStingy };
            public static int[] beehiveHM = { NPCID.MossHornet, NPCID.TinyMossHornet, NPCID.LittleMossHornet,
                NPCID.BigMossHornet, NPCID.GiantMossHornet };
            public static int[] jungleTemple = { NPCID.Lihzahrd, NPCID.LihzahrdCrawler, NPCID.FlyingSnake };
            public static int[] metorite = { NPCID.MeteorHead };
            public static int[] aether = { NPCID.ShimmerSlime };
        }

        public class Graveyard
        {
            public static int[] preHardmode = { NPCID.MaggotZombie, NPCID.Zombie, NPCID.SmallZombie, NPCID.BigZombie, 
                NPCID.ArmedZombie, NPCID.BaldZombie, NPCID.SmallBaldZombie, NPCID.BigBaldZombie,
                NPCID.PincushionZombie, NPCID.SmallPincushionZombie, NPCID.BigPincushionZombie, NPCID.ArmedZombiePincussion,
                NPCID.SlimedZombie, NPCID.SmallSlimedZombie, NPCID.BigSlimedZombie, NPCID.ArmedZombieSlimed,
                NPCID.SwampZombie, NPCID.SmallSwampZombie, NPCID.BigSwampZombie, NPCID.ArmedZombieSwamp,
                NPCID.TwiggyZombie, NPCID.SmallTwiggyZombie, NPCID.BigTwiggyZombie, NPCID.ArmedZombieTwiggy,
                NPCID.FemaleZombie, NPCID.SmallFemaleZombie, NPCID.BigFemaleZombie, NPCID.ArmedZombieCenx,
                NPCID.TorchZombie, NPCID.ArmedTorchZombie, NPCID.ZombieEskimo, NPCID.ArmedZombieEskimo,
                NPCID.ZombieRaincoat, NPCID.SmallRainZombie, NPCID.BigRainZombie, NPCID.TheGroom, NPCID.TheBride,
                NPCID.DemonEye, NPCID.DemonEye2, NPCID.CataractEye, NPCID.CataractEye2,
                NPCID.SleepyEye, NPCID.SleepyEye2, NPCID.DialatedEye, NPCID.DialatedEye2, NPCID.GreenEye, NPCID.GreenEye2,
                NPCID.PurpleEye, NPCID.PurpleEye2, NPCID.Raven, NPCID.Ghost};

            public static int[] hardmode = { NPCID.ZombieMushroom, NPCID.ZombieMushroomHat, NPCID.HoppinJack };
        }

        public class Space
        {
            public static int[] preHardmode = { NPCID.Harpy };
            public static int[] hardmode = { NPCID.WyvernHead };
        }
    }

    public class ffFunc
    {
        //function for saying something in the chat
        public static void Talk(string message, Color color)
        {
            //check if the player is in singleplayer of multiplayer
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                //send a message to the singe player in the chat
                Main.NewText(message, color);
            }
            else
            {
                //Brodcast a message to everyone in the server
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), color);
            }

            Console.WriteLine(message);
        }

        //function that will convert human time to terraria ticks
        public static int TimeToTick(int secs = 0, int mins = 0, int hours = 0, int days = 0)
        {
            //define the units
            int sec = 60;
            int min = sec * 60;
            int hour = min * 60;
            int day = hour * 24;

            //multiply the units and combine the final time
            return (sec * secs) + (min * mins) + (hour * hours) + (day * days);
        }

        //function that will convert terraria ticks to human time
        public static int TicksToTime(int ticks, bool secs = false, bool mins = false, bool hours = false, bool days = false)
        {
            // Define the units
            const int sec = 60;
            const int min = sec * 60;
            const int hour = min * 60;
            const int day = hour * 24;

            //divide the ticks by unit and return it
            if (days) return ticks / day;
            if (hours) return ticks / hour;
            if (mins) return ticks / min;
            if (secs) return ticks / sec;

            //return this incase no units were provided
            return 0;
        }

        //function for checking if a boss is currently alive
        public static bool IsBossAlive()
        {
            //loop through each npc in the game
            foreach (NPC npc in Main.npc)
            {
                //check if the npc is alive and is a boss
                if (npc.active && npc.boss)
                {
                    return true;
                }
                else
                {
                    //loop through each part of the boss parts
                    foreach (int part in ffVar.BossParts)
                    {
                        //check if the npc is alive and is a part of a boss
                        if (npc.active && npc.type == part)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        //function for checking if someone is in the world, and/or if they are also alive
        public static bool IsPlayerInWorld(bool checkDead = false)
        {
            //loop through each player
            foreach (Player player in Main.player)
            {
                //check if the current player is alive
                if (player.active)
                {
                    //check if it also needs to check if the player is alive
                    if (checkDead && !player.dead)
                        return true;
                    else
                        return true;
                }
            }

            return false;
        }

        //function blueprint for what to run when the cooldown is down
        public delegate void cooldownOperation();

        public static void CooldownSystem(ref int cooldown, ref int cooldownMax, cooldownOperation operation, bool alive = false)
        {
            //check if anyone is alive before counting
            if (IsPlayerInWorld(alive))
            {
                //if the cooldown isnt above the cooldown max, then count up
                if (cooldown <= cooldownMax)
                {
                    cooldown++;
                }
                //otherwise, run the operation and reset the cooldown
                else
                {
                    operation();
                    cooldown = 0;
                }
            }
        }
    }
}