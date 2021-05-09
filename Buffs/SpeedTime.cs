
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CmdsMod.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class SpeedTime : ModBuff
	{
		public bool hasnormalitemtimed = false;
		public int normalitemtime = 0;
		public Item olditem;
		public Item item;
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sped Up in Time");
			Description.SetDefault("You are Sped up in space and time");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
			
		}
		public override void Update(Player player, ref int buffIndex)
		{
			item = player.HeldItem;
			if (hasnormalitemtimed == false && player.buffTime[buffIndex] > 1 || olditem != item)
            {
				hasnormalitemtimed = true;
				normalitemtime = player.itemTime;
            }
			player.moveSpeed *= 2;
			//player.meleeSpeed *= 2;
			player.jumpSpeedBoost *= 2;
			player.maxFallSpeed *= 2;
			player.stepSpeed *= 2;
			player.maxRunSpeed *= 2;
			
			if (player.buffTime[buffIndex] <= 1)
            {
				hasnormalitemtimed = false;
            }
			olditem = player.HeldItem;
		}

	}
}