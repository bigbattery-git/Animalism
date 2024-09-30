using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FixFloor
{
    public class BrokenBoard : MonoBehaviour, IDragHandler
    {
        private RectTransform rectTransform;
        public Canvas canvas { get; set; }

        public FixFloorManager Manager { get; set; }
        private Vector2 startVector;

        [Header("Broken Nails")]
        [SerializeField] private GameObject[] brokenNails;
        
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.anchoredPosition;
        }
        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
            foreach(var nail in brokenNails)
            {
                nail.SetActive(true);
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (Manager.MissionState != MissionState.ChangeBoard_Broken) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        private void Update()
        {
            if (Manager.CanChangeNewBoard(rectTransform))
            {
                Manager.ChangeBoard_New();
                gameObject.SetActive(false);
            }
        }

        public void CheckNailClear()
        {
            foreach (var nail in brokenNails)
                if (nail.activeInHierarchy) return;

            Manager.ChangeBoard_Broken();
        }
    }
}