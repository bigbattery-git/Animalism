using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.ClearingTheTable
{
    public class Bowl : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField] private Canvas canvas;
        private BowlsManager manager;
        private RectTransform rectTransform;

        private Vector2 startPosition;

        // private float overlayTrayDistance = 150f;
        // private float cameraTrayDistance = 10f;

        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private RectTransform trayTransform;
        private void Awake()
        {

            manager = GetComponentInParent<BowlsManager>();
            rectTransform = GetComponent<RectTransform>();

            startPosition = rectTransform.localPosition;
        }

        private void OnEnable()
        {
            rectTransform.localPosition = startPosition;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.PlayRndSound(new AudioSource[] { OVSoundRoot.Instance.Mission.ID1213CleaningDish, OVSoundRoot.Instance.Mission.ID1213CleaningDish2 });
        }
        public void OnDrag(PointerEventData eventData)
        {
            if(manager.Manager.State == CleanTableMissionState.CleanBowl)
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

        private void Update()
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
        private void OnDisable()
        {
            manager.CheckBowlClear();
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!Input.GetMouseButton(0))
            {
                if(collision.transform == trayTransform)
                {
                    Debug.Log("ID12DishCrashng");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}