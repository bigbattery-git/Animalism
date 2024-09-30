using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stain : MonoBehaviour
{
    // RectTransform m_stains;
    // RectTransform rect;
    Image m_image;

    
    private void Awake()
    {
        m_image = GetComponent<Image>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MiniGameObject"))
        {
            m_image.color -= new Color(0f, 0f, 0f, 0.3f);
            if (m_image.color.a < 0f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}