using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace RainRandomEnemies
{
    public class RREcontrolEvent
    {
        //what to do when it's time to enable the event
        public static void EnableRREevent()
        {
            //cehck if the event isnt already going on
            if (!RREsystem.RREevent)
            {
                //set the event to be on
                RREsystem.RREevent = true;

                //reset the cooldown and tell the player about the event
                RREsystem.cooldownMax = ffFunc.TimeToTick(mins: Main.rand.Next(RREconfig.Instance.eventStartMin, 
                    RREconfig.Instance.eventStartMax));
                ffFunc.Talk(Language.GetTextValue("Mods.RainRandomEnemies.StatusMessage.Start"), new Color(50, 255, 130));

                //check if the player want the event to control rain
                if (RREconfig.Instance.eventControlRain)
                {
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
        }

        public static void DisableRREevent()
        {
            //cehck if the event is already going on
            if (RREsystem.RREevent)
            {
                //set the event to be on
                RREsystem.RREevent = false;

                //reset the values for tracking the kill count
                RREsystem.NPCTracker.Clear();
                RREsystem.killCount = 0;

                //reset the cooldown and tell the player about the end of the event
                RREsystem.duration = 0;
                RREsystem.durationMax = ffFunc.TimeToTick(mins: Main.rand.Next(RREconfig.Instance.durationMin,
                    RREconfig.Instance.durationMax));
                ffFunc.Talk(Language.GetTextValue("Mods.RainRandomEnemies.StatusMessage.End"), new Color(50, 255, 130));


                //check if the player want the event to control rain
                if (RREconfig.Instance.eventControlRain)
                {
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
                }

                //check if the player wants a boss to spawn at the end of the event
                if (RREconfig.Instance.allowBossSpawnAtEnd)
                {
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

                    //get the value for a random chance
                    int chance = 100 / RREconfig.Instance.BossSpawnPercent;

                    //if the avaiable player list is populated, and landed the random chace, then spawn in a random boss on them
                    if (avaiablePlayers.Count > 0 && Main.rand.Next(0, chance) == 0)
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
        }

        //function to spawn in a random enemy on every player
        public static void SummonRandomEnemy()
        {
            //reset the spawn delay cooldown
            RREsystem.spawnDelayMax = ffFunc.TimeToTick(secs: Main.rand.Next(RREconfig.Instance.spawnDelayMin,
            RREconfig.Instance.spawnDelayMax));

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

                        int enemy = 1;

                        //check weither or not to use the progression mode
                        if (RREconfig.Instance.useProgessionMode)
                        {
                            //get ready to get an enemy pool
                            int[] enemyPool;

                            //the start of the progression
                            //get the day time pool if day time, and night time pool if night time
                            if (Main.dayTime) enemyPool = RREprogression.StartEnemies;
                            else enemyPool = RREprogression.StartNightEnemies;

                            //post evil boss
                            if (NPC.downedBoss2)
                            {
                                //get the day time pool if day time, and night time pool if night time
                                if (Main.dayTime) enemyPool = RREprogression.PostEvilBossEnemies;
                                else enemyPool = RREprogression.PostEvilBossNightEnemies;
                            }
                            //hardmode
                            if (Main.hardMode)
                            {
                                //get the day time pool if day time, and night time pool if night time
                                if (Main.dayTime) enemyPool = RREprogression.HardmodeEnemies;
                                else enemyPool = RREprogression.HardmodeNightEnemies;
                            }
                            //post plantera
                            if (NPC.downedPlantBoss)
                            {
                                //get the day time pool if day time, and night time pool if night time
                                if (Main.dayTime) enemyPool = RREprogression.PostPlantEnemies;
                                else enemyPool = RREprogression.PostPlantNightEnemies;
                            }

                            //get an random enemy from the pool
                            enemy = enemyPool[Main.rand.Next(enemyPool.Length)];
                        } else
                        {
                            bool correctEnemy = false;

                            while (!correctEnemy)
                            {
                                //get a random npc including modded
                                enemy = Main.rand.Next(NPCLoader.NPCCount);

                                ////get a random modded enemy only
                                //int enemy = Main.rand.Next(NPCID.Count, NPCLoader.NPCCount);

                                //spawn in the enemy top left of the world while getting the id from him
                                int npcID = NPC.NewNPC(NPC.GetSource_NaturalSpawn(), 0, 0, enemy);

                                //get the npc that just spawn in
                                NPC npc = Main.npc[npcID];

                                if (RREconfig.Instance.allowRainBoss && npc.boss)
                                {
                                    correctEnemy = true;
                                    RREsystem.NPCTracker.Add(npc);
                                    npc.active = false;
                                    break;
                                }

                                if (RREconfig.Instance.allowRainMiniBosses && ffVar.MiniBosses.Contains(enemy))
                                {
                                    correctEnemy = true;
                                    RREsystem.NPCTracker.Add(npc);
                                    npc.active = false;
                                    break;
                                }

                                if (RREconfig.Instance.allowRainTownNPC && npc.isLikeATownNPC)
                                {
                                    correctEnemy = true;
                                    RREsystem.NPCTracker.Add(npc);
                                    npc.active = false;
                                    break;
                                }

                                if (RREconfig.Instance.allowRainCritters && npc.CountsAsACritter)
                                {
                                    correctEnemy = true;
                                    RREsystem.NPCTracker.Add(npc);
                                    npc.active = false;
                                    break;
                                }

                                //check to see if the enemy isnt a boss, miniboss, critter, or a town npc, or else restart the loop
                                if (!npc.boss && !npc.isLikeATownNPC && !npc.CountsAsACritter && !ffVar.BossParts.Contains(enemy)
                                    && !ffVar.MiniBosses.Contains(enemy))
                                {
                                    correctEnemy = true;
                                    RREsystem.NPCTracker.Add(npc);
                                }
                            }
                        }


                        //spawn in the enemy from the sky
                        NPC.NewNPC(NPC.GetSource_NaturalSpawn(),
                        (int)player.position.X + Main.rand.Next(-250, 250),
                        (int)player.position.Y - Main.rand.Next(600, 900),
                        enemy);
                    }
                }
            }
        }

    }
}
