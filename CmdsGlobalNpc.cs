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
    public class CmdsGlobalNpc : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(1) == 0)
            {
                if (npc.type == NPCID.Golem)
                {
                    
                }
                if (npc.type == NPCID.DungeonGuardian && IsMoving(npc.oldPosition, npc.position, 5))
                {
                    if (Main.rand.Next(0, 4) == 2)
                    {
                        int type = Main.rand.Next(new int[] { mod.ItemType("Illuminati"), mod.ItemType("Illuminati2"), mod.ItemType("Illuminati3") });
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, type, 1);
                    }
                    
                }

            }
        }
        public bool IsMoving(Vector2 Oldpos, Vector2 Newpos, float RequiredDistance)
        {
            bool moving = false;
            float distancex = Oldpos.X - Newpos.X;
            float distancey = Oldpos.Y - Newpos.Y;
            if (distancex > RequiredDistance || distancex < -RequiredDistance || distancey > RequiredDistance || distancey < -RequiredDistance)
            {
                moving = true;
            }
            return moving;
        }
    }
}