using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.SetTheFrame2
{
    public class Frame : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;

        [SerializeField] private float rotationSpeed = 2.0f;
        private Vector3 lastMousePosition;

        public Camera uiCamera;

        private Vector3 mouseDelta;
        private Vector3 initialRotation;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            if(canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                if (canvas.worldCamera)
                {
                    uiCamera = canvas.worldCamera;
                }
                else
                    uiCamera = Camera.main;
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            /*
            switch (canvas.renderMode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    Vector3 currentMousePosition = Input.mousePosition;
                    mouseDelta = currentMousePosition - lastMousePosition;
                    float rotationX = mouseDelta.y * rotationSpeed;
                    float rotationY = -mouseDelta.x * rotationSpeed;
                    transform.Rotate(Vector3.up * rotationY, Space.World);
                    transform.Rotate(Vector3.left * rotationX, Space.World);
                    lastMousePosition = currentMousePosition;
                    break;

                case RenderMode.ScreenSpaceCamera:
                    currentMousePosition = Input.mousePosition;
                    Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
                    mouseDelta = currentMousePosition - lastMousePosition;

                    // 카메라 시선과 UI 요소 간의 각도 계산 (z 축만 고려)
                    Vector3 cameraToUIElement = transform.position - cam.transform.position;
                    float angleZ = Mathf.Atan2(mouseDelta.y, cameraToUIElement.magnitude) * Mathf.Rad2Deg;

                    // 회전 (z 축만)
                    transform.Rotate(Vector3.forward * angleZ * rotationSpeed, Space.World);

                    lastMousePosition = currentMousePosition;
                    break;
            }
            */
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;

            // 카메라 시선과 UI 요소 간의 각도 계산 (z 축만 고려)
            Vector3 cameraToUIElement = transform.position - uiCamera.transform.position;
            float angleZ = Mathf.Atan2(mouseDelta.y, cameraToUIElement.magnitude) * Mathf.Rad2Deg;

            // 초기 회전 각도를 기준으로 회전 (z 축만)
            transform.eulerAngles = initialRotation + Vector3.forward * angleZ * rotationSpeed;

            lastMousePosition = currentMousePosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            lastMousePosition = Input.mousePosition;

            // 드래그가 시작될 때 초기 회전 각도 저장
            initialRotation = transform.eulerAngles;
        }
    }
}