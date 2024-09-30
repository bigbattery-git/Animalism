using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ShakingTheCarpet
{
    public class ShakingTheCarpetManager : MonoBehaviour
    {
        [SerializeField] private int targetPressCount;
        private int pressCount;
        public void IsClear()
        {
            if (pressCount == targetPressCount)
            {
                Clear();
            }
        }
        public void AddPressCount()
        {
            pressCount++;
        }
        private void Clear()
        {
            Debug.Log("Mission Clear");
        }
    }
}