using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Cascade.Items.Event
{
	public class CosmicShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flux Bubble");
            Tooltip.SetDefault("'This otherworldy bubble seems to flux through time'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }



        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;

            item.maxStack = 999;
            item.rare = 10;
            item.consumable = true;
}
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
