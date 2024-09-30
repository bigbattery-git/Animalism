using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.weighing
{
    [System.Serializable]
    public class SackData
    {
        public Sprite sackSprite;

        public int minWeigh;
        public int maxWeigh;
    }
    [CreateAssetMenu (menuName = "Weighing Sack Data", fileName = "SackData_")]
    public class SackSO : ScriptableObject
    {
        public SackData[] sackDatas;
    }
}