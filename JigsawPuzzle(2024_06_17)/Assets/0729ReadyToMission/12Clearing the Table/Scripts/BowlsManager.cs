using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClearingTheTable
{
    public class BowlsManager : MonoBehaviour
    {
        [SerializeField] private ClearingTheTableManager manager;

        public ClearingTheTableManager Manager => manager;
        private void OnEnable()
        {
            for(int i = 0; i< transform.childCount; i++)
            {
                GameObject gameObject = transform.GetChild(i).gameObject;

                if (!gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(true);
                }
            }
        }

        public void CheckBowlClear()
        {
            for(int i = 0; i< transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeInHierarchy)
                    return;
            }
            manager.SetState(CleanTableMissionState.CleanTable);
        }
    }
}