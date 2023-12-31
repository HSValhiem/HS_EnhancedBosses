﻿using HS_EnhancedBosses.Abstract;
using HS_EnhancedBosses.AttachmentScripts;
using HS_EnhancedBosses.Data;
using UnityEngine;

namespace HS_EnhancedBosses.Entity
{
    public class EikthyrThunderProjectile : ExternalEntity
    {
        public override void Setup(ZNetScene zNetScene)
        {
            base.Setup(zNetScene);
            entity = Plugin.Bundle!.LoadAsset<GameObject>("ThunderProjectile.prefab").Clone("eb_thunderprojectile");
            entity.transform.localScale *= 0.5f;

            GameObject lightning = zNetScene.GetPrefab("fx_Lightning").Clone("eb_fx_lightning");
            lightning.transform.Find("sfx").parent = entity.transform;
            entity.transform.Find("sfx").position = entity.transform.position;

            AudioSource audio = entity.GetComponent<AudioSource>();
            Object.Destroy(audio);            

            entity.AddComponent<ZNetView>();
            entity.AddComponent<ZSyncTransform>();
            entity.AddComponent<ThunderProjectile>();

            Rigidbody rb = entity.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }
}
