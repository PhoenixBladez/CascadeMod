using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace Cascade.Items.GunUpgrades
{
    public class SniperUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Deadshot");
			Tooltip.SetDefault("Shoots out a bouncing bullet\nRight-click to zoom out");
		}


        public override void SetDefaults()
        {
            item.damage = 318;
            item.ranged = true;
            item.width = 108;
            item.height = 34;
            item.useTime = 32;
			item.crit = 30;
            item.useAnimation = 32;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 12;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 20, 22, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item40;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SniperBullet");
            item.shootSpeed = 24f;
            item.useAmmo = AmmoID.Bullet;
        }
		 public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("SniperBullet");
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
		public override void HoldItem(Player player)
        {
            player.scope = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
		    recipe.AddIngredient(ItemID.SniperRifle, 1);	
            recipe.AddIngredient(null, "AstralPrism", 13);
            recipe.AddIngredient(ItemID.Ectoplasm, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}