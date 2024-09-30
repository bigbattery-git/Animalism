using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.BreakCoal
{
    public class BreakCoalManager : OVMissionOrigin
    {
        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private RectTransform coalTransform;
        [SerializeField] private RectTransform brokenCoalTransform;

        [SerializeField] private Coal coal;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            coal.gameObject.SetActive(true);

            Cursor.visible = false;
        }

        public override void Hide()
        {
            base.Hide();

            Cursor.visible = true;
        }
    }
}