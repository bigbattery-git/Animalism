using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.WindowCleaning
{
    public class WindowCleaningController : OVMissionOrigin
    {
        public override void MissionClear()
        {
            base.MissionClear();
            GetComponentInChildren<WindowCleaningManager>().isClear = true;
        }
    }
}

