using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using System.Collections.Generic;

namespace RainRandomEnemies
{
    public class RainRandomEnemiesSystem : ModSystem
    {
        //global values for controling the event
        int cooldown = 0;
        int cooldownMax = ffFunc.TimeToTick(secs: Main.rand.Next(10, 20));
        public static bool RREevent = false;
        int spawnDelay = 0;
        int spawnDelayMax = ffFunc.TimeToTick(1);
        int duration = 0;
        int durationMax = ffFunc.TimeToTick(mins: Main.rand.Next(3, 8));
        public static int killCount = 0;
        public static int killCountMax = 10;
        public static List<NPC> NPCTracker = new List<NPC>();


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

        void DisableRREevent()
        {
            //cehck if the event is already going on
            if (RREevent)
            {
                //set the event to be on
                RREevent = false;

                //reset the values for tracking the kill count
                NPCTracker.Clear();
                killCount = 0;

                //reset the cooldown and tell the player about the end of the event
                duration = 0;
                durationMax = ffFunc.TimeToTick(mins: Main.rand.Next(3, 8));
                ffFunc.Talk(Language.GetTextValue("Mods.RainRandomEnemies.StatusMessage.End"), new Color(50, 255, 130));

                //set the world to not be raining
                Main.raining = false;
                Main.rainTime = 0;
                Main.maxRaining = Main.cloudAlpha = 0f;

                //sync the rain with the world
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                    Main.SyncRain();
                }

                //variable for storing all of the avaiable players
                List<Player> avaiablePlayers = [];

                //loop through each player
                for (int i = 0; i < Main.player.Length; i++)
                {
                    //get the current player info
                    Player current = Main.player[i];

                    //if the current player active and not dead, then add it to the list
                    if (current.active && !current.dead) avaiablePlayers.Add(current);
                }

                //if the avaiable player list is populated, and landed a 25% chace, then spawn in a random boss on them
                if (avaiablePlayers.Count > 0 && Main.rand.Next(0, 4) == 0) 
                {
                    //get a random player in the list
                    Player unluckyPlayer = avaiablePlayers[Main.rand.Next(avaiablePlayers.Count)];

                    //set the variabe for checking if the current npc is a boss
                    bool correctBoss = false;

                    //start the loop for rerolling until the current npc is a boss
                    while (!correctBoss)
                    {
                        //get a random npc including modded
                        int enemy = Main.rand.Next(NPCLoader.NPCCount);

                        //spawn in the enemy from the sky while getting the id from him
                        int npcID = NPC.NewNPC(NPC.GetSource_NaturalSpawn(),
                        (int)unluckyPlayer.position.X + Main.rand.Next(-250, 250),
                        (int)unluckyPlayer.position.Y - Main.rand.Next(600, 900),
                        enemy);

                        //get the npc that just spawn in
                        NPC npc = Main.npc[npcID];

                        //check to see if the enemy is a boss and warn the player about it
                        if (npc.boss)
                        {
                            correctBoss = true;
                            ffFunc.Talk(Language.GetTextValue("Mods.RainRandomEnemies.StatusMessage.Spawn", 
                                npc.FullName, unluckyPlayer.name), Color.Orange);
                        }
                        //despawn the npc since it isnt a boss
                        else npc.active = false;
                    }
                }
            }
        }

        //function to spawn in a random enemy on every player
        void SummonRandomEnemy()
        {
            //go through every player
            for (int i = 0; i < Main.player.Length; i++)
            {
                //check if the player is active and not dead
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    //check if the player is on the surface
                    if (!player.ZoneDirtLayerHeight && !player.ZoneRockLayerHeight && !player.ZoneUnderworldHeight)
                    {
                        //get ready to get an enemy pool
                        //int[] enemyPool = null;


                        ////the start of the progression
                        ////get the day time pool if day time, and night time pool if night time
                        //if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.StartEnemies;
                        //else enemyPool = RainRandomEnemiesProgression.StartNightEnemies;

                        ////post evil boss
                        //if (NPC.downedBoss2)
                        //{
                        //    //get the day time pool if day time, and night time pool if night time
                        //    if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.PostEvilBossEnemies;
                        //    else enemyPool = RainRandomEnemiesProgression.PostEvilBossNightEnemies;
                        //}
                        ////hardmode
                        //if (Main.hardMode)
                        //{
                        //    //get the day time pool if day time, and night time pool if night time
                        //    if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.HardmodeEnemies;
                        //    else enemyPool = RainRandomEnemiesProgression.HardmodeNightEnemies;
                        //}
                        ////post plantera
                        //if (NPC.downedPlantBoss)
                        //{
                        //    //get the day time pool if day time, and night time pool if night time
                        //    if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.PostPlantEnemies;
                        //    else enemyPool = RainRandomEnemiesProgression.PostPlantNightEnemies;
                        //}

                        ////get an random enemy from the pool
                        //int enemy = enemyPool[Main.rand.Next(enemyPool.Length)];

                        bool correctEnemy = false;

                        while (!correctEnemy)
                        {
                            //get a random npc including modded
                            int enemy = Main.rand.Next(NPCLoader.NPCCount);

                            ////get a random modded enemy only
                            //int enemy = Main.rand.Next(NPCID.Count, NPCLoader.NPCCount);

                            //spawn in the enemy from the sky while getting the id from him
                            int npcID = NPC.NewNPC(NPC.GetSource_NaturalSpawn(),
                            (int)player.position.X + Main.rand.Next(-250, 250),
                            (int)player.position.Y - Main.rand.Next(600, 900),
                            enemy);

                            //get the npc that just spawn in
                            NPC npc = Main.npc[npcID];

                            //check to see if the enemy isnt a boss, miniboss, critter, or a town npc, or else restart the loop
                            if (!npc.boss && !npc.isLikeATownNPC && !npc.CountsAsACritter && !ffVar.BossParts.Contains(enemy)
                                && !ffVar.MiniBosses.Contains(enemy))
                            {
                                correctEnemy = true;
                                NPCTracker.Add(npc);
                            }
                            else npc.active = false;
                        }
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
                    //spawn in a random enemy once it's off cooldown
                    ffFunc.CooldownSystem(ref spawnDelay, ref spawnDelayMax, SummonRandomEnemy);

                    //end the event once the time's up
                    ffFunc.CooldownSystem(ref duration, ref durationMax, DisableRREevent);

                    //end the event once it's above the kill count
                    if (killCount > killCountMax) DisableRREevent();
                }
            }
            base.PostUpdateEverything();
        }
    }
}
