using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Handle : MonoBehaviour, IDragHandler
{
    [SerializeField] Canvas canvas;
    RectTransform m_RectTransform;

    bool isCanPress;
    public bool IsCanPress
    {
        get
        {
            return isCanPress;
        }
        private set
        {
            isCanPress = value;
        }
    }
    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isCanPress == false) return;
        m_RectTransform.anchoredPosition += new Vector2(0, eventData.delta.y / canvas.scaleFactor);
        if (m_RectTransform.anchoredPosition.y < 460f)
        {
            m_RectTransform.anchoredPosition = new Vector2(m_RectTransform.anchoredPosition.x, 460f);
        }        
        if(m_RectTransform.anchoredPosition.y > 800f)
        {
            m_RectTransform.anchoredPosition = new Vector2(m_RectTransform.anchoredPosition.x, 800f);
        }
    }
    public void IsCansPress(bool _iscanPress)
    {
        isCanPress = _iscanPress;
    }
}