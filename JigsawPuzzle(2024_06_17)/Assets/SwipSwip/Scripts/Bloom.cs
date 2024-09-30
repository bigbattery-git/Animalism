using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.SwipFloor
{
    public class Bloom : MonoBehaviour, IDragHandler
    {
        RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.position = eventData.position;
        }
    }
}