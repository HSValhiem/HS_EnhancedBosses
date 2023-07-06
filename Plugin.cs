using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HS_EnhancedBosses.StatusEffects;
using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Data;

namespace HS_EnhancedBosses;

[BepInPlugin(GUID, PluginName, PluginVersion)]
[BepInDependency("castix_ValheimFPSBoost", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("org.bepinex.plugins.creaturelevelcontrol", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BaseUnityPlugin
{

    public const string GUID = "hs.enhancedbosses";
    public const string PluginName = "HS_EnhancedBosses";
    public const string PluginVersion = "1.10.4";
    private static Plugin? instance;

    public AssetBundle? assetBundle;
    public static Harmony harmony = new (GUID);
    public static readonly string? ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    public static AssetBundle? Bundle;

    public static List<Boss>? bossList;
    public static List<ExternalEntity>? externalEntities;
    public static List<ExternalItem>? externalItems;

    public static List<StatusEffect> statusEffects = new ()
    {
        //ScriptableObject.CreateInstance<SE_BaseShield>(),
        //ScriptableObject.CreateInstance<SE_Slow>(),
        //ScriptableObject.CreateInstance<SE_Trip>()
    };

    public static GameObject? Holder;
    public static List<Boss> pinsList = new ();
    public static ManualLogSource? Log;

    public class ItemInfo
    {
        public bool Enabled { get; set; }
        public int Cooldown { get; set; }
        public bool DropItemsOnDespawn { get; set; }
        public int Stars { get; set; }
        public List<string>? Creatures { get; set; }
        public int maxMinionsCount { get; set; }
        public int extraMaxMinionsCountPerPlayer { get; set; }
        public int spawnMinionsCount { get; set; }
        public int extraSpawnMinionsCountPerPlayer { get; set; }
        public int SummonMaxStars { get; set; }
        public float Heal { get; set; }
        public float HpThreshold { get; set; }
        public float AttackSpeedUpMultiplier { get; set; }
        public float AttackCoolDownMultiplier { get; set; }
        public int MinDistance { get; set; }
        public int MaxDistance { get; set; }
        public float ShieldHp { get; set; }
        public float ShieldDuration { get; set; }
    }

    /**
	 * Load mod properties.
	 */
    public void Awake()
    {
        Log = Logger;
        instance = this;
        bool configLoaded = ConfigManager.CreateConfigValues(this);
        if (!configLoaded)
        {
            Plugin.Log.LogInfo("This mod has been disabled from load due to incorrect configurations.");
            Destroy(this);
            return;
        }

        ReloadPrefabHolder();
        Bundle = Helpers.LoadAssetBundleFromResources("ebr_assetbundle");

        GetBosses();
        GetExternalEntities();
        GetExternalAttacks();

        Harmony harmony = Plugin.harmony;
        if (harmony != null)
        {
            harmony.PatchAll();
        }
    }


    /**
	 * Return the instance.
	 */
    public static Plugin GetInstance()
    {
        return instance!;
    }

    /**
	 * Reloads the prefabs holder.
	 */
    public static void ReloadPrefabHolder()
    {
        if (Holder != null)
        {
            Holder = null;
        }

        Holder = new GameObject("Prefabs");
        Holder.SetActive(false);
        DontDestroyOnLoad(Holder);
    }

    /**
	 * Adds all boss data from Bosses folder.
	 */
    private static void GetBosses()
    {
        List<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => (t.IsClass && t.ToString().StartsWith("HS_EnhancedBosses.Bosses") && !t.ToString().Contains("+<"))).ToList();
        bossList = new List<Boss>();

        foreach (Type type in types)
        {
            bossList.Add((Activator.CreateInstance(type) as Boss)!);
        }
    }

    /**
	 * Adds all external entity data from Entities folder.
	 */
    private static void GetExternalEntities()
    {
        List<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => (t.IsClass && t.ToString().StartsWith("HS_EnhancedBosses.Entity") && !t.ToString().Contains("+<") && t != null)).ToList();
        externalEntities = new List<ExternalEntity>();
        foreach (Type type in types)
        {
            externalEntities.Add((Activator.CreateInstance(type) as ExternalEntity)!);
        }
    }

    /**
	 * Adds all extrnal attacks in the Items folder.
	 */
    private static void GetExternalAttacks()
    {
        List<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => (t.IsClass && t.ToString().StartsWith("HS_EnhancedBosses.Item") && !t.ToString().Contains("+<") && t != null)).ToList();
        externalItems = new List<ExternalItem>();
        foreach (Type type in types)
        {
            externalItems.Add((Activator.CreateInstance(type) as ExternalItem)!);
        }
    }
}

