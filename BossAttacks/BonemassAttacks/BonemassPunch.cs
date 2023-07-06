using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.BossAttacks.BonemassAttacks
{
    public class BonemassPunch : CustomAttack
    {
        public BonemassPunch()
        {
            name = "bonemass_attack_punch";
            baseName = "bonemass_attack_punch";
            bossName = "Bonemass";
            stopOriginalAttack = false;
        }
    }
}
