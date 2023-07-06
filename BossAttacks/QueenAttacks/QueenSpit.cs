using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenSpit : CustomAttack
    {
        public QueenSpit()
        {
            name = "SeekerQueen_Spit";
            baseName = "SeekerQueen_Spit";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
