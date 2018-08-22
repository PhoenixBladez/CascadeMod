using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Cascade.Event.NPCs
{
    public class FluxStarShard : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flux Remnant");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 34;
            npc.damage = 70;
            npc.defense = 30;
            npc.lifeMax = 2480;
            npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 9060f;
            npc.knockBackResist = .0f;
			npc.chaseable = false;
            npc.aiStyle = 2;
			npc.noTileCollide =  true;
            npc.noGravity = true;
            aiType = NPCID.TheHungryII;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f * bossLifeScale);
        }
	   public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		int timer = 0;
		public override void AI()
		{
			timer++;
			npc.rotation += .2f;
			if(Main.rand.Next (5) == 0)
			{
			for (int num621 = 0; num621 < 5; num621++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 110);                 
						Main.dust[dust].scale = 0.5f;
						Main.dust[dust].velocity *= 0f;
					    int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
						Main.dust[dust1].scale = 1.5f;
						Main.dust[dust1].velocity *= 0f;
						int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                        Main.dust[dust2].scale = 1.5f;
						Main.dust[dust2].velocity *= 0f;
					}
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
						npc.velocity.X *= 1.2f;
			npc.velocity.Y *= 1.2f;
            for (int i = 0; i < 10; i++);
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
        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 1)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstralPrism"));
        }

    }
}
