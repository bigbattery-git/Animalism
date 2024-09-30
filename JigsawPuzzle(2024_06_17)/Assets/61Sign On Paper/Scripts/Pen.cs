using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.SignOnPaper
{
    public class Pen : MonoBehaviour, IDragHandler
    {
        private RectTransform rectTransform;
        [SerializeField] private RectTransform layerRectTransform;
        [SerializeField] private Canvas canvas;

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
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerRectTransform);
        }
    }
}