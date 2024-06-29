using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
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
            // the message string
            string message = "";

            //check if the event is going on
            if (RREsystem.RREevent)
            {
                //get the human time for the duration of the event
                string durationHuman = ffFunc.TicksToTime(RREsystem.duration, mins: true).ToString();
                string durationMaxHuman = ffFunc.TicksToTime(RREsystem.durationMax, mins: true).ToString() + " mins";

                //make the message for when the event is going to end
                message = Language.GetTextValue("Mods.RainRandomEnemies.Command.Duration", durationHuman, durationMaxHuman, RREsystem.killCount, RREsystem.killCountMax);
            }
            else
            {
                //get the human time for the cooldown of the event
                string cooldownHuman = ffFunc.TicksToTime(RREsystem.cooldown, mins: true).ToString();
                string cooldownMaxHuman = ffFunc.TicksToTime(RREsystem.cooldownMax, mins: true).ToString() + " mins";

                //make the message for when the event is going to start
                message = Language.GetTextValue("Mods.RainRandomEnemies.Command.Cooldown", cooldownHuman, cooldownMaxHuman);
            }

            caller.Reply(message, Color.SeaGreen);
        }
    }
}
