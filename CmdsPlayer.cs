using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace CmdsMod
{
    public class CmdsPlayer : ModPlayer
    {
        //public bool tutorialPet = false;
        public bool summonAirMinion = false;

        //public bool zoneBiome = false;

        public override void ResetEffects()
        {
        //    tutorialPet = false;
            summonAirMinion = false;
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            base.Hurt(pvp, quiet, damage, hitDirection, crit);
        }
        public override void SetupStartInventory(IList<Item> items)
        {
        ///    items.Clear();
        ///
        ///    Item item = new Item();
        ///    item.SetDefaults(mod.ItemType("TutorialWood"));
        ///    item.stack = 5;
        ///    items.Add(item);
        }

        public override void UpdateBiomes()
        {
        ///    zoneBiome = (TutorialWorld.biomeTiles > 50); // Chance 50 to the minimum number of tiles that need to be counted before it is classed as a biome
        }

        //public override bool CustomBiomesMatch(Player other)
       // {
        ///    TutorialPlayer otherPlayer = other.GetModPlayer<TutorialPlayer>(mod); // This will get other players using the TutorialPlayerClass
        ///    return zoneBiome == otherPlayer.zoneBiome; // This will return true or false depending on other player
       // }

        public override void CopyCustomBiomesTo(Player other)
        {
        ///    TutorialPlayer otherPlayer = other.GetModPlayer<TutorialPlayer>(mod);
        ///    otherPlayer.zoneBiome = zoneBiome; // This will set other player's biome to the same as thisPlayer
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
         ///   BitsByte flags = new BitsByte();
        ///    flags[0] = zoneBiome;
        ///    writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
        ///    BitsByte flags = reader.ReadByte();
        ///    zoneBiome = flags[0];
        }

        public override void UpdateBiomeVisuals()
        {

        }

        public override Texture2D GetMapBackgroundImage()
        {
            return null;
        }


    }
}