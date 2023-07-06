using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.AttachmentScripts;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class PoisonCloud : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
            entity = zNetScene.GetPrefab("blobtar_projectile_tarball").Clone("eb_poisoncloud");
            entity.transform.SetParent(Plugin.Holder!.transform, false);
            entity.ApplyTint(new Color(0.4f, 1.0f, 0.3f));

            HitData.DamageTypes damages = new HitData.DamageTypes();
            damages.m_poison = 50.0f;
            damages.m_blunt = 10.0f;

            Projectile projectile = entity.GetComponent<Projectile>();
            projectile.m_damage = damages;
            projectile.m_dodgeable = true;
            projectile.m_spawnOnHitChance = 0.0f;
        }
    }
}
