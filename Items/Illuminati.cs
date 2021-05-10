using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class Illuminati : ModItem
	{
		public NPC selectedEntity;
		public Projectile selectedProj;
		public Player selectedPlayer;
		public Vector2 OldMousePos;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Grab\nYou can move entities with your left click");
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
				if (Main.npc[i].Hitbox.Contains(Main.MouseWorld.ToPoint()))
				{
					selectedEntity = Main.npc[i];
				}
			}
			for (int i = 0; i <= Main.maxProjectiles; i++)
			{
				if (Main.item[i].Hitbox.Contains(Main.MouseWorld.ToPoint()))
				{
					selectedProj = Main.projectile[i];
				}
			}
			for (int i = 0; i <= Main.maxPlayers; i++)
			{
				if (Main.player[i].Hitbox.Contains(Main.MouseWorld.ToPoint()))
				{
					Main.player[i].position = Main.MouseWorld;
				}
			}
			if (selectedEntity != null)
			{
				selectedEntity.position = Main.MouseWorld;
				if (Main.netMode == Terraria.ID.NetmodeID.MultiplayerClient)
				{
					selectedEntity.netUpdate = true;
				}
			}
			if (selectedProj != null)
			{
				selectedProj.position = Main.MouseWorld;
				if (Main.netMode == Terraria.ID.NetmodeID.MultiplayerClient)
				{
					selectedProj.netUpdate = true;
				}
			}
			OldMousePos = Main.MouseWorld;
			return base.UseItem(player);
        }
        public override void HoldItem(Player player)
        {
			
			float fling = 6;
			if (player.channel == false)
            {
				if (selectedEntity != null)
				{
					selectedEntity.velocity = new Vector2(Main.MouseWorld.X / fling - OldMousePos.X / fling, Main.MouseWorld.Y / fling - OldMousePos.Y / fling);
					if (Main.netMode == Terraria.ID.NetmodeID.MultiplayerClient)
					{
						selectedEntity.netUpdate = true;
					}
					selectedEntity = null;
				}
				if (selectedProj != null)
				{
					selectedProj.velocity = new Vector2(Main.MouseWorld.X / fling - OldMousePos.X / fling, Main.MouseWorld.Y / fling - OldMousePos.Y / fling);
					if (Main.netMode == Terraria.ID.NetmodeID.MultiplayerClient)
					{
						selectedProj.netUpdate = true;
					}
					selectedProj = null;
				}
				//if (selectedPlayer != null)
				//{
				//	selectedPlayer.velocity = new Vector2(Main.MouseWorld.X / fling - OldMousePos.X / fling, Main.MouseWorld.Y / fling - OldMousePos.Y / fling);
				//	selectedPlayer.netUpdate = true;
				//	selectedPlayer = null;
				//}
			}
        }
    }
}