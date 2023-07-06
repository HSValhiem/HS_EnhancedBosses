using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.AttachmentScripts;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.BossAttacks.ModerAttacks
{
    public class ModerTaunt : SummonAttack
    {
        public ModerTaunt()
        {
            name = "dragon_taunt";
            baseName = "dragon_taunt";
            bossName = "Dragon";
            stopOriginalAttack = false;
        }

        public override void AdjustAttackParameters()
        {
            itemDrop!.m_itemData.m_shared.m_aiPrioritized = true;
            itemDrop!.m_itemData.m_shared.m_aiAttackRangeMin = 0;
        }

        public override void AssignParams(Character character, GameObject gameObject, out bool cancelSpawn)
        {
            base.AssignParams(character, gameObject, out cancelSpawn);
            if (ConfigManager.ModerSummonDieAfter!.Value > 0)
            {
                gameObject.AddComponent<ModerSummonScript>();
            }
        }
    }
}
