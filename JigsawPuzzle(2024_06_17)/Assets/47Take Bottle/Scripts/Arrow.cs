using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.TakeBottle
{
    public class Arrow : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private Sprite arrow;
        [SerializeField] private Sprite arrowClicked;
        [SerializeField] private Sprite arrowTouched;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }
        private void OnEnable()
        {
            image.sprite = arrow;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            image.sprite = arrowClicked;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.sprite = arrow;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = arrowTouched;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            image.sprite = arrowTouched;
        }
    }
}