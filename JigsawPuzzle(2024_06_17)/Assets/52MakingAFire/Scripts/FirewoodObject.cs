using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.MakeAFire
{
    public class FirewoodObject : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private RectTransform layerTransform;
        private RectTransform rectTransform;
        private Canvas canvas;

        private Image image;

        private FirewoodManager firewoodManager;

        [SerializeField] private int firewoodNum;

        public bool IsReadyToNext { get; set; }
        private Vector2 startVector;
        public void Init(FirewoodManager _manager, RectTransform _layerTransform, Canvas _canvas)
        {
            this.firewoodManager = _manager;
            this.layerTransform = _layerTransform;
            this.canvas = _canvas;
        }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
            startVector = rectTransform.anchoredPosition;            
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsReadyToNext) return;

            transform.SetAsLastSibling();

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(IsReadyToNext) return;

            if(Vector2.Distance(firewoodManager.FirewoodRect, rectTransform.anchoredPosition) 
                < firewoodManager.FirewoodDistance)
            {
                transform.SetSiblingIndex(firewoodNum);

                IsReadyToNext = true;
                rectTransform.anchoredPosition = startVector;

                firewoodManager.CheckClear();                
            }
        }

        private void Update()
        {
            image.raycastTarget = !IsReadyToNext;

            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
    }
}