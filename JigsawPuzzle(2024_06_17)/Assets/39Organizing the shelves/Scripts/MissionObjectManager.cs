using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizingTheShelves
{
    public class MissionObjectManager : MonoBehaviour
    {
        [SerializeField] private MissionObject[] missionObjects;
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerTransform;

        [SerializeField] private GoalPoint goalPoint;

        [SerializeField] private OVMissionOrigin origin;
        private Vector2[] startMissionObjects;

        [SerializeField] private float distance = 50f;
        private void Awake()
        {
            startMissionObjects = new Vector2[missionObjects.Length];

            for (int i = 0; i<missionObjects.Length; i++)
            {
                missionObjects[i].Init(canvas, layerTransform);
                startMissionObjects[i] = missionObjects[i].GetComponent<RectTransform>().anchoredPosition;
            }
        }

        private void OnEnable()
        {
            SetObjectsRandomPlace();
        }

        private void SetObjectsRandomPlace()
        {
            List<int> rndList = new List<int>();
            for(int i = 0; i<missionObjects.Length; i++)
            {
                rndList.Add(i);
            }

            for(int i = 0; i<missionObjects.Length; i++)
            {
                int rnd = Random.Range(0, rndList.Count);

                missionObjects[i].SetPosition(startMissionObjects[rndList[rnd]]);

                rndList.RemoveAt(rnd);
            }
        }

        public void CheckInPlace(MissionObject _missionObject)
        {
            RectTransform rectTransform = _missionObject.GetComponent<RectTransform>();

            for(int i = 0; i< goalPoint.Zones.Length; i++)
            {
                if (Vector2.Distance(rectTransform.anchoredPosition,
                    goalPoint.Zones[i].GetComponent<RectTransform>().anchoredPosition) > distance) continue;

                if (goalPoint.Zones[i].IsInPlace) continue;

                rectTransform.anchoredPosition = goalPoint.Zones[i].GetComponent<RectTransform>().anchoredPosition;
                _missionObject.Zone = goalPoint.Zones[i];
                goalPoint.Zones[i].IsInPlace = true;

                break;
            }
        }

        public void CheckClear()
        {
            if (!goalPoint.IsAllZoneIsInPoint()) return;
            foreach(MissionObject obj in missionObjects)
            {
                if (!obj.IsEqualZoneNum()) return;
            }

            foreach (MissionObject obj in missionObjects) obj.CanMove = false;
            origin.MissionClear();
        }

    }
}