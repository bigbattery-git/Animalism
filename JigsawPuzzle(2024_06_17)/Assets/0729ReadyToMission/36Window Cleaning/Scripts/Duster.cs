using Missons.Village.CleaningTheFloor;
using Missons.Village.PolishingATombstone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.WindowCleaning
{
    public class Duster : MonoBehaviour, IDragHandler
    {
        private RectTransform rectTransform;
        [SerializeField] private WindowCleaningManager manager;
        [SerializeField] private Canvas canvas;
        [SerializeField] private int cleanCount;
        [SerializeField] private RectTransform layerTransform;

        private Vector2 startVector;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            startVector = rectTransform.anchoredPosition;
        }
        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (!manager.isClear)
            {
                OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
            }

        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                Stain stain = collision.GetComponent<Stain>();

                stain.OnTouchedDuster(cleanCount);
                if (stain.CleanCount >= cleanCount)
                {
                    stain.gameObject.SetActive(false);
                    stain.GetComponentInParent<StainManager>().CheckClear();
                }
            }
        }
    }
}