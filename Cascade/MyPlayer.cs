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
namespace Cascade
{
    public class MyPlayer : ModPlayer
    {

        public bool phantasmEye = false;
		
        public override void ResetEffects()
        {
		this.phantasmEye = false;
		}
        public override void PostUpdateEquips()
        {
           
            if (this.phantasmEye)
            {
                this.SpawnRunicRunes();
            }
           
       }
        private void SpawnRunicRunes()
        {
            int num = 80;
            float num2 = 2.5f;
            int num3 = mod.ProjectileType("PhantasmEye1");
            if (Main.rand.Next(18) == 0)
            {
                int num4 = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].type == num3)
                    {
                        num4++;
                    }
                }
                if (Main.rand.Next(15) >= num4 && num4 < 9)
                {
                    int num5 = 50;
                    int num6 = 24;
                    int num7 = 90;
                    for (int j = 0; j < num5; j++)
                    {
                        int num8 = Main.rand.Next(300 - j * 2, 500 + j * 2);
                        Vector2 center = player.Center;
                        center.X += (float)Main.rand.Next(-num8, num8 + 1);
                        center.Y += (float)Main.rand.Next(-num8, num8 + 1);
                        if (!Collision.SolidCollision(center, num6, num6) && !Collision.WetCollision(center, num6, num6))
                        {
                            center.X += (float)(num6 / 2);
                            center.Y += (float)(num6 / 2);
                            if (Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(player.Center.X, player.position.Y - 50f), 1, 1, center, 1, 1))
                            {
                                int num9 = (int)center.X / 16;
                                int num10 = (int)center.Y / 16;
                                bool flag = false;
                                if (Main.rand.Next(4) == 0 && Main.tile[num9, num10] != null && Main.tile[num9, num10].wall > 0)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    center.X -= (float)(num7 / 2);
                                    center.Y -= (float)(num7 / 2);
                                    if (Collision.SolidCollision(center, num7, num7))
                                    {
                                        center.X += (float)(num7 / 2);
                                        center.Y += (float)(num7 / 2);
                                        flag = true;
                                    }
                                }
                                if (flag)
                                {
                                    for (int k = 0; k < 1000; k++)
                                    {
                                        if (Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].type == num3 && (center - Main.projectile[k].Center).Length() < 48f)
                                        {
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag && Main.myPlayer == player.whoAmI)
                                    {
                                        Terraria.Projectile.NewProjectile(center.X, center.Y, 0f, 0f, num3, num, num2, player.whoAmI, 0f, 0f);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
	 }
	 }

	   