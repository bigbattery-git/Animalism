using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    Vector2 originalVector;
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        originalVector = this.transform.position;
        image.color = new Color32(255, 255, 255, 0);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.transform.position = Input.mousePosition;
            image.color = new Color32(255, 255, 255, 50);
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.transform.position = originalVector;
            image.color = new Color32(255, 255, 255, 0);
        }
    }
}
