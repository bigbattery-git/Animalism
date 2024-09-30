using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LostAndFound_Church
{
    public enum ClearType { Click, Drag }
    public class LostAndFound_AcquiredManager : OVMissionOrigin
    {
        [SerializeField] private ClearType clearType;

        public ClearType ClearType => clearType;

        [SerializeField] private Missing_Church missing;
        [SerializeField] private GameObject effect;
        public override void Awake()
        {
            base.Awake();

            missing.manager = this;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            effect.SetActive(false);
            ActiveMissing();
        }

        private void ActiveMissing()
        {
            missing.gameObject.SetActive(true);
        }

        public void EffectMissionClear(RectTransform _rect)
        {
            MissionClear();

            effect.SetActive(true);
            effect.GetComponent<RectTransform>().anchoredPosition = _rect.anchoredPosition;
        }
    }
}