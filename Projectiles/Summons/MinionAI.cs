using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace CmdsMod.Projectiles.Summons
{
    public abstract class MinionAI : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
            Behaviour();
        }

        public abstract void CheckActive();

        public abstract void Behaviour();
    }
}