using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Missons.Village.Sabotage_Trashbox
{
    public class Mark : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public int markId;

        [SerializeField] private Sprite inactiveMark;
        [SerializeField] private Sprite activeMark;

        private Image image;

        private ToInputMark toInputMark;
        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            image.sprite = activeMark;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            toInputMark.OnClickMark(markId);
            // OVSoundRoot.Instance.Mission.PushSabotageButton.Play();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = inactiveMark;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.sprite = activeMark;
        }

        public void SetToInputMark(ToInputMark mark) => toInputMark = mark;
    }
}