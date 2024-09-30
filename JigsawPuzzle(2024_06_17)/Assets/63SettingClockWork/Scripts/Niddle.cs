using Missons.Village.CleaningTheFloor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.SettingClockWork
{
    public class Niddle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private bool isHourNiddle;
        [SerializeField] private RectTransform hourRectTransform;

        public Number TouchedNum { get; private set; }

        private RectTransform rectTransform;
        private Vector2 centerPosition;
        private Vector2 startPosition;
        [SerializeField] private float rotateSpeed = 0.05f;
        public SettingClockWorkManager Manager { get; set; }

        [SerializeField] private RectTransform centerRect;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            centerPosition = centerRect.anchoredPosition;
        }

        private void OnEnable()
        {
            TouchedNum = null;
            rectTransform.rotation = Quaternion.identity;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            /*
            Vector2 direction = eventData.position - centerPosition;
            float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (endAngle < 0f) endAngle += 360f;

            direction = startPosition - centerPosition;
            float startAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            if (startAngle < 0f) startAngle += 360f;

            float angleDiff = endAngle - startAngle;

            if (startAngle >= 270f && endAngle < 90f)
            {
                angleDiff += 360f;
                transform.rotation = Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.back);
            }
            else if (startAngle <= 90f && endAngle >= 270f)
            {
                angleDiff -= 360f;
                transform.rotation = Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.back);
            }
            else
                transform.rotation = Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.forward);

            startPosition = eventData.position;
            */

            if (Manager.IsClear) return;

            Vector2 direction = eventData.position - centerPosition;            
            float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (endAngle < 0f) endAngle += 360f;

            direction = startPosition - centerPosition;
            float startAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (startAngle < 0f) startAngle += 360f;

            float angleDiff = endAngle - startAngle;

            if (startAngle >= 270f && endAngle <= 90f)
            {
                angleDiff += 360f;
                transform.rotation *= Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.back);

                if(!isHourNiddle)
                    hourRectTransform.rotation *= Quaternion.AngleAxis((angleDiff * rotateSpeed)/12, Vector3.back);
                    
            }
            else if (startAngle <= 90 && endAngle >= 270)
            {
                angleDiff -= 360f;
                transform.rotation *= Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.back);

                if (!isHourNiddle)
                    hourRectTransform.rotation *= Quaternion.AngleAxis((angleDiff * rotateSpeed) / 12, Vector3.back);
            }
            else
            {
                transform.rotation *= Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.forward);

                if (!isHourNiddle)
                    hourRectTransform.rotation *= Quaternion.AngleAxis((angleDiff * rotateSpeed) / 12, Vector3.forward);
            }
            startPosition = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Manager.CheckClear();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {                
                TouchedNum = collision.GetComponent<Number>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject") && !isHourNiddle)
            {
                TouchedNum = null;
            }
        }
    }
}