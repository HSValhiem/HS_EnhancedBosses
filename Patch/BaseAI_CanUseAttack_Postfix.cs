using HS_EnhancedBosses.Data;
using HarmonyLib;
using HS_EnhancedBosses.Abstract;

namespace HS_EnhancedBosses.Patch
{
    internal class BaseAI_CanUseAttack
    {
        [HarmonyPatch(typeof(BaseAI), "CanUseAttack")]
        public static class BaseAI_CanUseAttack_Postfix
        {
            public static void Postfix(BaseAI __instance, ItemDrop.ItemData item, ref bool __result)
            {
                Boss? boss = __instance.GetBoss();
                if (boss != null && __result)
                {
                    __result = boss.CanUseAttack(item);
                }
            }
        }
    }
}
