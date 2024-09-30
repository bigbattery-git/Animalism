using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.weighing
{
    public class TrashBox : MonoBehaviour
    {
        [SerializeField] private Sprite normalBox;
        [SerializeField] private Sprite openBox;

        private Image image;

        private GameObject weighObj;
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        private void Update()
        {
            if(Input.GetMouseButtonUp(0) && weighObj)
            {
                Destroy(weighObj);
                weighObj = null;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                image.sprite = openBox;
                weighObj = collision.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                image.sprite = normalBox;
                weighObj = null;
            }
        }
    }
}