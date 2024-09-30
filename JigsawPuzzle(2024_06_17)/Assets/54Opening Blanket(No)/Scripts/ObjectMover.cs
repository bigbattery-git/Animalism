using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.OpeningBlanket
{
    public class ObjectMover : MonoBehaviour, IDragHandler
    {
        private Vector2 startVector;
        private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.anchoredPosition;
        }
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        private void Update()
        {
            if(rectTransform.anchoredPosition.x < startVector.x || rectTransform.anchoredPosition.x > startVector.x)
            {
                rectTransform.anchoredPosition = new Vector2(startVector.x, rectTransform.anchoredPosition.y);
            }
        }
    }
}