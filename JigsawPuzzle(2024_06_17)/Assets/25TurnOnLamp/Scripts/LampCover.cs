using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.TurnOnLamp
{
    public class LampCover : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform coverConnectingTransform;

        [SerializeField] private Canvas canvas;

        [SerializeField] private TurnOnLampManager manager;

        [SerializeField] private RectTransform layerTransform;
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
            if (manager.MissionState != MissionState.CoveringLampCover) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (manager.MissionState != MissionState.CoveringLampCover) return;
            if (Vector3.Distance(rectTransform.anchoredPosition, coverConnectingTransform.anchoredPosition) > 50f) return;

            rectTransform.anchoredPosition = coverConnectingTransform.anchoredPosition;
            manager.FiringLamp();
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
    }
}