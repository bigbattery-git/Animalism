using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Missons.Village.AdjustingRadio
{
    public class Gear : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        private AdjustingRadioManager manager;
        private RectTransform rectTransform;

        [SerializeField]
        private Canvas canvas;
        private Camera uiCam;

        private Vector3 screenPos;
        private float angleOffset;

        private float beforeAngle;

        [SerializeField]
        private Frequency frequency;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                uiCam = Camera.main;
            }
            else
            {
                uiCam = canvas.worldCamera;
            }
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (manager.IsClear) return;
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                OnBeginDragWhenCanvasOverlay(eventData);
            }
            else
            {
                OnBeginDragWhenCanvasModeElse(eventData);
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (manager.IsClear) return;
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                OnDragWhenCanvasOverlay(eventData);
            }
            else
            {
                OnDragWhenCanvasModeElse(eventData);
            }
        }

        private void OnBeginDragWhenCanvasOverlay(PointerEventData eventData)
        {
            screenPos = rectTransform.position;
            Vector3 vec3 = (Vector3)eventData.position - screenPos;
            angleOffset = (Mathf.Atan2(rectTransform.right.y, rectTransform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
        }
        private void OnDragWhenCanvasOverlay(PointerEventData eventData)
        {
            Vector3 vec3 = (Vector3)eventData.position - screenPos;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            rectTransform.eulerAngles = new Vector3(0, 0, angle + angleOffset);            
        }

        private void OnBeginDragWhenCanvasModeElse(PointerEventData eventData)
        {   
            // 오브젝트내 좌표를 world에서 screen으로 변경
            screenPos = uiCam.WorldToScreenPoint(rectTransform.position);

            // screenPos에서 screen 내 마우스 좌표까지의 방향벡터 구하기
            Vector3 vec3 = (Vector3)eventData.position - screenPos;

            // 현 오브젝트의 라디안에서 vec 방향벡터 라디안 만큼 차이를 angleOffset으로 주기 
            angleOffset = (Mathf.Atan2(rectTransform.right.y, rectTransform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
        }

        private void OnDragWhenCanvasModeElse(PointerEventData eventData)
        {
            // screenPos에서 screen 내 마우스 좌표까지의 방향벡터 구하기
            Vector3 vec3 = (Vector3)eventData.position - screenPos;

            // 방향벡터의 좌표 구하기
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;

            // 각도, angleOffset만큼 각도 주기
            rectTransform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

            // 주파수 박스에 영향 주기
            frequency.OnMoveGear(beforeAngle, angle);

            beforeAngle = angle;
        }

        public void Setup(AdjustingRadioManager _manager, Canvas _canvas)
        {
            manager = _manager;
            canvas = _canvas;

            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                uiCam = Camera.main;
            }
            else
            {
                uiCam = canvas.worldCamera;
            }
        }
    }
}