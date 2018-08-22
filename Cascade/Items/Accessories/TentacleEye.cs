using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Cascade.Items.Accessories
{
    public class TentacleEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystic Eye");
            Tooltip.SetDefault("Press UP to change gravity\nSpawns phantasmal eyes that home onto nearby enemies and explode");

        }


        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 32, 0, 0);
            item.rare = 5;
			item.expert = true;
            item.accessory = true;
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(ItemID.SporeSac, 1);
						            recipe.AddIngredient(ItemID.GravityGlobe, 1);
            recipe.AddIngredient(null, "Malachite", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>(mod).phantasmEye = true;
				player.AddBuff(BuffID.Gravitation, 1);
        }
    }
}
