using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.ClassifyingGrains
{
    public class Grain : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField] int BeanNumber;

        Vector2 startRectTransform;
        RectTransform rectTransform;

        public Canvas canvas;
        public OVMissionOrigin origin;
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            startRectTransform = rectTransform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if(!Input.GetMouseButton(0))
            {
                if (collision.CompareTag("MiniGameObject"))
                {
                    if (BeanNumber == collision.GetComponent<Sack>().SackNumber)
                    {
                        if(transform.parent.transform.childCount == 1)
                        {
                            origin.MissionClear();
                        }
                        Destroy(gameObject);
                    }
                }
                else if (collision.name != "Tray")
                {
                    rectTransform.position = startRectTransform;
                }
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID8GettingBeans.Play();
        }
    }
}