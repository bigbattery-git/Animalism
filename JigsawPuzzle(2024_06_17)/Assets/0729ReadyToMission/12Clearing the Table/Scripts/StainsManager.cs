using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClearingTheTable
{
    public class StainsManager : MonoBehaviour
    {
        private GameObject[] stains;
        [SerializeField] private OVMissionOrigin manager;

        [SerializeField] private int numOfActivations;
        private void Awake()
        {
            stains = new GameObject[transform.childCount];
            for(int i = 0; i< stains.Length; i++)
            {
                stains[i] = transform.GetChild(i).gameObject;
            }
        }
        private void OnEnable()
        {
            ActiveStains(false);

            int[] nums = GetRandomNums(numOfActivations);

            for(int i = 0; i< nums.Length; i++)
            {
                stains[nums[i]].SetActive(true);
            }
        }

        private void ActiveStains(bool _turnOn)
        {
            foreach (var stain in stains)
            {
                if (stain.activeInHierarchy == true)
                {
                    stain.SetActive(_turnOn);
                }
            }
        }
        private void OnDisable()
        {
            ActiveStains(false);
        }
        private int[] GetRandomNums(int _count)
        {
            int[] nums = new int[_count];
            List<int> numbers = new List<int>();

            for(int i = 0; i< transform.childCount; i++)
            {
                numbers.Add(i);
            }

            for(int i = 0; i< nums.Length; i++)
            {
                int a = UnityEngine.Random.Range(0, numbers.Count);

                nums[i] = numbers[a];
                numbers.RemoveAt(a);
            }

            return nums;
        }
        public void CheckStainClear()
        {
            for(int i = 0; i< transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeInHierarchy)
                    return;
            }
            manager.MissionClear();
        }
    }
}