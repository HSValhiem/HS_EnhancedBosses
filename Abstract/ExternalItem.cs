using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Abstract
{
    public abstract class ExternalItem
    {
        public virtual void Setup(ObjectDB objectDB)
        {
            if (objectDB == null)
            {
                Plugin.Log!.LogError("No objectDB found.");
            }
        }

        public void AddToObjectDB(ObjectDB objectDB)
        {
            if (objectDB == null)
            {
                Plugin.Log!.LogError("objectDB not found. Skipping adding item.");
                return;
            }
            if (item == null)
            {
                Plugin.Log!.LogError("No entity found to load.");
                return;
            }
            objectDB.AddCustomAttack(item);
        }

        public GameObject? item;
        public static string? name;
    }
}
