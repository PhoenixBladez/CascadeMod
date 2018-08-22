using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
namespace SpiritMod
{
    public class MyWorld : ModWorld
    {
	        public static bool Malachite = false;
			
			public override void Initialize()
{
            if (NPC.downedMoonlord)
            {
                Malachite = true;
            }
            else
            {
                Malachite = false;
            }
         
        }

        public override void PostUpdate()
        {
            if (NPC.downedMoonlord)
            {
                if (!Malachite)
				{
					 for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY * 1.73f) * 15E-05); k++)
                    {
                        int EEXX = WorldGen.genRand.Next(1000, Main.maxTilesX - 700);
                        int WHHYY = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 500);
                        if (Main.tile[EEXX, WHHYY] != null)
                        {
                            if (Main.tile[EEXX, WHHYY].active())
                            {
                                {
                                    WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(2, 3), (ushort)mod.TileType("MalachiteTile"));
                                }
                            }
                        }
                    }  Main.NewText("Your world has been graced with Malachite!", 40, 240, 40);
					Main.NewText("The stars grow unstable...", 60, 60, 150);
             
				}
				Malachite = true;
		    }
		}
	}
}