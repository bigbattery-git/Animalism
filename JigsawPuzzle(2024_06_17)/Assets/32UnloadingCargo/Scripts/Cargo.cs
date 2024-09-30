using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.UnloadingCargo
{
    public class Cargo : MonoBehaviour, IDragHandler,IDropHandler, IBeginDragHandler
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform cargoPlaceTransform;
        [SerializeField] private UnloadingCargoManager manager;
        [SerializeField] private RectTransform layerRectTransform;

        private RectTransform rectTransform;

        private float limitDistance = 50f;
        [SerializeField] private bool canDrag;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            canDrag = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canDrag) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        public void OnDrop(PointerEventData eventData)
        {
            if (!canDrag)
                return;

            if (Vector3.Distance(cargoPlaceTransform.anchoredPosition, rectTransform.anchoredPosition) < limitDistance)
            {
                canDrag = false;
                rectTransform.anchoredPosition = cargoPlaceTransform.anchoredPosition;
                manager.CheckClear();
            }
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerRectTransform);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID33UnloadingCargo.Play();
        }
    }
}