using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TurnOnLamp
{
    public class FollowingFire : MonoBehaviour
    {
        [SerializeField] private RectTransform followingPoint;
        private RectTransform rectTransform;
        private bool isTouchedLamp;

        public bool IsTouchedLamp => isTouchedLamp;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        void Update()
        {
            rectTransform.position = followingPoint.position;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            isTouchedLamp = true;
            Debug.Log(isTouchedLamp);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            isTouchedLamp = false;
        }
    }
}