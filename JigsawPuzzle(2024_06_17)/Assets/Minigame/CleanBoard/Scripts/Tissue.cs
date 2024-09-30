using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tissue : MonoBehaviour, IDragHandler
{
    RectTransform m_RectTransform;
    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.position = eventData.position;
    }
}