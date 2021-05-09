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
using CmdsMod.Projectiles;
using CmdsMod.Items;

namespace CmdsMod.NPCs
{
    public class CorruptionShooter : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corruption Shooter");
            
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 10; // The Max HP the boss has on Normal
            npc.damage = 20; // The base damage value the boss has on Normal
            npc.defense = 99999; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 40;
            npc.height = 40;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = false; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true; // Will not collide with the tiles. 
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.ai[0] = 50;
            
            
        }


        public override void AI()
        {
            Target(); // Sets the Player Target
            DespawnHandler();

            npc.ai[0] -= 1;
            if (npc.ai[0] <= 0)
            {
                Shoot();
                npc.ai[0] = 50;
            }

        }

        private void Target()
        {
            player = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];

        }


        private void DespawnHandler()
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.CorruptionWatcher>()))
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.CorruptionWatcher>()))
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private void Shoot()
        {
            int type = ProjectileID.ShadowBeamHostile;
            System.Random rand = new System.Random();

            Vector2 velocity = new Vector2(player.Center.X - npc.Center.X - rand.Next(-50, 50), player.Center.Y - npc.Center.Y - rand.Next(-100, 100)); // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 5f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, 50, 2f);



        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        

    }
}