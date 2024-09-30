using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PolishingATombstone
{
    public class PolishingATombstoneManager : OVMissionOrigin
    {
        public bool isClear = false;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            isClear = false;
        }
        public override void MissionClear()
        {
            base.MissionClear();
            isClear = true;
        }
    }
}