using System;
using HS_EnhancedBosses.Abstract;
using UnityEngine;

namespace HS_EnhancedBosses.Data
{
    internal class PinManager
    {
        public static Minimap.PinData AddBossPin(Vector3 pos)
        {
            Minimap.PinData pinData = new Minimap.PinData
            {
                m_type = BossPinType,
                m_icon = BossPinSprite,
                m_name = "",
                m_pos = pos,
                m_save = false,
                m_checked = false,
                m_ownerID = 0L
            };
            Minimap.instance.m_pins.Add(pinData);
            return pinData;
        }

        public static void CheckBossPins()
        {
            for (int i = Plugin.pinsList.Count - 1; i >= 0; i--)
            {
                Boss boss = Plugin.pinsList[i];
                bool flag = boss.character != null;
                if (flag)
                {
                    boss.UpdatePosition();
                }
                else
                {
                    boss.OnDeath();
                    Plugin.pinsList.RemoveAt(i);
                }
            }
        }

        public static Minimap.PinType BossPinType = Minimap.PinType.Boss;
        public static Sprite BossPinSprite = Minimap.instance.GetSprite(Minimap.PinType.Boss);
    }
}
