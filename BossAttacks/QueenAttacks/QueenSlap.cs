using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenSlap : CustomAttack
    {
        public QueenSlap()
        {
            name = "SeekerQueen_Slap";
            baseName = "SeekerQueen_Slap";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
