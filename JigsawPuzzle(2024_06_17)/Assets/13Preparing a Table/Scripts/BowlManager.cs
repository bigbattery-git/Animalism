using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PreparingATable
{
    public class BowlManager : MonoBehaviour
    {
        [SerializeField] private OVMissionOrigin origin;
        [SerializeField] private Bowl[] bowls;
        private void OnEnable()
        {
            for(int i = 0; i< bowls.Length; i++)
            {
                bowls[i].transform.SetSiblingIndex(i);
            }
        }

        public void CheckClear()
        {
            foreach(var bowl in bowls)
            {
                if (!bowl.IsInPlace())
                {
                    return;
                }
            }

            origin.MissionClear();
        }
    }
}