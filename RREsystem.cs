using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace RainRandomEnemies
{
    public class RREsystem : ModSystem
    {
        //global values for controling the event
        public static int cooldown = 0;
        public static int cooldownMax = ffFunc.TimeToTick(mins: Main.rand.Next(RREconfig.Instance.eventStartMin, 
            RREconfig.Instance.eventStartMax));
        public static bool RREevent = false;
        public static int spawnDelay = 0;
        public static int spawnDelayMax = ffFunc.TimeToTick(secs: Main.rand.Next(RREconfig.Instance.spawnDelayMin,
            RREconfig.Instance.spawnDelayMax));
        public static int duration = 0;
        public static int durationMax = ffFunc.TimeToTick(mins: Main.rand.Next(RREconfig.Instance.durationMin,
            RREconfig.Instance.durationMax));
        public static int killCount = 0;
        public static int killCountMax = 10;
        public static List<NPC> NPCTracker = new List<NPC>();

        public override void PostUpdateEverything()
        {
            //update the kill count max
            killCountMax = RREconfig.Instance.killRequirement;

            //make it only active on non multiplayer clients
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                //do the cooldown while the event is not active
                if (!RREevent)
                {
                    ffFunc.CooldownSystem(ref cooldown, ref cooldownMax, RREcontrolEvent.EnableRREevent);
                }
                else
                {
                    //spawn in a random enemy once it's off cooldown
                    ffFunc.CooldownSystem(ref spawnDelay, ref spawnDelayMax, RREcontrolEvent.SummonRandomEnemy);

                    //end the event once the time's up
                    ffFunc.CooldownSystem(ref duration, ref durationMax, RREcontrolEvent.DisableRREevent);

                    //end the event once it's above the kill count and it's allowed
                    if (RREconfig.Instance.allowEndEventWithKills && killCount > killCountMax) RREcontrolEvent.DisableRREevent();
                }
            }
            base.PostUpdateEverything();
        }
    }
}
