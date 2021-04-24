using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace CmdsMod.Buffs
{
    public class AirSummon : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Summon Tornado");
            Description.SetDefault("Your Mini-Tornado will fight for you!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            CmdsPlayer modPlayer = player.GetModPlayer<CmdsPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summons.TornadoSummon>()] > 0)
            {
                modPlayer.summonAirMinion = true;
            }
            if (!modPlayer.summonAirMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}