using Terraria;
using Terraria.ModLoader;

namespace RainRandomEnemies
{
    public class RREglobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            //if the enemy is from the event and it's allowed to end the event with kills
            if (RREconfig.Instance.allowEndEventWithKills && RREsystem.RREevent && RREsystem.NPCTracker.Contains(npc))
            {
                //increase the kill count and remove it from the list
                RREsystem.killCount++;
                RREsystem.NPCTracker.Remove(npc);
            }
            base.OnKill(npc);
        }
    }
}
