using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.ElderAttacks
{
    public class ElderStomp : CustomAttack
    {
        public ElderStomp()
        {
            name = "gd_king_stomp";
            baseName = "gd_king_stomp";
            bossName = "gd_king";
            stopOriginalAttack = false;
        }

        public override void AdjustAttackParameters()
        {
            itemDrop!.m_itemData.m_shared.m_aiPrioritized = false;
        }
    }
}
