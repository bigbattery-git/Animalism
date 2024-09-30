using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.OpenTheMap
{
    public class MapMover : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private OVMissionOrigin origin;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Map map;
        [SerializeField] private RectTransform[] mapPoints;

        private RectTransform rectTransform;

        private Vector2 limitVector;

        private float limitPointX;
        private int mapState = 0;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            limitVector = rectTransform.anchoredPosition;
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = limitVector;

            limitPointX = limitVector.x;

            mapState = 0;
        }

        public void OnDrag(PointerEventData eventData)
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
        public void OnEndDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition = new Vector2(limitPointX, limitVector.y);
        }

        private void Update()
        {
            if (rectTransform.anchoredPosition.y > limitVector.y)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, limitVector.y);
            }

            if( rectTransform.anchoredPosition.y < limitVector.y)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, limitVector.y);
            }
            
            if(rectTransform.anchoredPosition.x < limitPointX)
            {
                rectTransform.anchoredPosition = new Vector2(limitPointX, rectTransform.anchoredPosition.y);
            }

            CheckCheckPoint();
        }

        private void CheckCheckPoint()
        {
            if(rectTransform.anchoredPosition.x > mapPoints[mapState].anchoredPosition.x)
            {
                limitPointX = mapPoints[mapState].anchoredPosition.x;
               
                map.UpdateMap(mapState + 1);

                if (mapState == 3)
                {
                    origin.MissionClear();
                    return;
                }

                mapState++;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID46OpeningMap.Play();
        }
    }
}