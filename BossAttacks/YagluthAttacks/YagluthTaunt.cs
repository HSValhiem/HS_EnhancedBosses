using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.YagluthAttacks
{
    public class YagluthTaunt : CustomAttack
    {
        public YagluthTaunt()
        {
            name = "GoblinKing_Taunt";
            baseName = "GoblinKing_Taunt";
            bossName = "GoblinKing";
            stopOriginalAttack = false;
        }
    }
}
