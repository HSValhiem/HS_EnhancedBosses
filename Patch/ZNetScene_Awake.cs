using HarmonyLib;
using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Data;

namespace HS_EnhancedBosses.Patch
{
    internal class ZNetScene_Awake
    {
        [HarmonyPatch(typeof(ZNetScene), "Awake")]
        [HarmonyPriority(Priority.Last)]
        public static class ZNetScene_Awake_Postfix
        {
            public static void Postfix(ZNetScene __instance)
            {
                if (ObjectDB_Awake.ObjectDB_Awake_Postfix.FejdObjectDB == null)
                {
                    Plugin.Log!.LogError("No fejd");
                    return;
                }

                ConfigManager.ParseJson();
                ObjectDB objectDB = ObjectDB_Awake.ObjectDB_Awake_Postfix.FejdObjectDB.GetComponent<ObjectDB>();

                LoadModdedAssets(__instance);
                
                SetupBosses(__instance, objectDB);
                Plugin.ReloadPrefabHolder();
            }


            private static void SetupBosses(ZNetScene instance, ObjectDB objectDB)
            {
                foreach (Boss boss in Plugin.bossList!)
                {
                    boss.SetupCustomAttacks(objectDB);
                    boss.SetupCharacter(instance);
                    boss.SetupLateCustomAttacks();
                    boss.AddToObjectDB(objectDB);
                    boss.AddCustomAttacksToPrefab();
                    boss.AddBossPrefab(instance);
                    Plugin.Log!.LogMessage("Added " + boss.customAttacks!.Count.ToString() + " custom attacks to " + boss.bossName + ".");
                }
            }

            private static void LoadModdedAssets(ZNetScene instance)
            {
                foreach (ExternalEntity entity in Plugin.externalEntities!)
                {
                    entity.Setup(instance);
                    entity.AddToPrefabs(instance);
                }
            }
        }
    }
}