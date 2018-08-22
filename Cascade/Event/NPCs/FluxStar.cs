using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cascade.Event;

namespace Cascade.Event.NPCs
{
    public class FluxStar : ModNPC
    {
		int moveSpeed = 0;
		int moveSpeedY = 0;
		float HomeY = 80f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flux Star");
        }
        public override void SetDefaults()
        {
            npc.width = 62;
            npc.height = 62;
            npc.damage = 97;
            npc.defense = 50;
			npc.value = 10130f;
            npc.lifeMax = 7100;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath43;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.lavaImmune = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f * bossLifeScale);
        }
		int timer = 0;
		int projectileTimer = 0;
		public override void AI()
		{
			npc.rotation += 0.2f;
			bool expertMode = Main.expertMode;
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
				if (npc.Center.X >= player.Center.X && moveSpeed >= -53) // flies to players x position
				{
					moveSpeed--;
				}
					
				if (npc.Center.X <= player.Center.X && moveSpeed <= 53)
				{
					moveSpeed++;
				}
				
				npc.velocity.X = moveSpeed * 0.1f;
				
				if (npc.Center.Y >= player.Center.Y - HomeY && moveSpeedY >= -30) //Flies to players Y position
				{
					moveSpeedY--;
					HomeY = 150f;
				}
					
				if (npc.Center.Y <= player.Center.Y - HomeY && moveSpeedY <= 30)
				{
					moveSpeedY++;
				}
				
				npc.velocity.Y = moveSpeedY * 0.1f;
			if (Main.rand.Next(220) == 6)
			{
				HomeY = -35f;
			}
			timer++;
			if (timer == 100 || timer == 200 || timer == 300 || timer == 400 || timer == 500 || timer == 600 || timer == 700 || timer == 800)
			{
			npc.TargetClosest(true);
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
			direction.Normalize();
			direction *= 9f;
			{
				{
					for (int num621 = 0; num621 < 5; num621++)
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
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 91);
					int damage = expertMode ? 60 : 95;
					int proj2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("FluxStarBeam"), damage, 1f, npc.target);
				}
			}
			}
			if (timer >= 900)
			{
				npc.rotation += 0.3f;
				projectileTimer++;
                npc.velocity.X = 0f;
				npc.velocity.Y = 0f;
				if(	projectileTimer >= 10)
				{
					npc.defense = 80;
					for (int num621 = 0; num621 < 5; num621++)
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
					projectileTimer = 0;
					npc.TargetClosest(true);
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					direction *= 12f;
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 91);
					int damage = expertMode ? 50 : 85;
					int proj2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("FluxStarBeam"), damage, 1f, npc.target);
				}
			}
			if (timer >= 1100)
			{
				timer = 0;
				projectileTimer = 0;
			}
			
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CascadeWorld.TheCascade)
                return 1.5f;

            return 0;
        }
		   public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override void NPCLoot()
		{
				if(Main.rand.Next(2) == 0)
		{
			      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstralPrism"));
		}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("PrismShatter"), 90);
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
				
		                        for (int i = 0; i < 3; ++i)
								{
                    Vector2 dir = Main.player[npc.target].Center - npc.Center;
                    dir.Normalize();
                    dir *= 4;
                    int newNPC = NPC.NewNPC((int)npc.Center.X + (Main.rand.Next(-15, 15)), (int)npc.Center.Y + (Main.rand.Next(-15, 15)), mod.NPCType("FluxStarShard"), npc.whoAmI);
                    Main.npc[newNPC].velocity = dir;
					};
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
