using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimHelper : MonoBehaviour
{
    [SerializeField] GameObject marker;

    Image image;
    Vector2 originalSize;
    void Start()
    {
        image = GetComponent<Image>();
        originalSize = image.rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseWidth();
        DecreaseWidth();
    }
    void IncreaseWidth()
    {
        if (Input.GetMouseButton(0))
        {
            float mousedistence = (GetComponent<RectTransform>().anchoredPosition - marker.GetComponent<RectTransform>().anchoredPosition).magnitude;

            // Debug.Log("MousePosition: " + Input.mousePosition);
            Debug.Log(mousedistence);

            image.rectTransform.sizeDelta = new Vector2(mousedistence - 55f, originalSize.y);

            LookMouse();
        }        
    }
    void LookMouse()
    {
        Vector3 dir = this.transform.position - marker.transform.position;
        float angle = Mathf.Atan2(- dir.y, - dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void DecreaseWidth()
    {
        if (Input.GetMouseButtonUp(0))
        {
            image.rectTransform.sizeDelta = originalSize;
        }
    }
}
