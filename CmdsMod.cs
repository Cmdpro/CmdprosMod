using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CmdsMod;
using CmdsMod.NPCs;
using CmdsMod.Items;

namespace CmdsMod
{
	public class CmdsMod : Mod
	{
        
        public override void Load()
        {
            int[] BossList = {ModContent.NPCType<ElementalGuardian>()};
            //We want to give it a second boss head icon, so we register one
            string texture = NPCLoader.GetNPC(BossList[0]).BossHeadTexture + "_SecondStage"; //Our texture is called "ClassName_Head_Boss_SecondStage"
            this.AddBossHeadTexture(texture, -1); //-1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
            ElementalGuardian.secondStageHeadSlot = ModContent.GetModBossHeadSlot(texture);

        }
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call("AddBoss", 5.7f, ModContent.NPCType<NPCs.ElementalGuardian>(), this, "Elemental Guardian", (Func<bool>)(() => CmdsWorld.downedElementalGuardian), ModContent.ItemType<Items.ElementalBeacon>(), new List<int> { }, new List<int> {ModContent.ItemType<Items.ElementalShooter>() }, "Use a [i:" + ModContent.ItemType<Items.ElementalBeacon>() + "] to summon", "The Elemental Guardian protects the elementals from harm,\n By using an Elemental Beacon you are harming the elements,\nWhich causes him to come", "CmdsMod/NPCs/ElementalGuardianBossCL", "CmdsMod/NPCs/ElementalGuardianHeadCL");
				// Additional bosses here
			}
		}
	}
}