using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Missons.Village.CleaningTheFloor
{
    public class CleaningTheFloorManager : MonoBehaviour
    {
        [SerializeField] int missionSetCount;
        public UnityEvent onClearMission;
        private int missionClearCount;
        public int MissionClearCount => missionClearCount;
        public int MissionSetCount => missionSetCount;

        public void AddMissionClearCount()
        {
            onClearMission.Invoke();
            missionClearCount++;
        }
        public void Clear()
        {
            Debug.Log("All Clear");
        }
        public bool IsMissionClear()
        {
            return missionClearCount == missionSetCount;
        }
    }
}