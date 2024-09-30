using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClearingTheTable
{
    public enum CleanTableMissionState { CleanBowl, CleanTable, Clear }
    public class ClearingTheTableManager : OVMissionOrigin
    {
        public CleanTableMissionState State = CleanTableMissionState.CleanBowl;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            State = CleanTableMissionState.CleanBowl;
        }
        public void SetState(CleanTableMissionState _state)
        {
            State = _state;
        }
    }
}