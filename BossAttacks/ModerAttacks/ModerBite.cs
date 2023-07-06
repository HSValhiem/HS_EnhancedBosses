using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.ModerAttacks
{
    public class ModerBite : CustomAttack
    {
        public ModerBite()
        {
            name = "dragon_bite";
            baseName = "dragon_bite";
            bossName = "Dragon";
            stopOriginalAttack = false;
        }
    }
}
