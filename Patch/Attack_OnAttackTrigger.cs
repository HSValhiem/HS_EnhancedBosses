using HS_EnhancedBosses.Data;
using HarmonyLib;
using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.Patch
{
    internal class Attack_OnAttackTrigger
    {
        [HarmonyPatch(typeof(Attack), "OnAttackTrigger")]
        public static class Attack_OnAttackTrigger_Prefix
        {
            public static bool Prefix(Attack __instance)
            {
                Character character = __instance.m_character;
                Boss? boss = character.GetBoss();
                bool flag = boss != null;
                return !flag || boss!.Process_Attack(__instance);
            }
        }
    }
}
