using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.OrganizingTheKeys
{
    public class Key : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool IsInPosition => isInPosition;

        public int keyID;
        private bool isInPosition;

        private Vector2 startPosition;

        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerRectTransform;

        private RectTransform rectTransform;
        private RectTransform keyBoxRectTransform;
        private KeyBox myKeyBox;
        private Image image;

        private const float keyBoxDistance = 100f;
        public void OnDrag(PointerEventData eventData)
        {
            if (isInPosition) return;
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float distance = Vector2.Distance(keyBoxRectTransform.anchoredPosition, rectTransform.anchoredPosition);

            Debug.Log(distance);

            if (Vector2.Distance(keyBoxRectTransform.anchoredPosition, rectTransform.anchoredPosition) < keyBoxDistance)
            {
                rectTransform.anchoredPosition = keyBoxRectTransform.anchoredPosition;
                isInPosition = true;
                image.raycastTarget = false;

                GetComponentInParent<KeyManager>().CheckClear();
            }
        }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            startPosition = rectTransform.anchoredPosition;

            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            rectTransform.anchoredPosition = startPosition;
            isInPosition = false;
            image.raycastTarget = true;
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerRectTransform);
        }

        public void SetMyKeyBox(KeyBox[] _keyBoxes)
        {
            for(int i = 0; i<_keyBoxes.Length; i++)
            {
                if(_keyBoxes[i].KeyCaseID == keyID)
                {
                    myKeyBox = _keyBoxes[i];
                    break;
                }
            }            
            keyBoxRectTransform = myKeyBox.GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
           // OVSoundRoot.Instance.Mission.ID16PickingKey.Play();
        }
    }
}