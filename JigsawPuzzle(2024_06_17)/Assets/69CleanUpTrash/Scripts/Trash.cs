using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.CleanUpTrash
{
    public class Trash : MonoBehaviour, IDragHandler, IBeginDragHandler
    {       
        private RectTransform rectTransform;
        private Vector2 startVector;

        public Canvas canvas { get; set; }
        public RectTransform layerRectTransform { get; set; }
        public TrashManager manager { get; set; }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            startVector = rectTransform.anchoredPosition;
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
        }

        private void OnDisable()
        {
            manager.OnDisableTrash(rectTransform.anchoredPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerRectTransform);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.PlayRndSound(new AudioSource[] { OVSoundRoot.Instance.Mission.ID80MovingTrash1, OVSoundRoot.Instance.Mission.ID80MovingTrash2 });
        }
    }
}