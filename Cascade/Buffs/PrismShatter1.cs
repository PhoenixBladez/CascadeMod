using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Buffs
{
    public class PrismShatter1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Prism Shatter");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
  Dust.NewDust(npc.position, npc.width, npc.height, 110);
    Dust.NewDust(npc.position, npc.width, npc.height, 206);
	    Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
  npc.lifeRegen = 0;
    npc.lifeRegen -= 30;


        }
    }
}