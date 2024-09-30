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
            // ������Ʈ�� ��ǥ�� world���� screen���� ����
            screenPos = uiCam.WorldToScreenPoint(rectTransform.position);

            // screenPos���� screen �� ���콺 ��ǥ������ ���⺤�� ���ϱ�
            Vector3 vec3 = (Vector3)eventData.position - screenPos;

            // �� ������Ʈ�� ���ȿ��� vec ���⺤�� ���� ��ŭ ���̸� angleOffset���� �ֱ� 
            angleOffset = (Mathf.Atan2(rectTransform.right.y, rectTransform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
        }

        private void OnDragWhenCanvasModeElse(PointerEventData eventData)
        {
            // screenPos���� screen �� ���콺 ��ǥ������ ���⺤�� ���ϱ�
            Vector3 vec3 = (Vector3)eventData.position - screenPos;

            // ���⺤���� ��ǥ ���ϱ�
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;

            // ����, angleOffset��ŭ ���� �ֱ�
            rectTransform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

            // ���ļ� �ڽ��� ���� �ֱ�
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