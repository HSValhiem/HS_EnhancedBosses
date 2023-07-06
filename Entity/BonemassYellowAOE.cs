using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class BonemassYellowAOE : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
            entity = zNetScene.GetPrefab("bonemass_aoe").Clone("eb_bonemass_aoe_yellow");
            entity.transform.SetParent(Plugin.Holder!.transform, false);
            entity.ApplyTint(Color.yellow);
            entity.transform.localScale *= 1.3f;
        }
    }
}
