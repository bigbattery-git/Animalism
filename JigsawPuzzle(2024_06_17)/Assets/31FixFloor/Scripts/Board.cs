using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FixFloor
{
    public class Board : MonoBehaviour, IDragHandler, IDropHandler
    {
        public FixFloorManager Manager { get; set; }
        public Canvas canvas { get; set; }

        private RectTransform rectTransform;
        private Vector2 startVector;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.anchoredPosition;
        }
        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (Manager.MissionState != MissionState.ChangeBoard_New) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (Manager.MissionState != MissionState.ChangeBoard_New) return;

            if (Manager.IsInBrokenPosition(rectTransform))
            {
                Manager.PutonNail();
            }
        }
    }
}