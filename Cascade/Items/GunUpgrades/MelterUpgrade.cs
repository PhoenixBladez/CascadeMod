using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace Cascade.Items.GunUpgrades
{
    public class MelterUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starflare");
		}


        public override void SetDefaults()
        {
            item.damage = 108;
            item.ranged = true;
            item.width = 68;
            item.height = 34;
            item.useTime = 7;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = .2f;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 20, 22, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Flare");
            item.shootSpeed = 18f;
        }
		 public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("Flare");
			   Projectile.NewProjectile(position.X , position.Y , speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
           
		                           return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
		            recipe.AddIngredient(ItemID.EldMelter, 1);	
            recipe.AddIngredient(null, "AstralPrism", 13);
					            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}