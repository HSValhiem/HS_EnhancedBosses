using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenCall : CustomAttack
    {
        public QueenCall()
        {
            name = "SeekerQueen_Call";
            baseName = "SeekerQueen_Call";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
