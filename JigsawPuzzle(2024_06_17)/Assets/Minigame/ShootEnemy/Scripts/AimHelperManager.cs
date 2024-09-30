using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimHelperManager : MonoBehaviour
{
    [SerializeField] GameObject marker;
    [SerializeField] Image[] images;

    Vector2[] originalSizes;
    void Awake()
    {
        originalSizes = new Vector2[images.Length];
        for(int i = 0; i < images.Length; ++i)
        {
            originalSizes[i] = images[i].GetComponent<RectTransform>().sizeDelta;
        }
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
            for (int i = 0; i < images.Length; ++i)
            {
                float mousedistence = (images[i].GetComponent<RectTransform>().anchoredPosition - marker.GetComponent<RectTransform>().anchoredPosition).magnitude;

                images[i].rectTransform.sizeDelta = new Vector2(mousedistence - 55f, originalSizes[i].y);

                LookMouse();
            }

        }
    }
    void LookMouse()
    {
        Vector3 dir = this.transform.position - marker.transform.position;
        float angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void DecreaseWidth()
    {
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < images.Length; ++i)
                images[i].rectTransform.sizeDelta = originalSizes[i];
        }
    }
}
