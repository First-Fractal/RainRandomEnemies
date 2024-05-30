using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RainRandomEnemies
{
    public class RainRandomEnemiesSystem : ModSystem
    {
        //global values for controling the event
        int cooldown = 0;
        int cooldownMax = ffFunc.TimeToTick(secs: Main.rand.Next(10, 20));
        bool RREevent = false;
        int spawnDelay = 0;
        int spawnDelayMax = ffFunc.TimeToTick(1);
        int duration = 0;
        int durationMax = ffFunc.TimeToTick(secs: Main.rand.Next(3, 8));

        //what to do when it's time to enable the event
        void EnableRREevent()
        {
            //cehck if the event isnt already going on
            if (!RREevent)
            {
                //set the event to be on
                RREevent = true;

                //reset the cooldown and tell the player about the event
                cooldownMax = ffFunc.TimeToTick(secs: Main.rand.Next(10, 20));
                ffFunc.Talk(Language.GetTextValue("Mods.RainRandomEnemies.StatusMessage.Start"), new Color(50, 255, 130));

                //set the world to be raining
                Main.raining = true;
                Main.rainTime = ffFunc.TimeToTick(days: 31);
                Main.maxRaining = Main.cloudAlpha = 0.9f;

                //sync the rain with the world
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                    Main.SyncRain();
                }
            }
        }

        //function to spawn in a random enemy on every player
        void SummonRandomEnemy()
        {
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    int npcID = NPC.NewNPC(NPC.GetSource_NaturalSpawn(),
                    (int)player.position.X + Main.rand.Next(-50, 50),
                    (int)player.position.Y + Main.rand.Next(-50, 50),
                    Main.rand.Next(-65, NPCID.Count));

                    NPC npc = Main.npc[npcID];

                    if (npc.friendly || npc.boss || npc.townNPC)
                    {
                        foreach (int boss in ffVar.BossParts)
                        {
                            if (npc.type == boss) {
                                ffFunc.Talk("The " + npc.FullName + " isnt the type of person to spawn in during this event", Color.Orange);
                                npc.active = false;

                            }
                        }

                        foreach (int boss in ffVar.MiniBosses)
                        {
                            if (npc.type == boss)
                            {
                                ffFunc.Talk("The " + npc.FullName + " isnt the type of person to spawn in during this event", Color.Orange);
                                npc.active = false;
                            }
                        }

                        ffFunc.Talk("The " + npc.FullName + " isnt the type of person to spawn in during this event", Color.Orange);
                        npc.active = false;

                    }
                }
            }
        }

        public override void PostUpdateEverything()
        {
            //make it only active on non multiplayer clients
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                //do the cooldown while the event is not active
                if (!RREevent)
                {
                    ffFunc.CooldownSystem(ref cooldown, ref cooldownMax, EnableRREevent);
                }
                else
                {
                    ffFunc.CooldownSystem(ref spawnDelay, ref spawnDelayMax, SummonRandomEnemy);
                }
            }
            base.PostUpdateEverything();
        }
    }
}
