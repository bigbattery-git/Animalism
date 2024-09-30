using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.HandingOverLostItems
{
    public class LostObject : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private HandingOverLostItemsManager manager;

        private Canvas canvas;
        private Image image;
        private RectTransform rectTransform;
        private RectTransform layerTransform;

        private Vector2 startVector;

        private bool isCorrectObject = false;
        private bool isTouchedHand = false;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();

            startVector = rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(manager.IsCanMove)
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!manager.IsCanMove) return;
            if (isTouchedHand == true)
            {
                if (manager.CheckMissionClear(isCorrectObject))
                    return;
            }

            rectTransform.anchoredPosition = startVector;
        }

        public void Setup(HandingOverLostItemsManager _manager, Canvas _canvas, RectTransform _layerTransfrom, bool _isCorrectObject, Sprite _sprite)
        {
            manager = _manager;
            canvas = _canvas;
            layerTransform = _layerTransfrom;
            isCorrectObject = _isCorrectObject;

            if(image == null)
            {
                image = GetComponent<Image>();
            }
            image.sprite = _sprite;
        }

        public void Init()
        {
            isTouchedHand = false;
            rectTransform.anchoredPosition = startVector;
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                isTouchedHand = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                isTouchedHand = false;
            }
        }
    }
}