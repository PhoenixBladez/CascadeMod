using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.Malachite
{
    public class MalachiteStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Malachite Consumer");
			Tooltip.SetDefault("Summons a malachite portal that shoots beams at nearby foes\nLasts for 30 seconds before disspating\nOnly one portal can exist at once\nTakes up one minion slot");
		}


        public override void SetDefaults()
        {
            item.damage = 100;
            item.useTime = 11;
            item.useAnimation = 11;
            item.summon = true;            
            item.width = 42;              
            item.height = 42;             
            item.useStyle = 1;    
			item.mana = 40;    
            item.knockBack = 6;
			item.noMelee = true;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.shootSpeed = 1;
            item.UseSound = SoundID.Item66;   
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("MalachitePortal");
        }
			
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//remove any other owned SpiritBow projectiles, just like any other sentry minion
			for(int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == item.shoot && p.owner == player.whoAmI) 
				{
					p.active = false;
				}
			}
			return true;
        
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Malachite", 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}