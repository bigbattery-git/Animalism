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