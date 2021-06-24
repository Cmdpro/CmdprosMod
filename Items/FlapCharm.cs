using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CmdsMod;

namespace CmdsMod.Items
{
	//[AutoloadEquip(EquipType.Shoes)]
	public class FlapCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flap Charm");
			Tooltip.SetDefault("Click to flap");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.useTime = 0;
			item.useAnimation = 0;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.melee = false;
			item.noMelee = true;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.rare = ItemRarityID.Expert;
			item.value = Item.sellPrice(gold: 1); // Sets the item sell price to one gold coin.
		}

        public override bool UseItem(Player player)
        {
			player.velocity.Y = -12;
            return base.UseItem(player);
        }
		

	}
}
