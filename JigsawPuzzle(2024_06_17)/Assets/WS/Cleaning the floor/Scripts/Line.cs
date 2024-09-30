using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.CleaningTheFloor
{
    public class Line : MonoBehaviour
    {
        [SerializeField] float scrollSpeed = 0.5f;
        float offset;

        Image image;
        private void Start()
        {
            image = GetComponent<Image>();
        }
        private void Update()
        {
            offset += Time.deltaTime * scrollSpeed;
            image.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}