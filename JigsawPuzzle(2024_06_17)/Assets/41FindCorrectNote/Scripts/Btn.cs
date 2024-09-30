using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Missons.Village.FindCorrectNote
{
    public class Btn : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Square Button")]
        [SerializeField] private Sprite btnNormal;
        [SerializeField] private Sprite btnTouched;
        [SerializeField] private Sprite btnPressed;
        private Image image;

        [Header("Icon Button")]        
        [SerializeField] private Sprite iconPlay;
        [SerializeField] private Sprite iconReplay;
        [SerializeField] private Image iconImage;
        public UnityEvent OnClick;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            image.sprite = btnTouched;
            OnClick?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
           image.sprite = btnPressed;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = btnTouched;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.sprite = btnNormal;
        }

        public void InitStart()
        {
            image.sprite = btnNormal;
            iconImage.sprite = iconPlay;
        }
        public void InitCheckClear() => image.sprite = btnNormal;
        public void SetReplayIcon()
        {
            image.sprite = btnNormal;
            iconImage.sprite = iconReplay;
        }
    }
}