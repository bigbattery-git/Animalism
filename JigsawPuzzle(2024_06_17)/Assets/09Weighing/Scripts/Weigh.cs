using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.weighing
{
    public class Weigh : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private bool isSpawned = false;
        private RectTransform rectTransform;

        [SerializeField] private int weigh;
        public Canvas canvas { get; set; }
        public int Weigh_ => weigh;

        public WeighingManager Manager { get; set; }
        public Transform SetupTransform { get; set; }
        public Transform GDishTransform { get; set; }
        public RectTransform layerTransform { get; set; }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Manager.IsClear) return;

            if(transform.parent.transform == SetupTransform)
            {
                transform.SetParent(GDishTransform);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (Manager.IsClear) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (Manager.IsClear) return;

            if (transform.parent.transform == GDishTransform)
            {
                this.transform.SetParent(SetupTransform);
                Manager.SetHorizontalStand();
                Manager.CheckClear();
            }
        }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnDisable()
        {
            Destroy(this.gameObject);
        }
        private void Update()
        {
            if (!isSpawned)
            {
                if (Input.GetMouseButton(0))
                {
                    OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    if (transform.parent.transform == GDishTransform)
                    {
                        this.transform.SetParent(SetupTransform);
                        Manager.SetHorizontalStand();
                        Manager.CheckClear();
                    }
                    isSpawned = true;
                }
            }
            DestroyOutOfLayer();
        }

        private void DestroyOutOfLayer()
        {
            Vector2 layerSize = layerTransform.sizeDelta;
            Vector2 rect = rectTransform.anchoredPosition;
            if (Input.GetMouseButtonUp(0) && transform.parent.name != "SetUpWeigh")
            {
                if (rect.x > layerSize.x || rect.x < 0 || rect.y > layerSize.y || rect.y < 0)
                    Destroy(this.gameObject);
            }
        }
    }
}