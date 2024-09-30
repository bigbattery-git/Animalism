using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SwipFloor
{
    public class SwipSwipManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] dusts; 
        private bool isCleard = false; 
        
        private void Update()
        {
            if (CheckClear() && !isCleard)
            {
                Debug.Log("Clear!");
                isCleard = true;
            }
        }
        private bool CheckClear()
        {
            for (int i = 0; i < dusts.Length; ++i)
            {
                if (dusts[i].activeSelf == true)
                    return false;
            }
            return true;
        }
    }
}
