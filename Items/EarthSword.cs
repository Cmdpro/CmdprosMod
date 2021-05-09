using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class EarthSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 20;
			item.value = 10000;
			item.rare = 2;
			item.scale = 2f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//item.shoot = ModContent.ProjectileType<Projectiles.CelestialBladeSolar>();
			//item.shoot = ModContent.ProjectileType<Projectiles.CelestialBladeVortex>();

			item.shootSpeed = 6;
		}




    }
}