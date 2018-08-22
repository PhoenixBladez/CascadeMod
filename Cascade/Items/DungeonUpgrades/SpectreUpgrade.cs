using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.DungeonUpgrades
{
    public class SpectreUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Burst");
		}


        public override void SetDefaults()
        {
            item.damage = 128;
			item.magic = true;
			item.mana = 15;
			item.width = 56;
			item.height = 57;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 8;
            item.value = Terraria.Item.sellPrice(0, 25, 50, 0);
            item.rare = 11;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpectreProj");
			item.shootSpeed = 12f; 
        }
			 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreStaff, 1);
			            recipe.AddIngredient(null,"AstralPrism", 12);
						            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
      
    }
}