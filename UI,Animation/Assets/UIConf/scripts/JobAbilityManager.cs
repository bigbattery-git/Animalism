using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeatingRoom.Village
{
    public class JobAbilityManager : MonoBehaviour
    {
        private int activeJobListNumber = 0;
        private GameObject[] jobLists;

        [SerializeField]
        private GameObject jobList;
        private void Awake()
        {
            jobLists = new GameObject[jobList.transform.childCount];
            AddJobList();
            Init();
        }
        private void AddJobList()
        {
            for(int i = 0; i<jobLists.Length; ++i)
            {
                jobLists[i] = jobList.transform.GetChild(i).gameObject;
            }
        }
        private void Init()
        {
            for (int i = 0; i < jobLists.Length; ++i)
            {
                if (i == activeJobListNumber)
                {
                    jobLists[i].SetActive(true);
                    continue;
                }
                jobLists[i].SetActive(false);
            }
        }
        public void TurnRightJobList()
        {
            int maxJobList = jobLists.Length - 1;
            if(activeJobListNumber == maxJobList)
            {
                activeJobListNumber = 0;
            }
            else
            {
                activeJobListNumber++;
            }
            Init();
        }
        public void TurnLeftJobList()
        {
            int maxJobList = jobLists.Length - 1;
            if (activeJobListNumber == 0)
            {
                activeJobListNumber = maxJobList;
            }
            else
            {
                activeJobListNumber--;
            }
            Init();
        }
    }
}