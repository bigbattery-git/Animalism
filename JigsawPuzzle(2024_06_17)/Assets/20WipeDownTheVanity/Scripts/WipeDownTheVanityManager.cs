using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.WipeDownTheVanity
{
    public class WipeDownTheVanityManager : OVMissionOrigin
    {
        [Range(1, 50)]
        [SerializeField] private int clearCount;

        public int ClearCount => clearCount;
    }
}