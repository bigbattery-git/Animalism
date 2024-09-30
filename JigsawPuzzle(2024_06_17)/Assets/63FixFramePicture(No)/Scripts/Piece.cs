using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.FixFramePicture
{
    public class Piece : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        public bool canMove { get; private set; }
        private RectTransform rectTransform;

        public FixFramePictureManager manager { get; set; }
        public RectTransform layerTransform { get; set; }
        public Canvas canvas { get; set; }
        public int pieceID { get; set; }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (!canMove) return;

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
        private void OnEnable()
        {
            canMove = true;
        }
        private void Update()
        {
            LimitPiecePosition();
        }
        private void LimitPiecePosition()
        {
            if (rectTransform.anchoredPosition.x > layerTransform.sizeDelta.x)
            {
                rectTransform.anchoredPosition = new Vector2(layerTransform.sizeDelta.x, rectTransform.anchoredPosition.y);
            }
            if (rectTransform.anchoredPosition.x < 0)
            {
                rectTransform.anchoredPosition = new Vector2(0, rectTransform.anchoredPosition.y);
            }
            if (rectTransform.anchoredPosition.y < -layerTransform.sizeDelta.y)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -layerTransform.sizeDelta.y);
            }
            if (rectTransform.anchoredPosition.y > 0)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!canMove) return;

            if(manager.IsInPlace(this, rectTransform))
            {
                canMove = false;
                transform.SetAsFirstSibling();
                manager.CheckClear();
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!canMove) return;
            transform.SetAsLastSibling();
        }
    }
}

