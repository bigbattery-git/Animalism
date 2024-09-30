using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.OrganizingTheShelves
{
    public class MissionObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private int objectID;
        [SerializeField] private MissionObjectManager manager;
        public int ObjectID => objectID;

        private Canvas canvas;
        private RectTransform rectTransform;
        private RectTransform layerTransform;

        public bool CanMove { get; set; }
        public Zone Zone { get; set; }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Init(Canvas _canvas, RectTransform _layerTransform)
        {
            canvas = _canvas;
            layerTransform = _layerTransform;            
        }

        private void OnEnable()
        {
            CanMove = true;
        }

        public void SetPosition(Vector2 _anchoredPosition)
        {
            if(rectTransform == null) rectTransform = GetComponent<RectTransform>();

            rectTransform.anchoredPosition = _anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
            if (Zone)
            {
                Zone.IsInPlace = false;
                Zone = null;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!CanMove) return;
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            manager.CheckInPlace(this);
            manager.CheckClear();
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }

        public bool IsEqualZoneNum()
        {
            if (!Zone) return false;
            if (objectID != Zone.ZoneID) return false;

            return true;
        }
    }
}