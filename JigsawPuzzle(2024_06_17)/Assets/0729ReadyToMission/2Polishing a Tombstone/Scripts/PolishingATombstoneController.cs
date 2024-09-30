using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PolishingATombstone
{
    public class PolishingATombstoneController : OVMissionOrigin
    {
        public override void MissionClear()
        {
            base.MissionClear();
            GetComponentInChildren<PolishingATombstoneManager>().isClear = true;
        }
    }
}