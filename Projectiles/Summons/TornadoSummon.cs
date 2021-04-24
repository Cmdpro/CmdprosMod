using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace CmdsMod.Projectiles.Summons
{
    public class TornadoSummon : MinionAI
    {
        public bool OnGround = false;
        public override void SetStaticDefaults()
        {
            //Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.minion = true; // This is true if the Projectile is a minion
            projectile.minionSlots = 1; // How many minion slots are taken up. 
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            //projectile.damage = 15;
        }

        public override void Behaviour()
        {
            if (projectile.tileCollide == false)
            {
                projectile.position.Y += 2;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.velocity = new Microsoft.Xna.Framework.Vector2(target.velocity.X, -15);
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            CmdsPlayer tutorialPlayer = player.GetModPlayer<CmdsPlayer>();
            if (player.dead)
            {
                tutorialPlayer.summonAirMinion = false;
            }
            if (tutorialPlayer.summonAirMinion)
            {
                projectile.timeLeft = 2;
            }
        }


    }
}