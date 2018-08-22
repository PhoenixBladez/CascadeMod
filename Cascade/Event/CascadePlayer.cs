using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Cascade;
namespace Cascade.Event
{
	public class CascadePlayer : ModPlayer
	{
		float randX;
		float randY;
		public static int EnemyKills2 = 0;
		public override void PostUpdate()
		{
			
			if (!CascadeWorld.TheCascade)
			{
				CascadeWorld.CascadePoints2 = 0;
				EnemyKills2 = 0;
			}
			if (CascadeWorld.TheCascade)
			{
				if (Main.rand.Next(28) == 0)
				{
				randX = (Main.screenPosition.X + Main.rand.Next(0, 1200));
				randY = (Main.screenPosition.Y + Main.rand.Next(0, 1200));
				int p = Projectile.NewProjectile(randX, randY, 0f, 0f, mod.ProjectileType("Visual"), 0, 5f, Main.myPlayer, 0f, 0f);
				}
			}
			CascadeWorld.CascadePoints = CascadeWorld.CascadePoints2;
		}
	
		public override void UpdateBiomeVisuals()
        {
           bool useShreksWand = false;
			if(CascadeWorld.TheCascade)
			{
				useShreksWand = true;
			}
			else
			{
				useShreksWand = false;
			}
            player.ManageSpecialBiomeVisuals("Cascade:Shrek", useShreksWand, player.Center);
       }
	}
}
