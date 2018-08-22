using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Cascade.Items.Event
{
	public class AstralPrism : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Quartz");
            Tooltip.SetDefault("'Glimmering through the spectrum of light'");

        }



        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 32;

            item.maxStack = 999;
            item.rare = 10;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

        }
		 public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
                        foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoB, Main.DiscoG, Main.DiscoB);
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
