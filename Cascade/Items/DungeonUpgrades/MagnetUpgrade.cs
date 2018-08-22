using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.DungeonUpgrades
{
    public class MagnetUpgrade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Orbiter");
		}


        public override void SetDefaults()
        {
            item.damage = 99;
			item.magic = true;
			item.mana = 17;
			item.width = 56;
			item.height = 57;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 25, 50, 0);
            item.rare = 11;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MagnetProj");
			item.shootSpeed = 3f; 
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
            recipe.AddIngredient(ItemID.SpectreStaff, 1);
			            recipe.AddIngredient(null,"AstralPrism", 12);
						            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
      
    }
}