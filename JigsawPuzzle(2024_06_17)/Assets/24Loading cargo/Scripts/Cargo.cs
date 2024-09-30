using Missons.Village.ClearingTheTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.LoadingCargo
{
    public class Cargo : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField] private LoadingCargoManager manager;
        [SerializeField] private RectTransform layerTransform;

        private RectTransform rectTransform;
        
        private Canvas canvas;
        private Vector2 startVector;

        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.localPosition;
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
        private void OnEnable()
        {
            rectTransform.localPosition = startVector;
        }
        private void OnDisable()
        {
            manager.IsClear();
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!Input.GetMouseButton(0))
            {
                if (collision.CompareTag("MiniGameObject"))
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID25LoadingCargo.Play();
        }
    }
}