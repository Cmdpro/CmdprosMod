using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using CmdsMod;


namespace CmdsMod.Items
{
	public class ElementalBeacon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("CelestialBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Use to summon Elemental Guardian");
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
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 32);
			recipe.AddIngredient(ItemID.WaterBucket, 1);
			recipe.AddIngredient(ItemID.Cloud, 32);
			recipe.AddIngredient(ItemID.LavaBucket, 1);
			recipe.AddIngredient(ItemID.IronBar, 16);
			recipe.AddIngredient(ItemID.Bone, 32);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe2.AddIngredient(ItemID.DirtBlock, 32);
			recipe2.AddIngredient(ItemID.WaterBucket, 1);
			recipe2.AddIngredient(ItemID.Cloud, 32);
			recipe2.AddIngredient(ItemID.LavaBucket, 1);
			recipe2.AddIngredient(ItemID.LeadBar, 16);
			recipe2.AddIngredient(ItemID.Bone, 32);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
		public override bool CanUseItem(Player player)
		{
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.ElementalGuardian>());
		}
		public override bool UseItem(Player player)
		{
			Main.PlaySound(SoundID.Roar, player.Center, 0);
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.ElementalGuardian>());
			return true;
		}
		public override void OnConsumeItem(Player player)
        {
			

		}
	}
}