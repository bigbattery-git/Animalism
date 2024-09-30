using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.ShakingOffAPillow
{
    public class Pillow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private ShakingOffAPillowManager manager;
        [SerializeField] private Sprite beforePushedSprite;
        [SerializeField] private Sprite pushedSprite;

        private Image image;
        private void Start()
        {
            image = GetComponent<Image>();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            image.sprite = beforePushedSprite;
            manager.AddPressCount();
            manager.IsClear();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!manager.IsClear())
                image.sprite = pushedSprite;

            OVSoundRoot.Instance.Mission.ID21ShakingPillow.Play();
        }
    }
}