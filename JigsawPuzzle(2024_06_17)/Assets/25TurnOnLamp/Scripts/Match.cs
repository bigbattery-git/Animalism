using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.TurnOnLamp
{
    public class Match : MonoBehaviour
    {
        [SerializeField] private TurnOnLampManager manager;
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private FollowingFire fire;
        
        private RectTransform rectTransform;
        private float firingTime = 0.0f;

        private Vector2 startVector;


        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.anchoredPosition;
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
            firingTime = 0.0f;
    }

        private void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);

            if (manager.MissionState != MissionState.FiringLamp) return;
            if (!fire.IsTouchedLamp) 
            {
                firingTime = 0.0f;
                return;
            } 

            if (Input.GetMouseButton(0))
            {
                firingTime += Time.deltaTime;
                rectTransform.rotation = Quaternion.Euler(0, 0, 20);
            }
            if (Input.GetMouseButtonUp(0))
            {
                rectTransform.rotation = Quaternion.identity;
            }

            if (firingTime > manager.FiringTime)
            {
                manager.Clear();               
            }                
        }
    }
}