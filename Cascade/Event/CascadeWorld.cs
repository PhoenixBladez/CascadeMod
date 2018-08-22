using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Cascade.Event
{
	public class CascadeWorld : ModWorld
	{
		public static int CascadePoints = 0;
		public static int CascadePoints2;
		public static int EnemyKills = 0;
		public static bool TheCascade;
		public override void Initialize() 
		{
			TheCascade = false;
			CascadePoints2 = 0;
		}
		public override void PostUpdate() 
		{
				CascadePoints = EnemyKills / 2;
			if (CascadePoints2 >= 80 || CascadePoints >= 80)
			{
			bool txt = false;
			if(!txt)
			{
				Main.NewText("The Cosmic Energies have dispersed.", 145, 0, 255);
				txt = true;
				}
				CascadePoints2 = 0;
				CascadePoints = 0;
				TheCascade = false;
			}
		}
		
	}
}