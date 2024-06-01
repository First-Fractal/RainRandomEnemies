using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

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

        void DisableRREevent()
        {
            //cehck if the event is already going on
            if (RREevent)
            {
                //set the event to be on
                RREevent = false;

                //reset the cooldown and tell the player about the end of the event
                durationMax = ffFunc.TimeToTick(secs: Main.rand.Next(3, 8));
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
                    //get ready to get an enemy pool
                    int[] enemyPool = null;

                    //the start of the progression
                    //get the day time pool if day time, and night time pool if night time
                    if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.StartEnemies;
                    else enemyPool = RainRandomEnemiesProgression.StartNightEnemies;

                    //post evil boss
                    if (NPC.downedBoss2)
                    {
                        //get the day time pool if day time, and night time pool if night time
                        if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.PostEvilBossEnemies;
                        else enemyPool = RainRandomEnemiesProgression.PostEvilBossNightEnemies;
                    } 
                    //hardmode
                    if (Main.hardMode)
                    {
                        //get the day time pool if day time, and night time pool if night time
                        if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.HardmodeEnemies;
                        else enemyPool = RainRandomEnemiesProgression.HardmodeNightEnemies;
                    } 
                    //post plantera
                    if (NPC.downedPlantBoss)
                    {
                        //get the day time pool if day time, and night time pool if night time
                        if (Main.dayTime) enemyPool = RainRandomEnemiesProgression.PostPlantEnemies;
                        else enemyPool = RainRandomEnemiesProgression.PostPlantNightEnemies;
                    }

                    //get an random enemy from the pool
                    int enemy = enemyPool[Main.rand.Next(enemyPool.Length - 1)];

                    //spaw the enemy above the player
                    int npcID = NPC.NewNPC(NPC.GetSource_NaturalSpawn(),
                    (int)player.position.X + Main.rand.Next(-250, 250),
                    (int)player.position.Y - Main.rand.Next(700, 1200),
                    enemy);
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
                    ffFunc.CooldownSystem(ref duration, ref durationMax, DisableRREevent);
                }
            }
            base.PostUpdateEverything();
        }
    }
}
