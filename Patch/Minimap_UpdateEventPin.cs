using HarmonyLib;
using HS_EnhancedBosses.Data;

namespace HS_EnhancedBosses.Patch
{
    internal class Minimap_UpdateEventPin
    {
        [HarmonyPatch(typeof(Minimap), "UpdateEventPin")]
        public static class UpdateEventMobMinimapPinsPatch
        {
            public static void Postfix()
            {
                PinManager.CheckBossPins();
            }
        }
    }
}
