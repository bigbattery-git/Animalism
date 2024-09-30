using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.OpenTheMap
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Sprite[] mapSprites;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            image.sprite = mapSprites[0];
        }

        public void UpdateMap(int _mapSequence)
        {
            image.sprite = mapSprites[_mapSequence];
        }
    }
}