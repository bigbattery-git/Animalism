using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FindJewel
{
    public class Trash : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;

        [SerializeField] private TrashManager manager;

        [SerializeField] private bool isCoffinCover;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isCoffinCover)
            {
                Debug.Log("ID34CoffinCoverOpening");
            }
            else
            {
                Debug.Log("ID34TrashMoving");
            }
        }
    }
}