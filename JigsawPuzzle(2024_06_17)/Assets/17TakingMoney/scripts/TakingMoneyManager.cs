using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TakingMoney
{
    public class TakingMoneyManager : OVMissionOrigin
    {
        public int currentClearCount;
        public int FinishClearCount;

        [SerializeField] private GameObject[] moneys;
        public override void Awake()
        {
            base.Awake();
            FinishClearCount = moneys.Length; 
        }

        private void OnEnable()
        {
            foreach (GameObject money in moneys)
            {
                money.SetActive(true);
            }

            currentClearCount = 0;
        }

        public void Clear()
        {
            Debug.Log("Clear");
        }
    }
}