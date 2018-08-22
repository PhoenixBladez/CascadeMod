using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.DungeonUpgrades
{
    public class ShadowbeamUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Umbra Scepter");
		}


        public override void SetDefaults()
        {
            item.damage = 120;
			item.magic = true;
			item.mana = 7;
			item.width = 56;
			item.height = 57;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 5;
            item.value = Terraria.Item.sellPrice(0, 26, 50, 0);
            item.rare = 11;
			item.UseSound = SoundID.Item72;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowProj");
			item.shootSpeed = 12f; 
        }
			 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShadowbeamStaff, 1);
			            recipe.AddIngredient(null,"AstralPrism", 12);
						            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
      
    }
}