using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.Presser
{
    public class PresserObject : MonoBehaviour, IDragHandler
    {
        private RectTransform rectTransform;
        private Canvas canvas;

        private Image image;
        private Sprite startSprite;
        private Vector2 startVector;
        [SerializeField] private Sprite[] resultObjects;

        [SerializeField] private RectTransform objectzoneRectTransform;

        [SerializeField] private float zoneDistance;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
            canvas = transform.root.GetComponentInChildren<Canvas>();

            startSprite = image.sprite;

            startVector = rectTransform.localPosition;
        }

        private void OnEnable()
        {
            if(image.sprite != startSprite)
            {
                image.sprite = startSprite;
            }

            rectTransform.localPosition = startVector;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!IsInZone())
            {
                // 캔버스의 RenderMode에 따라 Drag and Drop 방법이 다름
                switch (canvas.renderMode)
                {
                    // canvas의 Render Mode가 Overlay일 때
                    // canvas가 카메라의 레퍼런스를 받을 필요가 없으므로 UI 위치와 eventData 위치를 같게 하면 됨
                    case RenderMode.ScreenSpaceOverlay:
                        this.rectTransform.position = eventData.position;
                        break;

                    // canvas의 Render Mode가 Camera일 때
                    // UI가 카메라에 맞게 위치하므로 eventData의 위치에 맞추면 나도 모르는 곳으로 이동함
                    case RenderMode.ScreenSpaceCamera:
                        Camera cam = canvas.worldCamera; // 그래서 canvas가 랜더링하고 있는 카메라에 맞춰서 position을 이동시킴
                        Vector3 vec = Vector3.zero;

                        // 카메라의 투영방식에 따라 좌표 받아오는 방법이 다름
                        if (cam.orthographic) // 원근감 X
                        {
                            // 카메라의 Depth 상관없이 평면이므로 screen좌표를 world 좌표로 바꾸면 됨
                            vec = new Vector3(cam.ScreenToWorldPoint(eventData.position).x, cam.ScreenToWorldPoint(eventData.position).y, 0);
                        }
                        else // 원근감 O
                        {
                            // 카메라의 Depth에 따라 좌표도 다르게 나오므로 z값을 지정해야함. z값이 0이면 항상 (0, 1, camera.z) 출력
                            // UI의 z값은 cam.fieldOfView + canvas.planeDistance을 통해 항상 0으로 만들 수 있음.
                            vec = cam.ScreenToWorldPoint(Input.mousePosition + (Vector3.forward * (cam.fieldOfView + canvas.planeDistance)));
                        }
                        this.rectTransform.position = vec;
                        break;
                }
            }
        }

        public bool IsInZone()
        {
            if (Vector2.Distance(rectTransform.position, objectzoneRectTransform.position) < zoneDistance)
            {              
                rectTransform.position = objectzoneRectTransform.position;
                return true;
            }

            return false;
        }
    }
}

