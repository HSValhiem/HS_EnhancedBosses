﻿using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Bosses;
using HS_EnhancedBosses.Data;
using System.Collections.Generic;

namespace HS_EnhancedBosses.BossAttacks.YagluthAttacks
{
    public class YagluthSummon : SummonAttack
    {
        public YagluthSummon()
        {
            name = "GoblinKing_Summon";
            baseName = "GoblinKing_Taunt";
            bossName = "GoblinKing";
            stopOriginalAttack = false;
            prefabs = new List<string>() { "vfx_ghost_death" };
        }

        public override bool CanUseAttack(Character character, MonsterAI monsterAI)
        {
            Yagluth? yagluth = character.GetBoss() as Yagluth;
            if (yagluth == null)
            {
                return false;
            }

            return !yagluth.IsInRockFormation() && base.CanUseAttack(character, monsterAI);
        }
    }
}
