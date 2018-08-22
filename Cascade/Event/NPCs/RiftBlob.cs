using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cascade.Event;

namespace Cascade.Event.NPCs
{
    public class RiftBlob : ModNPC
    {
	        int moveSpeed = 0;
        int moveSpeedY = 0;
        float HomeY = 150f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift Hopper");
            Main.npcFrameCount[npc.type] = 5;
        }
		int timer = 0;
        public override void SetDefaults()
        {
            npc.width = 42;
            npc.height = 34;
            npc.damage = 76;
            npc.defense = 34;
			npc.value = 5000f;
            npc.lifeMax = 3300;
            npc.HitSound = SoundID.Item86;
            npc.DeathSound = SoundID.Item95;
            npc.value = 3060f;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
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
				bool txt = false;
		public override void AI()
		{
		            npc.noTileCollide = true;
		                    Player player = Main.player[npc.target];
		      if (npc.Center.X >= player.Center.X && moveSpeed >= -68) // flies to players x position
                        {
                            moveSpeed--;
                        }

                        if (npc.Center.X <= player.Center.X && moveSpeed <= 68)
                        {
                            moveSpeed++;
                        }

                        npc.velocity.X = moveSpeed * 0.1f;

                        if (npc.Center.Y >= player.Center.Y - HomeY && moveSpeedY >= -44) //Flies to players Y position
                        {
                            moveSpeedY--;
                            HomeY = 160f;
                        }

                        if (npc.Center.Y <= player.Center.Y - HomeY && moveSpeedY <= 44)
                        {
                            moveSpeedY++;
                        }

                        npc.velocity.Y = moveSpeedY * 0.15f;
                        if (Main.rand.Next(220) == 6)
                        {
                            HomeY = -25f;
                        }
		if(!txt)
		{
		                        for (int i = 0; i < 6; ++i)
								{
                    Vector2 dir = Main.player[npc.target].Center - npc.Center;
                    dir.Normalize();
                    dir *= 12;
                    int newNPC = NPC.NewNPC((int)npc.Center.X + (Main.rand.Next(-150, 150)), (int)npc.Center.Y + (Main.rand.Next(-150, 150)), mod.NPCType("RiftBlob1"), npc.whoAmI);
                    Main.npc[newNPC].velocity = dir;
					}
			txt = true;
		}
		}
		
		   public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
		 int dust3 = Dust.NewDust(npc.position, npc.width, npc.height, 110);
                          
                              Main.dust[dust3].scale = 0.5f;
							Main.dust[dust3].velocity *= 1.5f;
					       int dust4 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
                            Main.dust[dust4].scale = 1.5f;
														Main.dust[dust4].velocity *= 1.5f;
						  int dust5 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                            Main.dust[dust5].scale = 1.5f;
														Main.dust[dust5].velocity *= 1.5f;
		
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {		
			         for (int i = 0; i < 5; ++i)
                    {
                        Vector2 targetDir = ((((float)Math.PI * 2) / 5) * i).ToRotationVector2();
                        targetDir.Normalize();
                        targetDir *= 3;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, targetDir.X, targetDir.Y, mod.ProjectileType("FluxRain"), (int)(npc.damage / 3), 0.5F, Main.myPlayer);
                    }	
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
	}
}