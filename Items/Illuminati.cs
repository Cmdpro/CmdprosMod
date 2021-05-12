using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class Illuminati : ModItem
	{
		public Player selectedPlayer;
		public Vector2 OldMousePos;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Movement\nYou can move really fast with your right click");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 2;
			item.scale = 0f;
			//item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//item.shoot = ModContent.ProjectileType<Projectiles.CelestialBladeSolar>();
			//item.shoot = ModContent.ProjectileType<Projectiles.CelestialBladeVortex>();

			item.shootSpeed = 6;
			item.channel = true;
		}
		public override bool UseItem(Player player)
		{

			player.position = Main.MouseWorld;
			return base.UseItem(player);
		}
	}    
}