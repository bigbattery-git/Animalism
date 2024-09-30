using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SprayingWater
{
    public class SprayWaterManager : OVMissionOrigin
    {
        [SerializeField] WetFloorFlower[] wetFloorFlowers;
        [SerializeField] WaterCan watercan;

        public void CheckClear()
        {
            foreach(var w in wetFloorFlowers)
            {
                if (!w.IsGrowwed(0)) return;
            }

            watercan.canMove = false;
            MissionClear();
        }
    }
}