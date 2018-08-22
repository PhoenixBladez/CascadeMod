using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Cascade.Items.Malachite
{
    public class MalachiteSword : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Malachite Blade");
			Tooltip.SetDefault("Summons a guarding aura that nullifies minor projectiles\nProjectiles that deal 100 damage or less will be nullified, and will be converted into malachite bolts");
		}


        public override void SetDefaults()
        {
            item.damage = 136;
            item.useTime = 9;
            item.useAnimation = 9;
            item.melee = true;            
            item.width = 42;              
            item.height = 42;             
            item.useStyle = 1;        
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.shootSpeed = 1;
            item.UseSound = SoundID.Item60;   
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("MalachiteWave");
        }
			
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
                      Projectile.NewProjectile(position.X , position.Y , speedX, speedY, mod.ProjectileType("MalachiteWave1"), damage, knockBack, player.whoAmI, 0f, 0f);
       				
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Malachite", 21);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}