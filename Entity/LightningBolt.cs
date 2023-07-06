using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class LightningBolt : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
            entity = zNetScene.GetPrefab("lightningAOE").Clone("eb_lightning");
            entity.transform.SetParent(Plugin.Holder!.transform, false);
            entity.ApplyTint(new Color(0.34f, 1.0f, 0.2f));

            Aoe[] aoes = entity.GetComponentsInChildren<Aoe>();
            foreach (Aoe aoe in aoes)
            {
                aoe!.m_damageSelf = 0.0f;
                aoe!.m_hitCharacters = false;
                aoe!.m_hitEnemy = false;
                aoe!.m_hitFriendly = false;
                aoe!.m_hitParent = false;
                aoe!.m_hitSame = false;
            }
        }
    }
}
