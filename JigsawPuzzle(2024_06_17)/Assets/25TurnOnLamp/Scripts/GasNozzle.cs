using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.TurnOnLamp
{
    public class GasNozzle : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform connectTransform;

        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;

        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private TurnOnLampManager manager;

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
            if (manager.MissionState != MissionState.MovingNozzle) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (manager.MissionState != MissionState.MovingNozzle) return;

            if (Vector3.Distance(rectTransform.anchoredPosition, connectTransform.anchoredPosition) > 50f) return;

            rectTransform.anchoredPosition = connectTransform.anchoredPosition;
            OVSoundRoot.Instance.Mission.ID26FillingOil.Play();
            manager.ConnectingNozzle();
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
    }
}