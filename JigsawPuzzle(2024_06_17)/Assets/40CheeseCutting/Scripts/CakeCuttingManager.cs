using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CakeCutting
{
    public class CakeCuttingManager : OVMissionOrigin
    {
        [Header("====================== Mission Data ======================")]
        [SerializeField] private float[] turnSpeeds;

        public float[] TurnSpeeds => turnSpeeds;
    }
}

