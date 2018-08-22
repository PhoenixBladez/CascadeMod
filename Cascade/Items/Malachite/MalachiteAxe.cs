using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Items.Malachite
{
    public class MalachiteAxe : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Malachite Axe");
		}


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 30;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.axe = 35;
            item.damage = 98;
            item.knockBack = 9;
            item.useStyle = 1;
            item.useTime = 18;
            item.useAnimation = 18;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"Malachite", 21);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
