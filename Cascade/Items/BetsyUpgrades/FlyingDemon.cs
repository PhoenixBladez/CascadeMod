using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.BetsyUpgrades
{
    public class FlyingDemon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rising Demon");
			Tooltip.SetDefault("'Unleashes the souls of the Demon'\nInflicts Shadowflame and Shadow Curse, reducing enemy defense");
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.LightPink;
        }
        public override void SetDefaults()
        {
            item.damage = 146;
            item.useTime = 22;
            item.useAnimation = 22;
            item.melee = true;            
            item.width = 52;              
            item.height = 52;             
            item.useStyle = 1;        
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 30, 0, 0);
            item.rare = 10;
            item.shootSpeed = 8;
            item.UseSound = SoundID.Item60;   
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("FlyingDemonProjectile");
        }
		public override void AddRecipes()
		{
		            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DD2SquireBetsySword, 1);
			            recipe.AddIngredient(null,"Malachite", 7);
						            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
			}
		
    }
}