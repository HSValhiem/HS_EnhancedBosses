using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenBite : CustomAttack
    {
        public QueenBite()
        {
            name = "SeekerQueen_Bite";
            baseName = "SeekerQueen_Bite";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
