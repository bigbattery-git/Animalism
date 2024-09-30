using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ShakingOffAPillow
{
    public class ShakingOffAPillowManager : OVMissionOrigin
    {
        [SerializeField] private int targetPressCount;
        private int pressCount;

        public void AddPressCount()
        {
            pressCount++;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            pressCount = 0;
        }

        public bool IsClear()
        {
            bool isClear = pressCount >= targetPressCount;
            if (isClear)
            {
                MissionClear();
            }
            return isClear;
        }
    }
}