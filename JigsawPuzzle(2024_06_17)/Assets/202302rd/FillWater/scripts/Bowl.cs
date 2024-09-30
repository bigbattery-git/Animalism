using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FillWater
{
    public class Bowl : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private RectTransform rect;
        private Vector2 startWaterPos;

        [SerializeField] private FillWaterManager manager;
        private bool isClear;
        private bool isClick;
        private void Awake()
        {
            startWaterPos = rect.position;
        }

        private void OnEnable()
        {
            rect.position = new Vector3(startWaterPos.x, startWaterPos.y - 3f);
            isClick = false;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            isClick = true;
        }
        private void Update()
        {
            if (isClear) return;
            if (rect.position.y > startWaterPos.y)
            {
                manager.Clear();
                isClear = true;
            }
            if(isClick)
            rect.position = new Vector3(rect.position.x, rect.position.y + Time.deltaTime);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isClick = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isClick = false;
        }
    }
}