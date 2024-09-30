using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.FillWater
{
    public class FillWaterManager : MonoBehaviour, IOVMisison
    {
        public bool IsAppeared { get; private set; }

        public event Action MissionCompletedHandler;
        public event Action MissionCancleHandler;

        public void Hide()
        {
            MissionCompletedHandler?.Invoke();
            MissionCancleHandler?.Invoke();
        }

        public void Show()
        {
            
        }
        public void Clear()
        {
            Debug.Log("Clear");
        }

        public void OnMissionCleared()
        {
            
        }
    }
}