using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.ElderAttacks
{
    public class ElderScream : CustomAttack
    {
        public ElderScream()
        {
            name = "gd_king_scream";
            baseName = "gd_king_scream";
            bossName = "gd_king";
            stopOriginalAttack = false;
        }
    }
}
