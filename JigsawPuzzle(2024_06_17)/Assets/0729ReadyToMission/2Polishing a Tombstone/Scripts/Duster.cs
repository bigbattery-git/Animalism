using Missons.Village.CleaningTheFloor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.PolishingATombstone
{
    public class Duster : MonoBehaviour, IDragHandler
    {
        RectTransform rectTransform;
        [SerializeField] PolishingATombstoneManager manager;

        [SerializeField] private Canvas canvas;
        [SerializeField] private int cleanCount;
        [SerializeField] private RectTransform layerTransform;
        private Vector2 startVector;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startVector = rectTransform.localPosition;
        }
        private void OnEnable()
        {
            rectTransform.localPosition = startVector;
        }
        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
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
                if(stain.CleanCount >= cleanCount)
                {
                    stain.gameObject.SetActive(false);
                    stain.GetComponentInParent<StainManager>().CheckClear();
                }
            }
        }
    }
}