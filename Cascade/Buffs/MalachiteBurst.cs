using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Buffs
{
    public class MalachiteBurst : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Malachite Burst");
            Description.SetDefault("Increases damage by 10%");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
player.meleeDamage += 0.1f;
player.magicDamage += 0.1f;
player.rangedDamage += 0.1f;
player.thrownDamage += 0.1f;
player.minionDamage += 0.1f;

  Dust.NewDust(player.position, player.width, player.height, 110);


        }
    }
}