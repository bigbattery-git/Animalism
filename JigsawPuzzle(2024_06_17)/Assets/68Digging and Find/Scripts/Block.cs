using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.DiggingAndFinding
{
    public class Block : MonoBehaviour, IPointerClickHandler
    {
        private Image image;
        private DiggingAndFindManager manager;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (manager.IsClear) return;

            OVSoundRoot.Instance.Mission.ID79MovingTrash.Play();
            gameObject.SetActive(false);
        }

        public void Init(Sprite _sprite, DiggingAndFindManager _manager)
        {
            if (!image) image = GetComponent<Image>();
            image.sprite = _sprite;

            manager = _manager;
        }
    }
}