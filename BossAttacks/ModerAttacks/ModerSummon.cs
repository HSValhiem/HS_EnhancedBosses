using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.AttachmentScripts;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.BossAttacks.ModerAttacks
{
    public class ModerSummon : SummonAttack
    {
        public ModerSummon()
        {
            name = "dragon_summon";
            baseName = "dragon_spit_shotgun";
            bossName = "Dragon";
            stopOriginalAttack = true;
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
