using Terraria;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Linq;

//this is my own libary that I use to store snipits. I don't want it to be it's own mod, so I'll use copy and paste this file when needed.
namespace RainRandomEnemies
{
    public class ffVar
    {
        //list of all the boss parts
        public static int[] BossParts = { NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.Creeper, 
            NPCID.SkeletronHand, NPCID.WallofFleshEye, NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PlanterasHook, NPCID.PlanterasTentacle, 
            NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistBossClone, NPCID.MoonLordCore, 
            NPCID.MoonLordHand, NPCID.MoonLordHead, NPCID.MoonLordFreeEye, NPCID.MoonLordLeechBlob };

        public class Slimes
        {
            //list of all  the normal slimes
            public static int[] normalSlimes = { NPCID.GreenSlime, NPCID.BlueSlime, NPCID.RedSlime, 
                NPCID.PurpleSlime, NPCID.YellowSlime, NPCID.BlackSlime };

            //list of all slimes that can only be found in certain biomes
            public static int[] biomeSlimes = { NPCID.IceSlime, NPCID.SpikedIceSlime, NPCID.SandSlime, 
                NPCID.JungleSlime, NPCID.JungleSlime, NPCID.MotherSlime, NPCID.BabySlime, NPCID.LavaSlime, NPCID.ShimmerSlime};

            //list of all slimes that can only be found in hardmode
            public static int[] hardmodeSlimes = { NPCID.ToxicSludge, NPCID.CorruptSlime, NPCID.Slimeling, 
                NPCID.Slimer, NPCID.Slimer2,  NPCID.Crimslime, NPCID.Gastropod, NPCID.IlluminantSlime};

            //list of all slimes that are special/rare
            public static int[] specialSlimes = { NPCID.Pinky, NPCID.GoldenSlime, NPCID.UmbrellaSlime, 
                NPCID.WindyBalloon, NPCID.DungeonSlime};

            //list of all slimes that are a part of a hoilday
            public static int[] festiveSlimes = { NPCID.SlimeMasked, NPCID.SlimeRibbonGreen, NPCID.SlimeRibbonRed, 
                NPCID.SlimeRibbonYellow, NPCID.SlimeRibbonWhite };

            //list of all slimes that are bosses
            public static int[] bossSlime = { NPCID.KingSlime, NPCID.QueenSlimeBoss };

            //list of all slimes that are boss minions
            public static int[] bossMinionSlimes = { NPCID.SlimeSpiked, NPCID.QueenSlimeMinionBlue, NPCID.QueenSlimeMinionPink, 
                NPCID.QueenSlimeMinionPurple };

            //list of all slimes in vanilla
            public static int[] allSlimes = normalSlimes.Concat(biomeSlimes).ToArray().Concat(hardmodeSlimes).ToArray()
                .Concat(specialSlimes).ToArray().Concat(festiveSlimes).ToArray()
                .Concat(bossSlime).ToArray().Concat(bossMinionSlimes).ToArray();
        }

        public class Zombies
        {
            //list of all the different types of zombies in vanilla
            public static int[] normalZombies = {NPCID.Zombie, NPCID.SmallZombie, NPCID.BigZombie, NPCID.ArmedZombie,
            NPCID.BaldZombie, NPCID.SmallBaldZombie, NPCID.BigBaldZombie,
            NPCID.PincushionZombie, NPCID.SmallPincushionZombie, NPCID.BigPincushionZombie, NPCID.ArmedZombiePincussion,
            NPCID.SlimedZombie, NPCID.SmallSlimedZombie, NPCID.BigSlimedZombie, NPCID.ArmedZombieSlimed,
            NPCID.SwampZombie, NPCID.SmallSwampZombie, NPCID.BigSwampZombie, NPCID.ArmedZombieSwamp,
            NPCID.TwiggyZombie, NPCID.SmallTwiggyZombie, NPCID.BigTwiggyZombie, NPCID.ArmedZombieTwiggy,
            NPCID.FemaleZombie, NPCID.SmallFemaleZombie, NPCID.BigFemaleZombie, NPCID.ArmedZombieCenx,
            NPCID.TorchZombie, NPCID.ArmedTorchZombie};

            //list of all the variant zombies in vanilla
            public static int[] variantZombies = {NPCID.ZombieDoctor, NPCID.ZombieSuperman, NPCID.ZombiePixie,
            NPCID.ZombieXmas, NPCID.ZombieSweater,
            NPCID.ZombieEskimo, NPCID.ArmedZombieEskimo,
            NPCID.ZombieRaincoat, NPCID.SmallRainZombie, NPCID.BigRainZombie,
            NPCID.MaggotZombie};

            //list of all the blood moon zombies in vanilla
            public static int[] bloodZombies = { NPCID.BloodZombie, NPCID.TheBride, NPCID.TheGroom };

            //list of all the special zombies in vanilla
            public static int[] specialZombies = { NPCID.DoctorBones, NPCID.ZombieMerman };

            //list of all the hardmode zombies in vanilla
            public static int[] hardmodeZombies = { NPCID.ZombieMushroom, NPCID.ZombieMushroomHat, NPCID.Eyezor };

            //list of all zombies in vanilla
            public static int[] allZombies = normalZombies.Concat(variantZombies).ToArray()
                .Concat(bloodZombies).ToArray()
                .Concat(specialZombies).ToArray()
                .Concat(hardmodeZombies).ToArray();
        }
    }

    public class ffFunc
    {
        //function for saying something in the chat
        public static void Talk(string message, Color color)
        {
            //check if the player is in singleplayer of multiplayer
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                //send a message to the singe player in the chat
                Main.NewText(message, color);
            }
            else
            {
                //Brodcast a message to everyone in the server
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), color);
            }
        }

        //function that will convert human time to terraria ticks
        public static int TimeToTick(int secs = 0, int mins = 0, int hours = 0, int days = 0)
        {
            //define the units
            int sec = 60;
            int min = sec * 60;
            int hour = min * 60;
            int day = hours * 24;

            //multiply the units and combine the final time
            return (sec * secs) + (min * mins) + (hour * hours) + (day * days);
        }

        //function for checking if a boss is currently alive
        public static bool IsBossAlive()
        {
            //loop through each npc in the game
            foreach (NPC npc in Main.npc)
            {
                //check if the npc is alive and is a boss
                if (npc.active && npc.boss)
                {
                    return true;
                }
                else
                {
                    //loop through each part of the boss parts
                    foreach (int part in ffVar.BossParts)
                    {
                        //check if the npc is alive and is a part of a boss
                        if (npc.active && npc.type == part)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        //function for checking if someone is in the world, and/or if they are also alive
        public static bool IsPlayerInWorld(bool checkDead = false)
        {
            //loop through each player
            foreach (Player player in Main.player)
            {
                //check if the current player is alive
                if (player.active)
                {
                    //check if it also needs to check if the player is alive
                    if (checkDead && !player.dead)
                        return true;
                    else
                        return true;
                }
            }

            return false;
        }

        //function blueprint for what to run when the cooldown is down
        public delegate void cooldownOperation();

        public static void CooldownSystem(ref int cooldown, ref int cooldownMax, cooldownOperation operation, bool alive = false)
        {
            //check if anyone is alive before counting
            if (IsPlayerInWorld(alive))
            {
                //if the cooldown isnt above the cooldown max, then count up
                if (cooldown < cooldownMax)
                {
                    cooldown++;
                }
                //otherwise, run the operation and reset the cooldown
                else
                {
                    operation();
                    cooldown = 0;
                }
            }
        }
    }
}