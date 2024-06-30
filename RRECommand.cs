using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RainRandomEnemies
{
    internal class RRECommand : ModCommand
    {
        //make the command run on all sides, since it's client side
        public override CommandType Type => CommandType.Chat;
        
        //the command to execute it
        public override string Command => "RRE";

        //the description of the command
        public override string Description => Language.GetTextValue("Mods.RainRandomEnemies.Command.Desc");

        //what the command does when it's run
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            string message;

            RREPlayer player = Main.LocalPlayer.GetModPlayer<RREPlayer>();

            bool RREevent;

            string durationHuman;
            string durationMaxHuman;

            string cooldownHuman;
            string cooldownMaxHuman;

            int killCount;
            int killCountMax;

            if (Main.netMode == NetmodeID.SinglePlayer) {
                
                RREevent = RREsystem.RREevent;

                //get the human time for the duration of the event
                durationHuman = ffFunc.TicksToTime(RREsystem.duration, mins: true).ToString();
                durationMaxHuman = ffFunc.TicksToTime(RREsystem.durationMax, mins: true).ToString() + " mins";

                //get the human time for the cooldown of the event
                cooldownHuman = ffFunc.TicksToTime(RREsystem.cooldown, mins: true).ToString();
                cooldownMaxHuman = ffFunc.TicksToTime(RREsystem.cooldownMax, mins: true).ToString() + " mins";

                killCount = RREsystem.killCount;
                killCountMax = RREsystem.killCountMax;
            } else
            {
                RREevent = player.RREevent;

                //get the human time for the duration of the event
                durationHuman = ffFunc.TicksToTime(player.duration, mins: true).ToString();
                durationMaxHuman = ffFunc.TicksToTime(player.durationMax, mins: true).ToString() + " mins";

                //get the human time for the cooldown of the event
                cooldownHuman = ffFunc.TicksToTime(player.cooldown, mins: true).ToString();
                cooldownMaxHuman = ffFunc.TicksToTime(player.cooldownMax, mins: true).ToString() + " mins";

                killCount = player.killCount;
                killCountMax = player.killCountMax;
            }

            if (RREevent)
            {
                //make the message for when the event is going to end
                message = Language.GetTextValue("Mods.RainRandomEnemies.Command.Duration", durationHuman, durationMaxHuman, killCount, killCountMax);
            } else
            {
                //make the message for when the event is going to start
                message = Language.GetTextValue("Mods.RainRandomEnemies.Command.Cooldown", cooldownHuman, cooldownMaxHuman);
            }

            caller.Reply(message, Color.SeaGreen);
        }
    }
}
