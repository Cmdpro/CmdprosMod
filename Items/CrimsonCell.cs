using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class CrimsonCell : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Use to summon Crimson Watcher");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.scale = 1.5f;
			item.consumable = true;
			item.maxStack = 30;
			item.scale = 2;
		}

		public override bool UseItem(Player player)
		{
			Main.PlaySound(SoundID.Roar, player.Center, 0);
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.CrimsonWatcher>());
			return true;

		}
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.CrimsonWatcher>()) && player.ZoneCrimson;
		}
	}
}