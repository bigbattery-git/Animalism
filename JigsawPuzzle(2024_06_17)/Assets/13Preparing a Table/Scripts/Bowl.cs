using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.PreparingATable
{
    public class Bowl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform placeTransform;
        [SerializeField] private RectTransform layerTransform;

        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;
        
        private Vector2 startVector;

        private float placeDistance = 60f;
        private bool canMove = false;

        private BowlManager bowlManager;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            startVector = rectTransform.anchoredPosition;
            bowlManager = GetComponentInParent<BowlManager>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canMove) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        } 
        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
            canMove = true;
        }
        
        public bool IsInPlace()
        {
            if((rectTransform.anchoredPosition - placeTransform.anchoredPosition).magnitude < placeDistance)
            {
                rectTransform.anchoredPosition = placeTransform.anchoredPosition;

                canMove = false;
                return true;
            }

            return false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(IsInPlace())
            bowlManager.CheckClear();
        }
    }
}