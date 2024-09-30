using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Part : MonoBehaviour, IDragHandler,IEndDragHandler
{
    RectTransform m_RectTransform;
    Image image;

    [SerializeField] Canvas canvas;
    [SerializeField] Handle m_handle;
    [SerializeField] RectTransform m_AssemblageRectTransform;
    [SerializeField] float snapOffset = 30f;
    [SerializeField] Sprite successImage;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (CanPress() == true)
            return;
        m_RectTransform.anchoredPosition +=  eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(CanPress() == true)
        {
            m_handle.IsCansPress(true);
        }
    }
    bool CanPress()
    {
        if(Vector2.Distance(m_RectTransform.position, m_AssemblageRectTransform.position) < snapOffset)
        {
            transform.SetParent(m_AssemblageRectTransform);
            m_RectTransform.position = m_AssemblageRectTransform.position;
            return true;
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Press")&& m_handle.IsCanPress == true)
        {
            image.sprite = successImage;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Press") && m_handle.IsCanPress == true)
        {
            PresserManager.Instance.CallMissionClear();
        }
    }
}
