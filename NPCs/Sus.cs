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

namespace CmdsMod.NPCs
{
    [AutoloadBossHead]
    public class Sus : ModNPC
    {
        private Player player;
        private float speed;
        private int phase;
		private bool enraged;
        private bool allDmgEnraged;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sus");
            Main.npcFrameCount[npc.type] = 1;
            
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 666666; // The Max HP the boss has on Normal
            npc.damage = 666666; // The base damage value the boss has on Normal
            npc.defense = 99999; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 148;
            npc.height = 198;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true; // Will not collide with the tiles. 
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            speed = 500;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SusSong");
            npc.scale = 1;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            
        }

        public override void AI()
        {
            Target(); // Sets the Player Target

            DespawnHandler(); // Handles if the NPC should despawn.

            Move(new Vector2(0, -100f)); // Calls the Move Method
                                         //Attacking
            //if (phase == 2)
            //{
            //    npc.ai[2] -= 1f;
            //}
            /*
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.

            if (npc.ai[1] == 20 || npc.ai[1] == 45)
            {
                Shoot();
                if (phase == 2)
                {
                    Shoot();
                    Shoot();
                }
            }
            if (npc.ai[1] == 15 || npc.ai[1] == 40)
            {
                Shoot();
                if (phase == 2)
                {
                    Shoot();
                    Shoot();
                }
            }
            if (npc.ai[1] == 10 || npc.ai[1] == 35)
            {
                Shoot();
                if (phase == 2)
                {
                    Shoot();
                    Shoot();
                }
            }
            if (npc.ai[1] == 5 || npc.ai[1] == 30)
            {
                Shoot();
                if (phase == 2)
                {
                    Shoot();
                    Shoot();
                }
            }
            if (npc.ai[1] <= 1 && phase == 2)
            {
                Rain();
            }
            if (npc.ai[1] <= 0)
            {
                if (npc.ai[1] <= 0 && phase == 1)
                {
                    npc.ai[1] = 200f;
                }
                if (npc.ai[1] <= 0 && phase == 2)
                {
                    npc.ai[1] = 50f;
                }
            }
            */

        }

        private void Target()
        {
            player = Main.player[npc.target]; // This will get the player target.
            
        }

        private void Move(Vector2 offset)
        {
             // Sets the max speed of the npc.
            Vector2 moveTo = player.Center/* + offset*/; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 10f; // The larget the number the slower the npc will turn.
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }

        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
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
            int type = mod.ProjectileType("EarthDagger");
            if (npc.ai[1] == 20 || npc.ai[1] == 45)
            {
                type = mod.ProjectileType("EarthDagger");
            }
            if (npc.ai[1] == 15 || npc.ai[1] == 40)
            {
                type = mod.ProjectileType("AirDagger");
            }
            if (npc.ai[1] == 10 || npc.ai[1] == 35)
            {
                type = mod.ProjectileType("FireDagger");
            }
            if (npc.ai[1] == 5 || npc.ai[1] == 30)
            {
                type = mod.ProjectileType("WaterDagger");
            }

            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 5f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage, 2f);
            


        }
        private void Rain()
        {

            Vector2 velocity = new Vector2(0f, 0f); // Get the distance between target and npc.
            //float magnitude = Magnitude(velocity);
            velocity = new Vector2(0f, 5f);
            float yoffset = 200;
            Projectile.NewProjectile(new Vector2(player.position.X, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("FireDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X + 20, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("EarthDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X - 20, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("AirDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X + 40, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("FireDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X - 40, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("WaterDagger"), npc.damage, 2f);

            Projectile.NewProjectile(new Vector2(player.position.X + 10, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("EarthDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X - 10, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("AirDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X + 30, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("FireDagger"), npc.damage, 2f);
            Projectile.NewProjectile(new Vector2(player.position.X - 30, player.position.Y - yoffset), new Vector2(0f, 5f), mod.ProjectileType("WaterDagger"), npc.damage, 2f);

            if (npc.ai[2] <= 1)
            {
                npc.ai[2] = 200;
            }


        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            if (npc.life <= npc.lifeMax / 2)
            {
            }

            //RotateNPCToTarget();
        }

        private void RotateNPCToTarget()
        {
            if (player == null) return;
            Vector2 direction = npc.Center - player.Center;
            float rotation = (float)Math.Atan2(direction.Y, direction.X);
            npc.rotation = rotation + ((float)Math.PI * 0.5f);
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (Main.rand.Next(3) == 0) // For items that you want to have a chance to drop 
                {
                    //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireStaff"));
                }
                //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TutorialSummonItem")); // For Items that you want to always drop
            }

            // For settings if the boss has been downed
        }
        

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
            
        }
        

    }
}