using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.PuttingMoney
{
    public class Money : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        private Canvas canvas;
        private RectTransform layerTransform;
        private RectTransform rectTransform;
        private RectTransform tillTransform;
        private PuttingMoneyManager manager;

        private Image image;
        public bool IsClear { get { return Vector3.Distance(tillTransform.anchoredPosition, rectTransform.anchoredPosition) < manager.TillMoneyDistance; } }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        public void Init(Canvas _canvas, RectTransform _layerTransform, RectTransform _tillTransform ,Sprite _moneySprite, PuttingMoneyManager _manager)
        {
            canvas = _canvas;
            layerTransform = _layerTransform;
            tillTransform = _tillTransform;
            image.sprite = _moneySprite;
            manager = _manager;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (manager.IsClear) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (IsClear)
            {
                manager.CheckClear();
            }
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }
    }
}