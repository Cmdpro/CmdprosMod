using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CmdsMod;

namespace CmdsMod.Items
{
	//[AutoloadEquip(EquipType.Shoes)]
	public class ElementalBand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Band");
			Tooltip.SetDefault("Grants 30 more Max Mana, 30 more Max Life, and 1 more Max Minion Slot");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.accessory = true; // Makes this item an accessory.
			item.noUseGraphic = true;
			item.rare = ItemRarityID.Expert;
			item.value = Item.sellPrice(gold: 1); // Sets the item sell price to one gold coin.
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 30;
			player.statLifeMax2 += 30;
			player.maxMinions += 1;
		}
		

	}
}
