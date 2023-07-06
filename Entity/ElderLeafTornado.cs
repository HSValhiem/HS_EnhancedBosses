using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.AttachmentScripts;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class ElderLeafTornado : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
           
            entity = Plugin.Bundle!.LoadAsset<GameObject>("leaftornado.prefab").Clone("eb_leaftornado");
            entity.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            entity.AddComponent<ZNetView>();
            entity.AddComponent<ZSyncTransform>();

            TimedDestruction timedDestruction = entity.AddComponent<TimedDestruction>();
            timedDestruction.m_triggerOnAwake = true;
            timedDestruction.m_timeout = 20.0f;
        }
    }
}
