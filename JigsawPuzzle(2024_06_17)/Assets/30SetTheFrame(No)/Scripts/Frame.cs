using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.SetTheFrame
{
    public class Frame : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        [SerializeField] private float rotateSpeed = 10f;

        private Vector2 CenterPosition;
        private RectTransform rectTransform;

        private Vector2 startPosition;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            CenterPosition = rectTransform.anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = eventData.position;            
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 direction = eventData.position - startPosition;
            float endAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (endAngle < 0f) endAngle += 360f;

            direction = startPosition - CenterPosition;
            float startAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (startAngle < 0f) startAngle += 360f;

            float angleDiff = endAngle - startAngle;

            if(startAngle >= 270f && endAngle <= 90f)
            {
                angleDiff += 360f;
                transform.rotation *= Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.back); 
            }
            else if(startAngle <= 90f && endAngle >= 270f)
            {
                angleDiff -= 360f;
                transform.rotation *= Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.back);
            }
            else
            {
                transform.rotation *= Quaternion.AngleAxis(angleDiff * rotateSpeed, Vector3.forward);
            }

            startPosition = eventData.position;
        }

        private void Update()
        {
            if (transform.rotation.eulerAngles.z < -45f)
                transform.rotation = Quaternion.Euler(0, 0, -45f);
        }
    }
}