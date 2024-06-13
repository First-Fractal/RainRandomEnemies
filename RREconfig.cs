using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;

namespace RainRandomEnemies
{
    internal class RREconfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static RREconfig Instance;

        [Header("GeneralOptions")]
        [DefaultValue(false)]
        public bool useProgessionMode;

        [DefaultValue(true)]
        public bool eventControlRain;

        [DefaultListValue(true)]
        public bool startAfterEoCBoss;

        [Header("EndEventWithBossOptions")]
        [DefaultValue(true)]
        public bool allowBossSpawnAtEnd;

        [DefaultValue(25)]
        [Range(1, 100)]
        [Slider()]
        public int BossSpawnPercent;


        [Header("RainEnemiesOptions")]
        [DefaultValue(true)]
        public bool allowEndEventWithKills;

        [DefaultValue(true)]
        public bool allowModdedEnemies;

        [DefaultValue(30)]
        public int killRequirement;

        [DefaultValue(false)]
        public bool allowRainBoss;

        [DefaultValue(false)]
        public bool allowRainMiniBosses;

        [DefaultValue(false)]
        public bool allowRainTownNPC;

        [DefaultValue(false)]
        public bool allowRainCritters;


        [Header("EventTimersOptions")]
        [DefaultValue(10)]
        public int eventStartMin;
        [DefaultValue(40)]
        public int eventStartMax;
        
        [DefaultValue(0)]
        public int spawnDelayMin;
        [DefaultValue(5)]
        public int spawnDelayMax;

        [DefaultValue(2)]
        public int durationMin;
        [DefaultValue(8)]
        public int durationMax;


        //update the max values after the config has been changed
        public override void OnChanged()
        {
            RREsystem.cooldownMax = ffFunc.TimeToTick(mins: Main.rand.Next(Instance.eventStartMin,
                Instance.eventStartMax));
            RREsystem.spawnDelayMax = ffFunc.TimeToTick(secs: Main.rand.Next(Instance.spawnDelayMin,
                Instance.spawnDelayMax));
            RREsystem.durationMax = ffFunc.TimeToTick(mins: Main.rand.Next(Instance.durationMin,
                Instance.durationMax));
            RREsystem.killCountMax = Instance.killRequirement;
            base.OnChanged();
        }
    }
}
