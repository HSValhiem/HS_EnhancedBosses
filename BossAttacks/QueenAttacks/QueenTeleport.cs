using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.QueenAttacks
{
    public class QueenTeleport : CustomAttack
    {
        public QueenTeleport()
        {
            name = "SeekerQueen_Teleport";
            baseName = "SeekerQueen_Teleport";
            bossName = "SeekerQueen";
            stopOriginalAttack = false;
        }
    }
}
