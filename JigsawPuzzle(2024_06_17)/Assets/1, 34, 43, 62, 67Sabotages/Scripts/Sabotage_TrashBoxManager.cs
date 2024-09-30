using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.Sabotage_Trashbox
{
    public class Sabotage_TrashBoxManager : MonoBehaviour
    {
        private OVMissionOrigin origin;
        public void Clear()
        {
            origin.MissionClear();
        }
        public void SetOrigin(OVMissionOrigin _origin)
        {
            origin = _origin;
        }
    }
}

