using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutCoals
{
    public class Coal : MonoBehaviour
    {
        public Canvas canvas;
        private RectTransform rectTransform;

        private bool isInPutPoint;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
            }

            else
            {
                if(!isInPutPoint)
                Destroy(this.gameObject);
            }
        }
        private void OnEnable()
        {
            Debug.Log("ID29Pushing");
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            isInPutPoint = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            isInPutPoint = false;
        }
    }
}