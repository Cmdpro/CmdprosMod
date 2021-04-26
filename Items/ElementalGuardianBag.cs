using CmdsMod.Items;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CmdsMod.NPCs;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace CmdsMod.Items
{
	public class ElementalGuardianBag : ModItem
	{
		private int ElementalBarCount = 0;
		private System.Random rand = new System.Random();
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Cyan;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{

			player.TryGettingDevArmor();
			if (Main.rand.NextBool(7))
			{
				//player.QuickSpawnItem(ModContent.ItemType<AbominationMask>());
			}
			player.QuickSpawnItem(Main.rand.Next(new int[] { ModContent.ItemType<FireStaff>(), ModContent.ItemType<WaterBow>(), ModContent.ItemType<EarthSword>(), ModContent.ItemType<Minions.AirMItem>() }));
			ElementalBarCount = rand.Next(25, 40);
			player.QuickSpawnItem(ModContent.ItemType<ElementalBar>(), ElementalBarCount);
		}
		

		public override int BossBagNPC => ModContent.NPCType<ElementalGuardian>();
	}
}