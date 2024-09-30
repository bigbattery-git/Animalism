using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.SprayingWater
{
    public class WaterCan : MonoBehaviour
    {
        [SerializeField] private GameObject waterEffect;
        [SerializeField] private float growTime = 3f;

        private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;

        public bool canMove = true;

        private Vector2 startVector;

        public float GrowTime => growTime;                

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.localPosition;
        }

        private void OnEnable()
        {
            rectTransform.localPosition = startVector;
            canMove = true;
            SetWaterSpraying(false);
        }
        private void Update()
        {
            if (canMove)
            {
                OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
            }
            else
            {
                SetWaterCan(false);
            }
        }
        public void SetWaterSpraying(bool _isSpraying)
        {
            switch (_isSpraying)
            {
                case true:
                    waterEffect.SetActive(true);
                    
                    break;
                case false:
                    waterEffect.SetActive(false);
                    
                    break;
            }
        }
        public void SetWaterCan(bool _isReady)
        {
            switch (_isReady)
            {
                case true:
                    rectTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 60));
                    break;
                case false:
                    rectTransform.transform.rotation = Quaternion.identity;
                    break;
            }

        }
    }
}