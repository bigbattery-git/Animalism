using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.MakeAFire
{
    public class Match : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public RectTransform layerTransform { get; set; }
        public Canvas canvas { get; set; }

        private RectTransform rectTransform;

        public MakingAFireManager manager { get; set; }

        private float makeFireTime;

        private Vector2 startVector;
        private Vector2 startFirePosition;

        private bool isPointerEnter;

        [SerializeField] private RectTransform matchImageTransform;
        [SerializeField] private RectTransform firePosition;
        [SerializeField] private RectTransform fire;

        private bool canMakingFire;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.anchoredPosition;

            startFirePosition = firePosition.anchoredPosition;
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (manager.state != MissionState.MakeFire) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);

            fire.position = firePosition.position;

            if (manager.state != MissionState.MakeFire) return;

            if (Input.GetMouseButtonDown(0) && isPointerEnter)
            {
                matchImageTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 20));
                firePosition.anchoredPosition = startFirePosition + new Vector2(7f, 0);
            }
            
            if (Input.GetMouseButton(0) && canMakingFire)
            {
                makeFireTime += Time.deltaTime;

                if (makeFireTime > manager.MakeFireTime)
                {
                    manager.ReadyToFire();
                }
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                matchImageTransform.rotation = Quaternion.identity;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == "Firewood")
            {
                Debug.Log("Aaaaa");
                canMakingFire = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.name == "Firewood")
            {
                canMakingFire = false;
                makeFireTime = 0;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointerEnter = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerEnter = false;
        }
    }
}