using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class CorruptedCell : ModItem
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

			item.value = 10000;
			item.rare = 2;
			item.scale = 2f;
			item.consumable = true;
			item.maxStack = 30;
		}

		public override bool UseItem(Player player)
		{
				Main.PlaySound(SoundID.Roar, player.Center, 0);
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.CorruptionWatcher>());
			return true;

		}
        public override bool CanUseItem(Player player)
        {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.CorruptionWatcher>()) && player.ZoneCorrupt;
		}
		public override void AddRecipes()
		{

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
			recipe.AddIngredient(ItemID.DemoniteBar, 26);
			recipe.AddIngredient(ItemID.RottenChunk, 7);
			recipe.AddIngredient(ItemID.VilePowder, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}