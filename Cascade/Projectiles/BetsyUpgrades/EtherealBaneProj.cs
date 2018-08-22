using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Projectiles.BetsyUpgrades
{
	public class EtherealBaneProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ethereal Bolt");

        }
        public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 26;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 1000;
			projectile.light = 0f;

			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return true;
		}
		  public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override bool PreAI()
        {
            {
                {
                    projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.5f, 0.5f, 0.9f);
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                            float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                            int num = Dust.NewDust(new Vector2(x, y), 1, 1, 173, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[num].alpha = projectile.alpha;
                            Main.dust[num].position.X = x;
                            Main.dust[num].position.Y = y;
                            Main.dust[num].velocity *= 0f;
                            Main.dust[num].noGravity = true;
                        }
                    }
                }
            }
            projectile.velocity.Y += 0.4F;
            projectile.velocity.X *= 1.001F;
            projectile.velocity.X = MathHelper.Clamp(projectile.velocity.X, -20, 20);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            {
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("WrathCurse"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 100;
            projectile.height = 100;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            for (int num621 = 0; num621 < 20; num621++)
            {
                int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num622].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num622].scale = 0.5f;
                    Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            
        }
		}		
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if(target.velocity.Y >= 0)
			{
			target.StrikeNPC(projectile.damage / 3, 0f, 0, crit);
			}
            if (Main.rand.Next(6) == 0)
            {
                target.AddBuff(mod.BuffType("WrathCurse"), 120, true);
            }
			Player player = Main.player[projectile.owner];
                for (int i = 0; i < 3; ++i)
                {

                    if (Main.myPlayer == player.whoAmI)
                    {
                        Vector2 mouse = Main.MouseWorld;
                        Projectile.NewProjectile(target.Center.X + Main.rand.Next(-80, 80), projectile.position.Y - 1000 + Main.rand.Next(-50, 50), 0, Main.rand.Next(10, 20), mod.ProjectileType("EtherealBaneProj1"), projectile.damage / 5 * 4, projectile.knockBack, Main.myPlayer);
                    }
                }
		
        }
    }
}