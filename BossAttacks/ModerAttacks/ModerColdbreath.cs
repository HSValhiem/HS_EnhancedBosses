using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Bosses;
using HS_EnhancedBosses.Data;

namespace HS_EnhancedBosses.BossAttacks.ModerAttacks
{
    public class ModerColdbreath : CustomAttack
    {
        public ModerColdbreath()
        {
            name = "dragon_coldbreath";
            baseName = "dragon_coldbreath";
            bossName = "Dragon";
            stopOriginalAttack = false;
        }



        public override bool CanUseAttack(Character character, MonsterAI monsterAI)
        {
            Moder? moder = character.GetBoss() as Moder;
            if (moder == null)
            {
                return false;
            }

            return !moder.IsInAncientState() && base.CanUseAttack(character, monsterAI);
        }
    }
}
