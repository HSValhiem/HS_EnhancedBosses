﻿using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Bosses;
using HS_EnhancedBosses.Data;

namespace HS_EnhancedBosses.BossAttacks.ModerAttacks
{
    public class ModerSpitShotgun : CustomAttack
    {
        public ModerSpitShotgun()
        {
            name = "dragon_spit_shotgun";
            baseName = "dragon_spit_shotgun";
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
