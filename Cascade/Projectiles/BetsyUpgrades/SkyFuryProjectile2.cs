using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.BetsyUpgrades
{
	public class SkyFuryProjectile2 : ModProjectile
    {
  public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Demon's Wrath");
        }
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.Trident);
            projectile.height = 122;
            projectile.width = 122;
            aiType = ProjectileID.Trident;
        } 
		int timer = 10;     
        public override void AI()
        {
            timer--;
                 int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = .9f;

		}
        
		        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.AddBuff(BuffID.ShadowFlame, 240, true);
				                target.AddBuff(mod.BuffType("ShadowCurse"), 240, true);
		    }
			}
        


            //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
            //{
            //    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            //    for (int k = 0; k < projectile.oldPos.Length; k++)
            //    {
            //        Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
            //        Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
            //        spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            //    }
            //    return true;
            //}
        }
}