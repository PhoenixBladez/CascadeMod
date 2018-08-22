using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cascade.Buffs
{
    public class ShadowCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shadow Curse");
            Description.SetDefault("Reduces defense by 55");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
  Dust.NewDust(npc.position, npc.width, npc.height, 173);
  npc.defense -= 55;


        }
    }
}