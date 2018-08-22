using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.BetsyUpgrades
{
    public class DemonFire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Fire");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.alpha = 255;
            projectile.timeLeft = 300;
            projectile.height = 16;
            projectile.width = 16;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            {
			               {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = .9f;
					
					             int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust1].noGravity = true;
                    Main.dust[dust1].velocity *= 0f;
                    Main.dust[dust1].scale = 1.9f;
                }

            }
        }
		
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
		   projectile.velocity *= 0f;
		               projectile.height = 36;
            projectile.width = 36;
		   target.AddBuff(BuffID.ShadowFlame, 240);
		   				                target.AddBuff(mod.BuffType("ShadowCurse"), 240, true);
        }
		
    }
}
