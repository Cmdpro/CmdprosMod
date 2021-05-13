
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CmdsMod.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class Warp : ModBuff
	{
		public bool hasnormalitemtimed = false;
		public int normalitemtime = 0;
		public bool ran = false;
		public Item olditem;
		public Item item;
		public Vector2 oldplrsize;
		public int oldheight;
		public Rectangle oldhitbox;
		public bool click;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Warping");
			Description.SetDefault("You can Warp to your mouse cursor");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;

		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (!Main.mouseRightRelease && click == false)
            {
				player.Teleport(Main.MouseWorld);
				click = true;
            }
			if (Main.mouseRightRelease == true)
            {
				click = false;
            }
		}
		

	}
}