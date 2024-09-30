using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Missons.Village.OpenTheBox
{
    public class Box_ : MonoBehaviour, IPointerClickHandler
    {
        public Image Image { get; private set; }
        [SerializeField] private OpenTheBoxManager manager;
        public int BoxNum => boxNum;

        [SerializeField] private Sprite closedBox;
        [SerializeField] private Sprite openedBox;
        [SerializeField] private int boxNum;
        private bool isOpened;
        private void Awake()
        {
            Image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            Image.sprite = closedBox;
            isOpened = false;
            Image.raycastTarget = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isOpened && !manager.IsClear)
            {
                OVSoundRoot.Instance.Mission.ID81OpeningBox.Play();

                Image.sprite = openedBox;
                isOpened = true;
                Image.raycastTarget = false;

                manager.CheckClear(this);
            }
        }
    }
}