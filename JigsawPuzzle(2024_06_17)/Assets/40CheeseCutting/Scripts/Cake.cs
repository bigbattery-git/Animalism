using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.CakeCutting
{
    public class Cake : MonoBehaviour
    {
        private Image image;
        [SerializeField] private Sprite[] cakeSprites;

        private void Awake()
        {
            image = GetComponent<Image>();
        }
        public void SetCakeSprite(int _cakeIndex)
        {
            image.sprite = cakeSprites[_cakeIndex];
        }
    }
}
