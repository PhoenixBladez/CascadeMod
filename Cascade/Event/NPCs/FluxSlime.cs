using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cascade.Event;

namespace Cascade.Event.NPCs
{
    public class FluxSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flux Slime");
            Main.npcFrameCount[npc.type] = 2;
        }
		int timer = 0;
        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 26;
            npc.damage = 101;
            npc.defense = 34;
			npc.value = 12000f;
            npc.lifeMax = 4900;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.Item94;
            npc.value = 13060f;
            npc.knockBackResist = 0.3f;
            npc.aiStyle = 41; 
            aiType = NPCID.Derpling;
			animationType = NPCID.BlueSlime;
            npc.lavaImmune = true;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CascadeWorld.TheCascade)
                return 5f;

            return 0;
        }
		  public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("PrismShatter"), 90);
            }
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f * bossLifeScale);
        }
		 public override void HitEffect(int hitDirection, double damage)
        {
if(Main.rand.Next(3) == 0)
{
  Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 94);
        
            Player target = Main.player[npc.target];
            int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
            npc.position.X = npc.position.X + (float)(npc.width / 2);
            npc.position.Y = npc.position.Y + (float)(npc.height / 2);
            npc.width = 30;
            npc.height = 30;
            npc.position.X = npc.position.X - (float)(npc.width / 2);
            npc.position.Y = npc.position.Y - (float)(npc.height / 2);
            int p = Terraria.Projectile.NewProjectile(npc.position.X + 5, npc.position.Y + 8, -(npc.position.X - target.position.X) / distance * 15, -(npc.position.Y - target.position.Y) / distance * 15, mod.ProjectileType("AstralBolt"), (int)((npc.damage * .15)), 0);
}
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {					  Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14);
			                    for (int i = 0; i < 6; ++i)
                    {
                        Vector2 targetDir = ((((float)Math.PI * 2) / 6) * i).ToRotationVector2();
                        targetDir.Normalize();
                        targetDir *= 3;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, targetDir.X, targetDir.Y, mod.ProjectileType("AstralBolt"), (int)(npc.damage / 4), 0.5F, Main.myPlayer);
                    }
						CascadeWorld.EnemyKills++;
                for (int num621 = 0; num621 < 20; num621++)
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
		if(Main.rand.Next(2) == 0)
		{
			      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstralPrism"));
		}
		}
		   public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}