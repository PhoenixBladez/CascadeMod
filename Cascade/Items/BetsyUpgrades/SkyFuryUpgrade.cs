using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Cascade.Items.BetsyUpgrades
{
    public class SkyFuryUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Demon's Wrath");
			Tooltip.SetDefault("Right click to thrust as a spear, releasing multiple dark flames\nInflicts Shadowflame and Shadow Curse, which reduces enemy defense");
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.LightPink;
        }
        private Vector2 newVect;
        public override void SetDefaults()
        {
            item.useStyle = 100;
            item.width = 58;
            item.height = 58;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
			item.channel = true;
            item.noMelee = true;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 6f;
            item.knockBack = 6f;
            item.damage = 102;
            item.value = Item.sellPrice(0, 25, 60, 0);
            item.rare = 10;
            item.shoot = mod.ProjectileType("SkyFuryProjectile1");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
		 public override bool UseItemFrame(Player player)
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
		
        }
     public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MonkStaffT3, 1);
			            recipe.AddIngredient(null,"Malachite", 7);
						            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
               item.UseSound = SoundID.Item92;
                item.autoReuse = true;
                item.useAnimation = 25;
                item.useTime = 25;
                item.shootSpeed = 8f;

				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DemonFire"), damage/3 * 2, knockBack, player.whoAmI, 0f, 0f);
             Projectile.NewProjectile(position.X, position.Y - 20, speedX, speedY, mod.ProjectileType("DemonFire"), damage/3 * 2, knockBack, player.whoAmI, 0f, 0f);
             
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SkyFuryProjectile2"), damage, knockBack, player.whoAmI, 0f, 0f);
                return false;
            }
            else
            {
			    item.UseSound = SoundID.Item1;
                item.autoReuse = true;
				item.useAnimation = 25;
                item.useTime = 25;
                item.melee = true;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SkyFuryProjectile1"), damage, knockBack, player.whoAmI, 0f, 0f);
                item.shootSpeed = 0f;
            }
            return false;
        }
    }
}