using CmdsMod.Projectiles.Summons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CmdsMod.Items
{
	public class AirStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Tornado Staff");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<TornadoSummon>();
			item.shootSpeed = 0f;
		}

	}
}