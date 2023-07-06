using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.AttachmentScripts;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class EikthyrThunderVortex : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
           
            entity = Plugin.Bundle!.LoadAsset<GameObject>("tornado.prefab").Clone("eb_thundervortex");
            entity.transform.localScale = new Vector3(5, 3, 5);
            entity.AddComponent<ZNetView>();
            entity.AddComponent<ZSyncTransform>();
            entity.AddComponent<Vortex>();

            ExtendedTimedDestruction timedDestruction = entity.AddComponent<ExtendedTimedDestruction>();
            timedDestruction.m_triggerOnAwake = true;
        }
    }
}
