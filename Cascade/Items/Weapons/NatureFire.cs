using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.Weapons
{
    public class NatureFire : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wildfire Blade");
			Tooltip.SetDefault("'The destroyer and propogator of nature'\nShoots out a fiery blaze that explodes into multiple vines of energy above hit foes");
		}

int charger = 0;
        public override void SetDefaults()
        {
            item.damage = 65;
            item.useTime = 24;
            item.useAnimation = 24;
            item.melee = true;            
            item.width = 68;              
            item.height = 78;             
            item.useStyle = 1;        
            item.knockBack = 6.5f;
            item.value = Terraria.Item.sellPrice(0, 12, 0, 0);
            item.rare = 8;
            item.shootSpeed = 12;
            item.UseSound = SoundID.Item74;   
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("WildfireProjectile");
        }
		        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
Main.dust[dust].noGravity = true;
            }

        }
     	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		    {
                    charger++;
                    if (charger >= 2)
                    {
                        for (int I = 0; I < 1; I++)
                        {
                            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
                        }
                        charger = 0;
                    }
                }
			
			return false;
		}
				public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
			
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cutlass);
		    recipe.AddIngredient(ItemID.BrokenHeroSword);
		    recipe.AddIngredient(ItemID.HellstoneBar, 4);
		    recipe.AddIngredient(ItemID.ChlorophyteBar, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}