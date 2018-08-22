using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.Malachite
{
    public class MalachiteScythe : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Malachite Harvester");
			Tooltip.SetDefault("Attacks may grant the player 'Malachite Burst,' increasing damage by 10%\nCritical hits steal life");
		}


        public override void SetDefaults()
        {
            item.damage = 143;
            item.useTime = 17;
            item.useAnimation = 17;
            item.melee = true;            
            item.width = 42;              
            item.height = 42;             
            item.useStyle = 1;       
			item.crit += 4;
            item.knockBack = 8;
            item.value = Terraria.Item.sellPrice(0, 12, 0, 0);
            item.rare = 10;
            item.shootSpeed = 10;
            item.UseSound = SoundID.Item71;   
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("MalachiteScythe");
        }
						public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
			{
				if(crit)
				{
					player.statLife += 5;
					player.HealEffect(5);
				}
				if(Main.rand.Next(7) == 1)
				{
					player.AddBuff(mod.BuffType("MalachiteBurst"), 240);
				}
			}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Malachite", 23);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}