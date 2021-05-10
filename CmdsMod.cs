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
				bossChecklist.Call("AddBoss", 11.1f, ModContent.NPCType<NPCs.CorruptionWatcher>(), this, "Corruption Watcher", (Func<bool>)(() => CmdsWorld.downedCorruptionWatcher), ModContent.ItemType<Items.CorruptedCell>(), "Use a [i:" + ModContent.ItemType<Items.CorruptedCell>() + "] to summon", "The Cell contains the chaos which is the Corruption Watcher", "CmdsMod/NPCs/CorruptionWatcher", "CmdsMod/NPCs/CorruptionWatcher_Head_Boss");
				bossChecklist.Call("AddBoss", 11.11f, ModContent.NPCType<NPCs.CrimsonWatcher>(), this, "Crimson Watcher", (Func<bool>)(() => CmdsWorld.downedCrimsonWatcher), ModContent.ItemType<Items.CrimtaneCell>(), new List<int> { }, new List<int> { ModContent.ItemType<Items.CrimtaneCell>() }, "Use a [i:" + ModContent.ItemType<Items.CrimtaneCell>() + "] to summon", "The Cell contains the chaos which is the Crimson Watcher", "CmdsMod/NPCs/CrimsonWatcher", "CmdsMod/NPCs/CrimsonWatcher_Head_Boss");
				bossChecklist.Call("AddBoss", 5.7f, ModContent.NPCType<NPCs.ElementalGuardian>(), this, "Elemental Guardian", (Func<bool>)(() => CmdsWorld.downedElementalGuardian), ModContent.ItemType<Items.ElementalBeacon>(), new List<int> { }, new List<int> {ModContent.ItemType<Items.ElementalShooter>() }, "Use a [i:" + ModContent.ItemType<Items.ElementalBeacon>() + "] to summon", "", "CmdsMod/NPCs/ElementalGuardianBossCL", "CmdsMod/NPCs/ElementalGuardianHeadCL");
				// Additional bosses here
			}
		}
		public override void Close()
		{
			// Fix a tModLoader bug.
			var slots = new int[] {
				GetSoundSlot(SoundType.Music, "Sounds/Music/ElementalGuardianMusic"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/EnragedElementalGuardianMusic"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/Evil1BossMusic"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/SusSong")
			};
			foreach (var slot in slots) // Other mods crashing during loading can leave Main.music in a weird state.
			{
				if (Main.music.IndexInRange(slot) && Main.music[slot]?.IsPlaying == true)
				{
					Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
				}
			}
			base.Close();
		}
	}
}