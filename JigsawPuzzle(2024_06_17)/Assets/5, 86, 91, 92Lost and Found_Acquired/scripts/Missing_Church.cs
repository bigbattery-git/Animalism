using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Missons.Village.LostAndFound_Church
{
    public class Missing_Church : MonoBehaviour, IPointerClickHandler, IDragHandler
    {
        private RectTransform rectTransform;
        public LostAndFound_AcquiredManager manager { get; set; }

        private Vector2 startPosition;
        [SerializeField] private Canvas canvas;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startPosition = rectTransform.anchoredPosition;
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (manager.ClearType != ClearType.Drag) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (manager.ClearType != ClearType.Click) return;
            manager.EffectMissionClear(rectTransform);
            gameObject.SetActive(false);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                manager.EffectMissionClear(rectTransform);
                gameObject.SetActive(false);
            }                
        }
    }
}