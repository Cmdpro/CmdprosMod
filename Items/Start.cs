using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class Start : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Your Sus");
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
			item.consumable = false;
			item.maxStack = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ruby, 64);
			recipe.AddIngredient(ItemID.SoulofSight, 100);
			recipe.AddIngredient(ItemID.Diamond, 64);
			recipe.AddIngredient(ItemID.SoulofNight, 100);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool CanUseItem(Player player)
		{
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Sus>());
		}
		public override bool UseItem(Player player)
		{
			Main.PlaySound(SoundID.Roar, player.Center, 0);
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Sus>());
			return true;
		}
		public override void OnConsumeItem(Player player)
		{


		}
	}
}