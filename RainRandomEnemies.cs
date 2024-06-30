using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace RainRandomEnemies
{
	public class RainRandomEnemies : Mod
    {

        //function for handling packets reccived
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            //get the local player
            RREPlayer RREP = Main.CurrentPlayer.GetModPlayer<RREPlayer>();

            //define all of the reccived values to the player
            RREP.cooldown = reader.ReadInt32();
            RREP.cooldownMax = reader.ReadInt32();
            RREP.RREevent = reader.ReadBoolean();
            RREP.duration = reader.ReadInt32();
            RREP.durationMax = reader.ReadInt32();
            RREP.killCount = reader.ReadInt32();
            RREP.killCountMax = reader.ReadInt32();

            base.HandlePacket(reader, whoAmI);
        }
    }

    //make the player store all of these values for multiplayer
    public class RREPlayer: ModPlayer
    {
        public int cooldown = 0;
        public int cooldownMax = ffFunc.TimeToTick(mins: Main.rand.Next(RREconfig.Instance.eventStartMin,
            RREconfig.Instance.eventStartMax));

        public bool RREevent = false;

        public int duration = 0;
        public int durationMax = ffFunc.TimeToTick(mins: Main.rand.Next(RREconfig.Instance.durationMin,
            RREconfig.Instance.durationMax));

        public int killCount = 0;
        public int killCountMax = 10;
    }
}
