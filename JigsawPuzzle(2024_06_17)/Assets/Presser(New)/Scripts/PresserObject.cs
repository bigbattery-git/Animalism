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
                // ĵ������ RenderMode�� ���� Drag and Drop ����� �ٸ�
                switch (canvas.renderMode)
                {
                    // canvas�� Render Mode�� Overlay�� ��
                    // canvas�� ī�޶��� ���۷����� ���� �ʿ䰡 �����Ƿ� UI ��ġ�� eventData ��ġ�� ���� �ϸ� ��
                    case RenderMode.ScreenSpaceOverlay:
                        this.rectTransform.position = eventData.position;
                        break;

                    // canvas�� Render Mode�� Camera�� ��
                    // UI�� ī�޶� �°� ��ġ�ϹǷ� eventData�� ��ġ�� ���߸� ���� �𸣴� ������ �̵���
                    case RenderMode.ScreenSpaceCamera:
                        Camera cam = canvas.worldCamera; // �׷��� canvas�� �������ϰ� �ִ� ī�޶� ���缭 position�� �̵���Ŵ
                        Vector3 vec = Vector3.zero;

                        // ī�޶��� ������Ŀ� ���� ��ǥ �޾ƿ��� ����� �ٸ�
                        if (cam.orthographic) // ���ٰ� X
                        {
                            // ī�޶��� Depth ������� ����̹Ƿ� screen��ǥ�� world ��ǥ�� �ٲٸ� ��
                            vec = new Vector3(cam.ScreenToWorldPoint(eventData.position).x, cam.ScreenToWorldPoint(eventData.position).y, 0);
                        }
                        else // ���ٰ� O
                        {
                            // ī�޶��� Depth�� ���� ��ǥ�� �ٸ��� �����Ƿ� z���� �����ؾ���. z���� 0�̸� �׻� (0, 1, camera.z) ���
                            // UI�� z���� cam.fieldOfView + canvas.planeDistance�� ���� �׻� 0���� ���� �� ����.
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

