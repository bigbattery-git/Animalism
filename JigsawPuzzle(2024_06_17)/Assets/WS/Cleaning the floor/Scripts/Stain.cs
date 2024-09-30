using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Missons.Village.CleaningTheFloor
{
    public class Stain : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        private Image image;
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        public void ChangeStainSprite()
        {
            image.sprite = sprite;
        }
    }
}