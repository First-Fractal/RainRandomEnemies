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
            //get the message and the local player
            string message;
            RREPlayer player = Main.LocalPlayer.GetModPlayer<RREPlayer>();

            //define all of the values needed for the command 
            bool RREevent;
            string durationHuman;
            string durationMaxHuman;
            string cooldownHuman;
            string cooldownMaxHuman;
            int killCount;
            int killCountMax;

            //if in the game is singeplayer, then get the value directly from the RRE system
            if (Main.netMode == NetmodeID.SinglePlayer) {
                //get if the event is currently going on
                RREevent = RREsystem.RREevent;

                //get the human time for the duration of the event
                durationHuman = ffFunc.TicksToTime(RREsystem.duration, mins: true).ToString();
                durationMaxHuman = ffFunc.TicksToTime(RREsystem.durationMax, mins: true).ToString() + " mins";

                //get the human time for the cooldown of the event
                cooldownHuman = ffFunc.TicksToTime(RREsystem.cooldown, mins: true).ToString();
                cooldownMaxHuman = ffFunc.TicksToTime(RREsystem.cooldownMax, mins: true).ToString() + " mins";

                //get the kill count
                killCount = RREsystem.killCount;
                killCountMax = RREsystem.killCountMax;
            } else
            {
                //get if the event is currently going on
                RREevent = player.RREevent;

                //get the human time for the duration of the event
                durationHuman = ffFunc.TicksToTime(player.duration, mins: true).ToString();
                durationMaxHuman = ffFunc.TicksToTime(player.durationMax, mins: true).ToString() + " mins";

                //get the human time for the cooldown of the event
                cooldownHuman = ffFunc.TicksToTime(player.cooldown, mins: true).ToString();
                cooldownMaxHuman = ffFunc.TicksToTime(player.cooldownMax, mins: true).ToString() + " mins";

                //get the kill count
                killCount = player.killCount;
                killCountMax = player.killCountMax;
            }

            //check if the event is currently going on
            if (RREevent)
            {
                //make the message for when the event is going to end
                message = Language.GetTextValue("Mods.RainRandomEnemies.Command.Duration", durationHuman, durationMaxHuman);

                //if the event is allowed to end with kills, then update the message
                if (RREconfig.Instance.allowEndEventWithKills)
                {
                    message += "\n" + Language.GetTextValue("Mods.RainRandomEnemies.Command.KillCount", killCount, killCountMax);
                }
            } else
            {
                //make the message for when the event is going to start
                message = Language.GetTextValue("Mods.RainRandomEnemies.Command.Cooldown", cooldownHuman, cooldownMaxHuman);
            }

            caller.Reply(message, Color.SeaGreen);
        }
    }
}
