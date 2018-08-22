using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.BetsyUpgrades
{
    public class DemonWrath : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon's Rage");
			Tooltip.SetDefault("Inflicts Shadowflame and Shadow Curse");
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.LightPink;
        }
        public override void SetDefaults()
        {
            item.damage = 101;
			item.magic = true;
			item.mana = 11;
			item.width = 50;
			item.height = 50;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 8;
            item.value = Terraria.Item.sellPrice(0, 29, 50, 0);
            item.rare = 10;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DemonWrathProj");
			item.shootSpeed = 8f; 
        }
			 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ApprenticeStaffT3, 1);
			            recipe.AddIngredient(null,"Malachite", 7);
						            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		 Projectile.NewProjectile(position.X , position.Y , speedX * 2f, speedY, mod.ProjectileType("DemonWrathProj"), damage, knockBack, player.whoAmI, 0f, 0f);
		 Projectile.NewProjectile(position.X , position.Y , speedX * 2.5f, speedY, mod.ProjectileType("DemonWrathProj"), damage, knockBack, player.whoAmI, 0f, 0f);		
         Projectile.NewProjectile(position.X , position.Y , speedX * 1.5f, speedY, mod.ProjectileType("DemonWrathProj"), damage, knockBack, player.whoAmI, 0f, 0f);
	     Projectile.NewProjectile(position.X , position.Y, speedX, speedY, mod.ProjectileType("DemonWrathProj"), damage, knockBack, player.whoAmI, 0f, 0f);
		 Projectile.NewProjectile(position.X , position.Y , speedX / 2, speedY, mod.ProjectileType("DemonWrathProj"), damage, knockBack, player.whoAmI, 0f, 0f);		
            return false;
        }
      
    }
}