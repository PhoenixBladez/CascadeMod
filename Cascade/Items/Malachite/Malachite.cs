using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Items.Malachite
{
    public class Malachite : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Malachite");
			Tooltip.SetDefault("'Imbued with Lunar and Terran energy'");
		}


        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;

            item.maxStack = 999;
            item.rare = 10;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("MalachiteTile");
        }
    }
}
