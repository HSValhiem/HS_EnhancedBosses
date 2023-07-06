using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class HotBreath : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
            entity = zNetScene.GetPrefab("vfx_dragon_coldbreath").Clone("eb_dragon_hotbreath");
            entity.transform.SetParent(Plugin.Holder!.transform, false);
            entity.ApplyTint(new Color(1.0f, 0.325f, 0.286f));
        }
    }
}
