using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Abstract
{
    public abstract class ExternalEntity
    {
        public virtual void Setup(ZNetScene zNetScene)
        {
            if (zNetScene == null)
            {
                Plugin.Log!.LogError("No ZNetScene found.");
            }
        }

        public void AddToPrefabs(ZNetScene zNetScene)
        {
            if (zNetScene == null)
            {
                Plugin.Log!.LogError("ZNetScene not found. Skipping adding item.");
                return;
            }
            if (entity == null)
            {
                Plugin.Log!.LogError("No entity found to load.");
                return;
            }
            zNetScene!.AddCustomPrefab(entity);
        }

        public GameObject? entity;
    }
}
