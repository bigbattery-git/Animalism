using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.CutTicket
{
    public class CutLine : MonoBehaviour, IDragHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler
    {
        [Header("전체 미션관련")]
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerTransform;
        private RectTransform rectTransform;

        public CutTicketManager manager { get; set; }
        [Header("해당 오브젝트 관련")]
        private bool canMove;
        private Vector2 limitVector;
        private Vector2 cutLineSize;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            limitVector = rectTransform.anchoredPosition;

            cutLineSize = rectTransform.sizeDelta;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (manager.isClear) return;

            /*
            if (!OVSoundRoot.Instance.Mission.ID85Ticketing.isPlaying)
            {
                OVSoundRoot.Instance.Mission.ID85Ticketing.Play();
            }
            */
            canMove = true;
            rectTransform.sizeDelta = new Vector2(100f, 100f);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canMove) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canMove = false;

            rectTransform.anchoredPosition = limitVector;
            rectTransform.sizeDelta = cutLineSize;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            canMove = false;

            rectTransform.anchoredPosition = limitVector;
            rectTransform.sizeDelta = cutLineSize;
        }

        private void Update()
        {
            if (rectTransform.anchoredPosition.x > limitVector.x || rectTransform.anchoredPosition.x < limitVector.x)
                rectTransform.anchoredPosition = new Vector2(limitVector.x, rectTransform.anchoredPosition.y);
            if (rectTransform.anchoredPosition.y > limitVector.y)
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, limitVector.y);

            if (rectTransform.anchoredPosition.y < -750f)
            {
                canMove = false;
                rectTransform.anchoredPosition = limitVector;

                manager.MissionClear();
            }
        }
    }
}