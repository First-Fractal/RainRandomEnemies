using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RainRandomEnemies
{
    internal class RainRandomEnemiesGlobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            //if the enemy is from the event, then increase the kill count and remove it from the list
            if (RainRandomEnemiesSystem.RREevent && RainRandomEnemiesSystem.NPCTracker.Contains(npc))
            {
                RainRandomEnemiesSystem.killCount++;
                RainRandomEnemiesSystem.NPCTracker.Remove(npc);
            }
            base.OnKill(npc);
        }
    }
}
