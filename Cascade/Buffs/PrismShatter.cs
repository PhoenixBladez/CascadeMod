using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Buffs
{
    public class PrismShatter : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Prism Shatter");
            Description.SetDefault("'Your life has been splintered'");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.lifeRegen = 0;
			player.lifeRegen -= 20;
		Dust.NewDust(player.position, player.width, player.height, 110);
		Dust.NewDust(player.position, player.width, player.height, DustID.GoldCoin);
		Dust.NewDust(player.position, player.width, player.height, 206);


        }
    }
}