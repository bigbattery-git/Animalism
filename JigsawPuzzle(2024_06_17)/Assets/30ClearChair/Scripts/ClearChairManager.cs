using Missons.Village.WindowCleaning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClearChair
{
    
    public class ClearChairManager : OVMissionOrigin
    {
        public bool IsClear { get; set; }
        public int ClearCount => clearCount;


        [Header("Mission Context")]
        [SerializeField] private int clearCount;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            IsClear = false;
        }
        public override void MissionClear()
        {
            base.MissionClear();
            IsClear = true;
        }
    }
}

