using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenPierceAOE : CustomAttack
    {
        public QueenPierceAOE()
        {
            name = "SeekerQueen_PierceAOE";
            baseName = "SeekerQueen_PierceAOE";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
