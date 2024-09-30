using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.FindCorrectNote
{
    public class Note : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Vector2 maxSize;

        private float scaleTime = 0f;

        private Image image;
        private Canvas canvas;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            maxSize = rectTransform.sizeDelta;

            rectTransform.sizeDelta = maxSize / 4f;
        }
        private void Update()
        {
            scaleTime += Time.deltaTime * 2f;

            switch (canvas.renderMode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    transform.Translate(Vector3.left * Time.deltaTime * 300f);
                    break;
                default:
                    transform.Translate(Vector3.left * Time.deltaTime * 2f);
                    break;
            }
            rectTransform.sizeDelta = Vector2.Lerp(maxSize / 4f, maxSize, scaleTime);
        }

        public void Init(Sprite _noteSprite, Canvas _canvas)
        {
            if(!image) image = GetComponent<Image>();

            image.sprite = _noteSprite;
            canvas = _canvas;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == "Note Destroy Position")
            {
                Destroy(this.gameObject);
            }
        }
    }
}