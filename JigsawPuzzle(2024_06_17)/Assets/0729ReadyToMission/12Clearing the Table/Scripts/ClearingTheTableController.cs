using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClearingTheTable
{
    public class ClearingTheTableController : OVMissionOrigin
    {
        public override void MissionClear()
        {
            base.MissionClear();
            GetComponentInChildren<ClearingTheTableManager>().State = CleanTableMissionState.Clear;
        }
    }
}