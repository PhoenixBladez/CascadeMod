using System;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cascade.Event;
using Microsoft.Xna.Framework;

namespace Cascade.NPCs
{
    public class GNPC : GlobalNPC
    {
	
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
			if (CascadeWorld.TheCascade)
            {
                maxSpawns = (int)(maxSpawns * 1.75f);
                spawnRate = (int)(spawnRate * 0.3f);
            }
		}
	}
}