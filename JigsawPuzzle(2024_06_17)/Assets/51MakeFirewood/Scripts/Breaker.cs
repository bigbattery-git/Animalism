using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.MakeFirewood
{
    public class Breaker : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerExitHandler, IEndDragHandler
    {
        [Header("전체 미션관련")]
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerTransform;
        private RectTransform rectTransform;

        public MakeFirewoodManager manager { get; set; }
        [Header("해당 오브젝트 관련")]        
        private Vector2 limitVector;
        private bool canMove => manager.CanMove;
        private bool IsBreaked { get { return rectTransform.anchoredPosition.y < -650f; } }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            limitVector = rectTransform.anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (manager.isClear) return;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canMove) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition = limitVector;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            rectTransform.anchoredPosition = limitVector;
        }

        private void Update()
        {
            if(rectTransform.anchoredPosition.x > limitVector.x || rectTransform.anchoredPosition.x < limitVector.x)
                rectTransform.anchoredPosition = new Vector2(limitVector.x, rectTransform.anchoredPosition.y);
            if (rectTransform.anchoredPosition.y > limitVector.y)
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, limitVector.y);

            if(IsBreaked)
            {
                rectTransform.anchoredPosition = limitVector;

                manager.BreakFirewood();

                OVSoundRoot.Instance.Mission.ID55ChoppingWood.Play();
            }
        }
    }
}