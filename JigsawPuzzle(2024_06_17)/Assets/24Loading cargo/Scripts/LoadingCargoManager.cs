using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LoadingCargo
{
    public class LoadingCargoManager : OVMissionOrigin
    {
        [SerializeField] Transform cargoTransform;

        public bool IsClear()
        {
            for(int i = 0; i < cargoTransform.childCount; ++i)
            {
                if (cargoTransform.GetChild(i).gameObject.activeSelf == true)
                    return false;
            }
            MissionClear();
            return true;
        }
    }
}