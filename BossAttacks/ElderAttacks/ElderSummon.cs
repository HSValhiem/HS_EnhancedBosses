using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.ElderAttacks
{
    public class ElderSummon : SummonAttack
    {
        public ElderSummon()
        {
            name = "gd_king_summon";
            baseName = "gd_king_rootspawn";
            bossName = "gd_king";
            stopOriginalAttack = true;
        }
    }
}
