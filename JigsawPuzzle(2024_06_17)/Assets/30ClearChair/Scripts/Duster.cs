using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.ClearChair
{
    public class Duster : MonoBehaviour, IDragHandler
    {
        [SerializeField] private ClearChairManager manager;

        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerRectTransform;

        private RectTransform rectTransform;
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
            if (manager.IsClear) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerRectTransform);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                Stain stain = collision.GetComponent<Stain>();

                stain.OnTouchedDuster(manager.ClearCount);
                if (stain.CleanCount >= manager.ClearCount)
                {
                    stain.gameObject.SetActive(false);
                    stain.GetComponentInParent<StainManager>().CheckClear();
                }
            }
        }
    }
}