using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cascade.Event;

namespace Cascade.Event.NPCs
{
    public class Asteroid : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum Asteroid");
            Main.npcFrameCount[npc.type] = 6;
        }
		int timer = 0;
        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 26;
            npc.damage = 97;
            npc.defense = 67;
			npc.value = 18000f;
            npc.lifeMax = 3600;
            npc.HitSound = SoundID.NPCHit41;
            npc.DeathSound = SoundID.NPCDeath43;
            npc.value = 3060f;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 85;
            npc.noGravity = true;
            npc.noTileCollide = true;
            aiType = NPCID.StardustCellBig;
            npc.lavaImmune = true;
        }
		  public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f * bossLifeScale);
        }

		 public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
		public override void AI()
		{
		          npc.TargetClosest(true);
                Player player = Main.player[npc.target];
		  
		float num801 = npc.position.X + (float)(npc.width / 2) - player.position.X - (float)(player.width / 2);
            float num802 = npc.position.Y + (float)npc.height - 59f - player.position.Y - (float)(player.height / 2);
            float num803 = (float)Math.Atan2((double)num802, (double)num801) + 1.57f;
            if (num803 < 0f)
            {
                num803 += 6.283f;
            }
            else if ((double)num803 > 6.283)
            {
                num803 -= 6.283f;
            }
            float num804 = 0.1f;
            if (npc.rotation < num803)
            {
                if ((double)(num803 - npc.rotation) > 3.1415)
                {
                    npc.rotation -= num804;
                }
                else
                {
                    npc.rotation += num804;
                }
            }
            else if (npc.rotation > num803)
            {
                if ((double)(npc.rotation - num803) > 3.1415)
                {
                    npc.rotation += num804;
                }
                else
                {
                    npc.rotation -= num804;
                }
            }
            if (npc.rotation > num803 - num804 && npc.rotation < num803 + num804)
            {
                npc.rotation = num803;
            }
            if (npc.rotation < 0f)
            {
                npc.rotation += 6.283f;
            }
            else if ((double)npc.rotation > 6.283)
            {
                npc.rotation -= 6.283f;
            }
            if (npc.rotation > num803 - num804 && npc.rotation < num803 + num804)
            {
                npc.rotation = num803;
            }
		           int dust5 = Dust.NewDust(npc.position, npc.width, npc.height, 110);
                            Main.dust[dust5].noGravity = true;
							Main.dust[dust5].velocity *= 0f;
					       int dust6 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
                                  Main.dust[dust6].noGravity = true;
							Main.dust[dust6].velocity *= 0f;
											  int dust7 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                                                     Main.dust[dust7].noGravity = true;
							Main.dust[dust7].velocity *= 0f;
		timer++;
			  if (timer == 120)
                    {
                        for (int i = 0; i < 50; ++i) //Create dust before teleport
                        {
                            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 110);
					       int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
                            Main.dust[dust1].scale = 1.5f;
														Main.dust[dust1].velocity *= 1.5f;
						  int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                            Main.dust[dust2].scale = 1.5f;
														Main.dust[dust2].velocity *= 1.5f;
							
                        }
						  Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 72);
        
						  Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14);
        
                        npc.position.X = player.position.X + Main.rand.Next(-200, 200);
                        npc.position.Y = player.position.Y + Main.rand.Next(-200, -10);
                        Vector2 direction = Main.player[npc.target].Center - npc.Center;
                        direction.Normalize();
                        npc.velocity.Y = direction.Y * 14f;
                        npc.velocity.X = direction.X * 14f;

                        for (int i = 0; i < 50; ++i) //Create dust after teleport
                        {
						 int dust = Dust.NewDust(npc.position, npc.width, npc.height, 110);
                          
                              Main.dust[dust].scale = 0.5f;
							Main.dust[dust].velocity *= 1.5f;
					       int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
                            Main.dust[dust1].scale = 1.5f;
														Main.dust[dust1].velocity *= 1.5f;
						  int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                            Main.dust[dust2].scale = 1.5f;
														Main.dust[dust2].velocity *= 1.5f;
							        }
						timer = 0;
                    }
					
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CascadeWorld.TheCascade)
                return 5.5f;

            return 0;
        }
		   public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		 public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("PrismShatter"), 90);
            }
        }
		public override void NPCLoot()
		{
				if(Main.rand.Next(2) == 0)
		{
			      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstralPrism"));
		}
		}
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
			CascadeWorld.EnemyKills++;		
  for (int i = 0; i < 50; ++i) //Create dust after teleport
                        {
						 int dust = Dust.NewDust(npc.position, npc.width, npc.height, 110);
                          
                              Main.dust[dust].scale = 0.5f;
							Main.dust[dust].velocity *= 1.5f;
					       int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
                            Main.dust[dust1].scale = 1.5f;
														Main.dust[dust1].velocity *= 1.5f;
						  int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                            Main.dust[dust2].scale = 1.5f;
														Main.dust[dust2].velocity *= 1.5f;
							        }
        }
		

    }
}
}
