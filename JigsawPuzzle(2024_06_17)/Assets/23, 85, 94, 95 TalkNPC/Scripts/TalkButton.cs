using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.TalkNPC
{
    public class TalkButton : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
    {
        private int buttonID;
        private Text text;

        private TalkManager manager;

        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite onMouseSprite;
        [SerializeField] private Sprite clickedSprite;

        private Image image;
        private void Awake()
        {
            text = GetComponentInChildren<Text>();
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            image.sprite = normalSprite;
        }

        public void SetManager(TalkManager _manager) => manager = _manager;

        public void SetTextID(int _buttonID, string _text)
        {
            if (!text)
            {
                text = GetComponentInChildren<Text>();
            }

            buttonID = _buttonID;
            text.text = _text;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            image.sprite = onMouseSprite;
            manager.SetNextText(buttonID);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.sprite = normalSprite;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            image.sprite = clickedSprite;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = onMouseSprite;
        }
    }
}