using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.WipeDownTheVanity
{
    public class Duster : MonoBehaviour, IDragHandler
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private RectTransform layerTransform;

        [SerializeField] private WipeDownTheVanityManager manager;

        private Vector2 startVector;

        private void Awake()
        {
            startVector = rectTransform.anchoredPosition;
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startVector;
        }
        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
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

                stain.OnTouchStain(manager.ClearCount);
            }
        }
    }
}