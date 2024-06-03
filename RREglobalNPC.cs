using Terraria;
using Terraria.ModLoader;

namespace RainRandomEnemies
{
    public class RREglobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            //if the enemy is from the event, then increase the kill count and remove it from the list
            if (RREsystem.RREevent && RREsystem.NPCTracker.Contains(npc))
            {
                RREsystem.killCount++;
                RREsystem.NPCTracker.Remove(npc);
            }
            base.OnKill(npc);
        }
    }
}
