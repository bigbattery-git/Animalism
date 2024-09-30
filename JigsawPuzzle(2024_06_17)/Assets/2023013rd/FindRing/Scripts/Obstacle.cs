using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FindRing
{
    public class Obstacle : MonoBehaviour, IDragHandler
    {
        private RectTransform m_RectTransform;

        private void Start()
        {
            m_RectTransform = GetComponent<RectTransform>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            m_RectTransform.position = eventData.position;
        }
    }
}