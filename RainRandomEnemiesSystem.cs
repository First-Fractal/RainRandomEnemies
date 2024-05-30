using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace RainRandomEnemies
{
    public class RainRandomEnemiesSystem : ModSystem
    {
        //global values for control the event
        int cooldown = 0;
        int cooldownMax = ffFunc.TimeToTick(secs: Main.rand.Next(10, 20));
        bool RREevent = false;
        
        //what to do when it's time to enable the event
        void enableRREevent()
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

        public override void PostUpdateEverything()
        {
            //do the cooldown while the event is not active
            if (!RREevent) ffFunc.CooldownSystem(ref cooldown, ref cooldownMax, enableRREevent);
            base.PostUpdateEverything();
        }
    }
}
