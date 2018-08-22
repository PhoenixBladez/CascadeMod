using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cascade.Event;

namespace Cascade.Items.Consumable
{
    public class BlackPearl : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Confluence of the Cosmos");
			Tooltip.SetDefault("'Disrupts the flow of Cosmic Energies'\nSummons the Cascade");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = 10;
            item.maxStack = 99;
            item.useStyle = 4;
            item.useTime = 30;
			item.useAnimation = 30;
			item.reuseDelay = 10;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item105;
        }

    
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
	       recipe.AddIngredient(ItemID.LunarBar, 3);
	       recipe.AddIngredient(null,"CosmicShard", 10);
            recipe.AddIngredient(null,"Malachite", 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
		 Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
  
			if (CascadeWorld.TheCascade)
			{
				return false;
				}
			Mod mod = ModLoader.GetMod("Cascade");
			CascadeWorld.TheCascade = true;
			return true;
        }
  
    }
}
