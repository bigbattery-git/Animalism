using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.FindJewel
{
    public class FindJewelController : OVMissionOrigin
    {
        public override void MissionClear()
        {
            base.MissionClear();

            GetComponentInChildren<FindJewelManager>().isClear = true;
        }
    }
}

