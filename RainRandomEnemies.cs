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
	public class RainRandomEnemies : Mod
	{

	}

	public class RainRandomEnemiesSystem : ModSystem
	{
        int cooldown = 0;
        int cooldownMax = ffFunc.TimeToTick(5);

        void test()
        {
            ffFunc.Talk("I've just came online", Color.White);
        }

        public override void PostUpdateEverything()
        {
            ffFunc.CooldownSystem(ref cooldown, ref cooldownMax, test);
            base.PostUpdateEverything();
        }
    }
}
