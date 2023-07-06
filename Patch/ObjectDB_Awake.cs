using HS_EnhancedBosses.Data;
using HarmonyLib;
using HS_EnhancedBosses.Abstract;
using UnityEngine;

namespace HS_EnhancedBosses.Patch
{
    internal class ObjectDB_WakeUp
    {
        [HarmonyPatch(typeof(ObjectDB), "Awake")]
        public static class ObjectDB_WakeUp_Postfix
        {
            public static void Postfix(ObjectDB __instance)
            {
                if (!ObjectDB_Awake.ObjectDB_Awake_Postfix.alreadyInvoked)
                {
                    return;
                }

                foreach (Boss boss in Plugin.bossList!)
                {
                    boss.AddToObjectDB(__instance);
                }

                foreach (ExternalItem item in Plugin.externalItems!)
                {
                    item.AddToObjectDB(__instance);
                }
            }
        }
    }


    internal class ObjectDB_Awake
    {
        [HarmonyPatch(typeof(FejdStartup), "SetupObjectDB")]
        [HarmonyPriority(800)]
        public static class ObjectDB_Awake_Postfix
        {
            public static void Postfix(FejdStartup __instance)
            {

                if (__instance == null)
                {
                    Plugin.Log!.LogError("ObjectDB not found. Cannot load custom items.");
                    return;
                }

                if (alreadyInvoked)
                {
                    Plugin.Log!.LogInfo("Already invoked item loading. Skipping");
                    return;
                }

                FejdObjectDB = __instance.m_objectDBPrefab;
                ObjectDB component = FejdObjectDB.GetComponent<ObjectDB>();

                Plugin.Log!.LogMessage("Setting up external attacks.");
                SetupExternalAttacks(component);
                Plugin.Log!.LogMessage("External attacks created successfully.");
                Plugin.Log!.LogMessage("Setting up custom status effects...");
                SetupStatusEffects(component);
                Plugin.Log!.LogMessage("Done.");
                alreadyInvoked = true;
            }

            private static void SetupExternalAttacks(ObjectDB instance)
            {
                foreach (ExternalItem attack in Plugin.externalItems!)
                {
                    attack.Setup(instance);
                    attack.AddToObjectDB(instance);
                }
            }

            private static void SetupStatusEffects(ObjectDB instance)
            {
                foreach (StatusEffect effect in Plugin.statusEffects)
                {
                    instance.AddStatusEffect(effect);
                }
            }

            public static GameObject? FejdObjectDB;
            public static bool alreadyInvoked;
        }
    }
}
