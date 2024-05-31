using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainRandomEnemies
{
    internal class RainRandomEnemiesProgression
    {
        public static int[] StartEnemies = ffVar.Slimes.normalSlimes.Concat(ffVar.Slimes.biomeSlimes).ToArray()
            .Concat(ffVar.Slimes.festiveSlimes).ToArray().Concat(ffVar.Skeleton.normalSkeletons).ToArray()
            .Concat(ffVar.Skeleton.halloweenSkeletons).ToArray().Concat(ffVar.Worms.normalWorms).ToArray()
            .Concat(ffVar.Bats.normalBats).ToArray().Concat(ffVar.Forest.dayTime).ToArray()
            .Concat(ffVar.Snow.dayTime).ToArray().Concat(ffVar.Desert.preHardmode).ToArray()
            .Concat(ffVar.Corruption.preHardmode).ToArray().Concat(ffVar.Crimson.preHardmode).ToArray()
            .Concat(ffVar.Ocean.enemies).ToArray().Concat(ffVar.GlowingMushroom.preHardmode).ToArray()
            .Concat(ffVar.MiniBiomes.aether).ToArray().Concat(ffVar.Graveyard.preHardmode).ToArray();

        public static int[] StartNightEnemies = StartEnemies.Concat(ffVar.Zombies.normalZombies).ToArray()
            .Concat(ffVar.Zombies.variantZombies).ToArray().Concat(ffVar.Zombies.bloodZombies).ToArray()
            .Concat(ffVar.FloatingEyes.DemonEyes).ToArray().Concat(ffVar.FloatingEyes.DemonEyeHalloween).ToArray()
            .Concat(ffVar.FloatingEyes.BossesMinions).ToArray().Concat(ffVar.Forest.nightTime).ToArray()
            .Concat(ffVar.Snow.nightTime).ToArray();

        public static int[] PostEvilBossEnemies = StartEnemies.Concat(ffVar.Hornets.normalHornets).ToArray()
            .Concat(ffVar.Slimes.specialSlimes).ToArray().Concat(ffVar.Skeleton.speicalSkeletons).ToArray()
            .Concat(ffVar.Skeleton.dungeonSkeletons).ToArray().Concat(ffVar.Worms.minionsWorms).ToArray()
            .Concat(ffVar.GoblinArmy.preHardmode).ToArray().Concat(ffVar.OOA.Tier1).ToArray()
            .Concat(ffVar.Jungle.dayTime).ToArray().Concat(ffVar.Ice.preHardmode).ToArray()
            .Concat(ffVar.UndergroundDesert.preHardmode).ToArray().Concat(ffVar.UndergroundJungle.preHardmode).ToArray()
            .Concat(ffVar.Underworld.preHardmode).ToArray().Concat(ffVar.MiniBiomes.granite).ToArray()
            .Concat(ffVar.MiniBiomes.marable).ToArray().Concat(ffVar.MiniBiomes.spider).ToArray()
            .Concat(ffVar.MiniBiomes.beehive).ToArray().Concat(ffVar.MiniBiomes.metorite)
            .ToArray().Concat(ffVar.Space.preHardmode).ToArray();

        public static int[] PostEvilBossNightEnemies = PostEvilBossEnemies.Concat(ffVar.Zombies.bloodZombies).ToArray()
            .Concat(ffVar.Zombies.specialZombies).ToArray().Concat(ffVar.FloatingEyes.BloodEyes).ToArray()
            .Concat(ffVar.BloodMoons.preHardmode).ToArray().Concat(ffVar.BloodMoons.corruptionEnemies).ToArray()
            .Concat(ffVar.BloodMoons.crimsonEnemies).ToArray().Concat(ffVar.BloodMoons.preHardmodeFishing).ToArray()
            .Concat(ffVar.Jungle.nightTime).ToArray();




        public static int[] HardmodeEnemies = PostEvilBossEnemies.Concat(ffVar.Slimes.hardmodeSlimes).ToArray()
            .Concat(ffVar.Slimes.bossMinionSlimes).ToArray().Concat(ffVar.Hornets.mossHornets).ToArray()
            .Concat(ffVar.Skeleton.hardmodeSekeltons).ToArray().Concat(ffVar.Worms.hardmodeWorms).ToArray()
            .Concat(ffVar.Worms.speicalWorms).ToArray().Concat(ffVar.Bats.hardmodeBats).ToArray()
            .Concat(ffVar.GoblinArmy.hardmode).ToArray().Concat(ffVar.OOA.Tier2).ToArray()
            .Concat(ffVar.FrostLegion).ToArray().Concat(ffVar.SolarEclipse.always).ToArray()
            .Concat(ffVar.PirateInvasion.normalEnemies).ToArray().Concat(ffVar.PirateInvasion.miniBoss).ToArray()
            .Concat(ffVar.Desert.hardmode).ToArray().Concat(ffVar.Corruption.hardmode).ToArray()
            .Concat(ffVar.Crimson.hardmode).ToArray().Concat(ffVar.Jungle.Hardmode).ToArray()
            .Concat(ffVar.GlowingMushroom.hardmode).ToArray().Concat(ffVar.Ice.hardmode).ToArray()
            .Concat(ffVar.UndergroundDesert.hardmode).ToArray().Concat(ffVar.UndergroundJungle.hardmode).ToArray()
            .Concat(ffVar.Underworld.hardmode).ToArray().Concat(ffVar.Hallow.dayTime).ToArray()
            .Concat(ffVar.Hallow.underground).ToArray().Concat(ffVar.MiniBiomes.marableHM).ToArray()
            .Concat(ffVar.MiniBiomes.spiderHM).ToArray().Concat(ffVar.MiniBiomes.beehiveHM).ToArray()
            .Concat(ffVar.Graveyard.hardmode).ToArray().Concat(ffVar.Space.hardmode).ToArray();

        public static int[] HardmodeNightEnemies = PostEvilBossNightEnemies.ToArray().Concat(ffVar.Zombies.hardmodeZombies)
            .ToArray().Concat(ffVar.FloatingEyes.HardDemonEyes).ToArray().Concat(ffVar.BloodMoons.Hardmode).ToArray()
            .ToArray().Concat(ffVar.BloodMoons.HardmodeFishing).ToArray().Concat(ffVar.Forest.nightTimeHardmode).ToArray()
            .Concat(ffVar.Snow.hardmode).ToArray().Concat(ffVar.Hallow.nightTime).ToArray();

        public static int[] PostPlantEnemies = HardmodeEnemies.ToArray().Concat(ffVar.Skeleton.ppDungeonSkeletons).ToArray()
            .Concat(ffVar.Worms.pillarsWorms).ToArray().Concat(ffVar.Bats.speicalBats).ToArray().Concat(ffVar.OOA.Tier3)
            .ToArray().Concat(ffVar.SolarEclipse.postPlantera).ToArray().Concat(ffVar.MartianMadness.normalEnemies).ToArray()
            .Concat(ffVar.LunarEvents.solarEnemies).ToArray().Concat(ffVar.LunarEvents.vortexEnemies).ToArray()
            .Concat(ffVar.LunarEvents.nebulaEnemies).ToArray().Concat(ffVar.LunarEvents.stardustEnemies).ToArray()
            .Concat(ffVar.MiniBiomes.jungleTemple).ToArray();

        public static int[] PostPlantNightEnemies = HardmodeNightEnemies.ToArray()
            .Concat(ffVar.PumpkinMoon.normalEnemies).ToArray().Concat(ffVar.FrostMoon.normalEnemies).ToArray();




        public static int[] AllEnemies = PostPlantEnemies.Concat(PostPlantNightEnemies).ToArray();
    }
}
