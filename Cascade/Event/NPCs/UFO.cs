using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Event.NPCs
{
	public class UFO : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum Traverser");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
		{
			npc.damage = 88;
			npc.width = 34; //324
			npc.height = 26; //216
			npc.defense = 58;
			npc.lifeMax = 4220;
			npc.knockBackResist = 0f;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 5, 0, 0);
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.Item94;
		}
		
		public override void AI()
		{
		                bool expertMode = Main.expertMode;
		   Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .24f, .27f, 1.66f);
               
		 if (Main.rand.Next(190) == 4)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 91);
                Vector2 direction = Main.player[npc.target].Center - npc.Center;
                direction.Normalize();
                direction.X *= 7f;
                direction.Y *= 7f;

                int amountOfProjectiles = 2;
                for (int i = 0; i < amountOfProjectiles; ++i)
                {
                    float A = (float)Main.rand.Next(-200, 200) * 0.02f;
                    float B = (float)Main.rand.Next(-200, 200) * 0.02f;
                    int damage = expertMode ? 32 : 72;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("UFOBolt"), damage, 1, Main.myPlayer, 0, 0);

                }
            }
			npc.TargetClosest(true);
			float num1164 = 9f;
			float num1165 = 0.95f;
			Vector2 vector133 = new Vector2(npc.Center.X, npc.Center.Y);
			float num1166 = Main.player[npc.target].Center.X - vector133.X;
			float num1167 = Main.player[npc.target].Center.Y - vector133.Y - 200f;
			float num1168 = (float)Math.Sqrt((double)(num1166 * num1166 + num1167 * num1167));
			if (num1168 < 20f)
			{
				num1166 = npc.velocity.X;
				num1167 = npc.velocity.Y;
			}
			else
			{
				num1168 = num1164 / num1168;
				num1166 *= num1168;
				num1167 *= num1168;
			}
			if (npc.velocity.X < num1166)
			{
				npc.velocity.X = npc.velocity.X + num1165;
				if (npc.velocity.X < 0f && num1166 > 0f)
				{
					npc.velocity.X = npc.velocity.X + num1165 * 2f;
				}
			}
			else if (npc.velocity.X > num1166)
			{
				npc.velocity.X = npc.velocity.X - num1165;
				if (npc.velocity.X > 0f && num1166 < 0f)
				{
					npc.velocity.X = npc.velocity.X - num1165 * 2f;
				}
			}
			if (npc.velocity.Y < num1167)
			{
				npc.velocity.Y = npc.velocity.Y + num1165;
				if (npc.velocity.Y < 0f && num1167 > 0f)
				{
					npc.velocity.Y = npc.velocity.Y + num1165 * 2f;
				}
			}
			else if (npc.velocity.Y > num1167)
			{
				npc.velocity.Y = npc.velocity.Y - num1165;
				if (npc.velocity.Y > 0f && num1167 < 0f)
				{
					npc.velocity.Y = npc.velocity.Y - num1165 * 2f;
				}
			}
			if (npc.position.X + (float)npc.width > Main.player[npc.target].position.X && npc.position.X < Main.player[npc.target].position.X + (float)Main.player[npc.target].width && npc.position.Y + (float)npc.height < Main.player[npc.target].position.Y && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && Main.netMode != 1)
			{
				npc.ai[0] += 4f;
				if (npc.ai[0] > 24f)
				{
				                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 91);
					npc.ai[0] = 0f;
					int num1169 = (int)(npc.position.X + 10f + (float)Main.rand.Next(npc.width - 20));
					int num1170 = (int)(npc.position.Y + (float)npc.height + 4f);
					int num184 = 75;
					if (Main.expertMode)
					{
						num184 = 29;
					}
					Projectile.NewProjectile((float)num1169, (float)num1170, 0f, 5f, mod.ProjectileType("UFOBolt"), num184, 0f, Main.myPlayer, 0f, 0f);
					return;
				}
			}
		}
		
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < 3; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 206, hitDirection, -1f, 0, default(Color), 1f);
			}
            if (npc.life <= 0)
            {
       for (int i = 0; i < 50; ++i) //Create dust after teleport
                        {
				
					       int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
                            Main.dust[dust1].scale = 1.5f;
														Main.dust[dust1].velocity *= 1.5f;
					        }            }
        }
		  public override void NPCLoot()
        {
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Malachite"));
            }
			   if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlackPearl"));
            }
			{
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmicShard"));
            }
            
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.sky && NPC.downedMoonlord ? 0.0416f : 0f;
        }
    }
}