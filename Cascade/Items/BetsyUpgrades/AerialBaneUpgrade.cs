using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Cascade.Items.BetsyUpgrades
{
    public class AerialBaneUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ethereal Bane");
			Tooltip.SetDefault("Rains down multiple ethereal bolts from the sky on hitting foes\nDeals extra damage to airborne foes\nInflicts Shadowflame and Shadow Curse, lowering enemy defense");
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.LightPink;
        }
        private Vector2 newVect;
        public override void SetDefaults()
        {
            item.damage = 60;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 40;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.shoot = 9;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 5;
            item.value = Terraria.Item.sellPrice(0,  20, 0, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 22f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 origVect = new Vector2(speedX, speedY);
            for (int X = 0; X <= 5; X++)
            {
                if (Main.rand.Next(2) == 1)
                {
                    newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                else
                {
                    newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("EtherealBaneProj"), damage, knockBack, player.whoAmI);
                Projectile newProj2 = Main.projectile[proj2];
            }
            return false;
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DD2BetsyBow, 1);
			            recipe.AddIngredient(null,"Malachite", 8);
						            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}