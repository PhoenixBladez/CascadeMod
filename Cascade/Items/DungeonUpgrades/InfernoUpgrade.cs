using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.DungeonUpgrades
{
    public class InfernoUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fiendfire Trident");
		}


        public override void SetDefaults()
        {
            item.damage = 151;
			item.magic = true;
			item.mana = 21;
			item.width = 56;
			item.height = 57;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 10;
            item.value = Terraria.Item.sellPrice(0, 26, 50, 0);
            item.rare = 11;
			item.UseSound = SoundID.Item73;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("InfernoProj");
			item.shootSpeed = 12f; 
        }
			 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.InfernoFork, 1);
			            recipe.AddIngredient(null,"AstralPrism", 12);
						            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
      
    }
}