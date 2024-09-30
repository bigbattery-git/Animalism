using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizingTheShelves
{
    public class GoalPoint : MonoBehaviour
    {
        [SerializeField] private Zone[] zones;
        private Vector2[] zonePositions;
        public Zone[] Zones => zones;

        private void Awake()
        {
            zonePositions = new Vector2[zones.Length];

            for(int i = 0; i< zones.Length; i++)
            {
                zonePositions[i] = zones[i].GetComponent<RectTransform>().anchoredPosition;
            }
        }

        private void OnEnable()
        {
            foreach(Zone zone in zones)
            {
                zone.IsInPlace = false;
            }
        }

        public void SetRndZone(int _zoneNum, int _positionNum)
        {
            zones[_zoneNum].GetComponent<RectTransform>().anchoredPosition = zonePositions[_positionNum];
        }

        public bool IsAllZoneIsInPoint()
        {
            foreach(Zone zone in zones)
            {
                if (!zone.IsInPlace) return false;
            }
            return true;
        }
    }
}