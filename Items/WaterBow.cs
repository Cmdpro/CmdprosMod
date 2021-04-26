using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CmdsMod;
using Terraria.DataStructures;

namespace CmdsMod.Items
{
	public class WaterBow : ModItem
	{
		public override void SetStaticDefaults() 
		{ 
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("How is this not falling apart?");

		}
		public override void SetDefaults() 
		{
			item.damage = 30;
			//item.magic = true;
			item.ranged = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 25;
			//item.mana = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.scale = 1.5f;
			item.useAmmo = AmmoID.Arrow;
			
			//item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.WaterArrow>();
			//item.shoot = ModContent.ProjectileType<Projectiles.CelestialBladeVortex>();
			
			item.shootSpeed = 6;
		}

		public override void AddRecipes() 
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.FragmentSolar, 5);
			//recipe.AddIngredient(ItemID.FragmentNebula, 5);
			//recipe.AddIngredient(ItemID.FragmentStardust, 5);
			//recipe.AddIngredient(ItemID.FragmentVortex, 5);
			//recipe.AddIngredient(ItemID.LunarBar, 10);
			//recipe.AddTile(TileID.LunarCraftingStation);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			//type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<Projectiles.PWaterDagger>(), ModContent.ProjectileType<Projectiles.PFireDagger>(), ModContent.ProjectileType<Projectiles.PAirDagger>(), ModContent.ProjectileType<Projectiles.PEarthDagger>() });
			item.shoot = ModContent.ProjectileType<Projectiles.WaterArrow>();
			//item.shoot = type;
			return true;
		}
		
	}
}