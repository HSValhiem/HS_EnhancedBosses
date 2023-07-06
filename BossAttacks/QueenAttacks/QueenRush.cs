using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenRush : CustomAttack
    {
        public QueenRush()
        {
            name = "SeekerQueen_Rush";
            baseName = "SeekerQueen_Rush";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
