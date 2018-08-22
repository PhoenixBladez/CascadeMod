using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Items.Malachite
{
    public class MalachitePickaxe : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Malachite Pickaxe");
		}


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 30;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.pick = 240;
            item.damage = 84;
			item.tileBoost += 5;
            item.knockBack = 4;
            item.useStyle = 1;
            item.useTime = 7;
            item.useAnimation = 12;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"Malachite", 24);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

