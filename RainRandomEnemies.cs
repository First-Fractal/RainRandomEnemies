using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;


namespace RainRandomEnemies
{
	public class RainRandomEnemies : Mod
    {
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            RREPlayer RREP = Main.CurrentPlayer.GetModPlayer<RREPlayer>();

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
