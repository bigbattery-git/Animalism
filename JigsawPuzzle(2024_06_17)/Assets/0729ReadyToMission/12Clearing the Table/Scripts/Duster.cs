using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.ClearingTheTable
{
    public class Duster : MonoBehaviour, IDragHandler
    {
        [SerializeField] private Canvas canvas;        
        [SerializeField] private ClearingTheTableManager manager;
        private RectTransform rectTransform;

        private Vector2 startVector;

        [SerializeField] private int clearCount;
        [SerializeField] private RectTransform layerTransform;
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
            if (manager.State == CleanTableMissionState.CleanTable)
            {
                OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
            }
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                Stain stain = collision.GetComponent<Stain>();
                
                if (stain.clearCount >= clearCount)
                {
                    collision.gameObject.SetActive(false);
                    collision.GetComponentInParent<StainsManager>().CheckStainClear();
                }
                else
                {
                    stain.clearCount++;
                    stain.SetImageAlpha(clearCount);
                }
            }
        }
    }
}