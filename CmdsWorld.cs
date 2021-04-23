using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace CmdsMod
{
	public class CmdsWorld : ModWorld
	{
        public static bool downedElementalGuardian = false; // Downed Tutorial Boss

        public override void Initialize()
        {
            downedElementalGuardian = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedElementalGuardian) downed.Add("elementalguardian");

            return new TagCompound
            {
                {"downed", downed }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedElementalGuardian = downed.Contains("elementalguardian");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedElementalGuardian = flags[0];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedElementalGuardian;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedElementalGuardian = flags[0];
        }


    }
}