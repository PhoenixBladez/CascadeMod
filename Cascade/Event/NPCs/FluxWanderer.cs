using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Cascade.Event;
using Terraria.ModLoader;

namespace Cascade.Event.NPCs
{
    public class FluxWanderer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flux Wanderer");
			            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.width = 114;
            npc.height = 74;
            npc.damage = 95;
            npc.defense = 42;
            npc.lifeMax = 4220;
            npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 4360f;
            npc.knockBackResist = 0.05f;
            npc.aiStyle = 26;
            aiType = NPCID.Unicorn;

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
		   public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CascadeWorld.TheCascade)
                return 5.3f;

            return 0;
        }
		  public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
      
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
 int dust = Dust.NewDust(npc.position, npc.width, npc.height, 206);
 Main.dust[dust].noGravity = true;
 Main.dust[dust].scale *= 1.5f;
				                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 107);
								 Main.dust[dust1].noGravity = true;
								  Main.dust[dust1].scale *= .5f;
								                int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, 244);
												 Main.dust[dust2].noGravity = true;
												  Main.dust[dust2].scale *= 1.5f;
 
            }
        }

        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.6f, .8f, 0.06f);
            {
         int dust = Dust.NewDust(npc.position, npc.width, npc.height, 206);
 Main.dust[dust].noGravity = true;
 Main.dust[dust].scale *= 1.5f;
				                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 107);
								 Main.dust[dust1].noGravity = true;
								  Main.dust[dust1].scale *= .5f;
								                int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, 244);
												 Main.dust[dust2].noGravity = true;
												  Main.dust[dust2].scale *= 1.5f;
		               {
                    npc.spriteDirection = npc.direction;
                    {
                        int num67 = 80;
                        {
                            num67 = 12;
                            if (npc.ai[3] == -120f)
                            {
                                npc.velocity *= 0f;
                                npc.ai[3] = 0f;
                                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                                Vector2 vector14 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                float num68 = npc.oldPos[2].X + (float)npc.width * 0.5f - vector14.X;
                                float num69 = npc.oldPos[2].Y + (float)npc.height * 0.5f - vector14.Y;
                                float num70 = (float)Math.Sqrt((double)(num68 * num68 + num69 * num69));
                                num70 = 2f / num70;
                                num68 *= num70;
                                num69 *= num70;
                                for (int num71 = 0; num71 < 20; num71++) //both loops spawn the pink dust.  simply change the id :P
                                {
                                    int num72 = Dust.NewDust(npc.position, npc.width, npc.height, 206, num68, num69, 200, default(Color), 2f);
                                    Main.dust[num72].noGravity = true;
                                    Dust expr_5C01_cp_0 = Main.dust[num72];
                                    expr_5C01_cp_0.velocity.X = expr_5C01_cp_0.velocity.X * 2f;
                                }
                                for (int num73 = 0; num73 < 20; num73++)
                                {
                                    int num74 = Dust.NewDust(npc.oldPos[2], npc.width, npc.height, 175, -num68, -num69, 200, default(Color), 2f);
                                    Main.dust[num74].noGravity = true;
                                    Dust expr_5C82_cp_0 = Main.dust[num74];
                                    expr_5C82_cp_0.velocity.X = expr_5C82_cp_0.velocity.X * 2f;
                                }
                            }
                        }
                        if (Main.netMode != 1 && npc.ai[3] >= (float)num67) //npc allows for teleporting.  moves npc to new position
                        {
                            int num214 = (int)Main.player[npc.target].position.X / 16;  //calculates player postition
                            int num215 = (int)Main.player[npc.target].position.Y / 16;
                            int num216 = (int)npc.position.X / 16;
                            int num217 = (int)npc.position.Y / 16;
                            int num218 = 20;
                            int num219 = 0;
                            bool flag28 = false;
                            if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 5000f)
                            {
                                num219 = 100;
                                flag28 = true;
                            }
                            while (!flag28)
                            {
                                if (num219 >= 100)
                                {
                                    return;
                                }
                                num219++;
                                int num220 = Main.rand.Next(num214 - num218, num214 + num218);
                                int num221 = Main.rand.Next(num215 - num218, num215 + num218);
                                for (int num222 = num221; num222 < num215 + num218; num222++)
                                {
                                    if ((num222 < num215 - 4 || num222 > num215 + 4 || num220 < num214 - 4 || num220 > num214 + 4) && (num222 < num217 - 1 || num222 > num217 + 1 || num220 < num216 - 1 || num220 > num216 + 1) && Main.tile[num220, num222].nactive())
                                    {
                                        bool flag29 = true;
                                        if (npc.type == 32 && Main.tile[num220, num222 - 1].wall == 0)
                                        {
                                            flag29 = false;
                                        }
                                        else if (Main.tile[num220, num222 - 1].lava()) //avoids lava
                                        {
                                            flag29 = false;
                                        }
                                        if (flag29 && Main.tileSolid[(int)Main.tile[num220, num222].type] && !Collision.SolidTiles(num220 - 1, num220 + 1, num222 - 4, num222 - 1)) //checks for a tile and if there is enough space
                                        {
                                            npc.position.X = (float)(num220 * 16 - npc.width / 2);
                                            npc.position.Y = (float)(num222 * 16 - npc.height);
                                            npc.netUpdate = true;
                                            npc.ai[3] = -120f;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstralPrism"));
            }
			            if (Main.rand.Next(50) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstralSword"), Main.rand.Next(1) + 1);
            }
        }
    }
}
