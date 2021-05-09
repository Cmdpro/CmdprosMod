using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class Illuminati2 : ModItem
	{
		public NPC selectedEntity;
		public Vector2 OldMousePos;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illuminati"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Harm\nYou can damage all entities around you with your left click");
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
			for (int i = 0; i <= Main.maxNPCs; i++)
			{
				if (player.position.X - Main.npc[i].position.X <= 600 && player.position.X - Main.npc[i].position.X >= -600 && player.position.Y - Main.npc[i].position.Y <= 600 && player.position.Y - Main.npc[i].position.Y >= -600)
				{
					int olddef = Main.npc[i].defense;
					Main.npc[i].defense = 0;
					Main.npc[i].StrikeNPC(Main.npc[i].lifeMax / 500, 0, 0, false, true, true);
					Main.npc[i].defense = olddef;
				}
			}
			return base.UseItem(player);
        }
        public override void HoldItem(Player player)
        {
			
			if (player.channel == false)
            {
				selectedEntity = null;
            }
        }
    }
}