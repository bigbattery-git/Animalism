using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVCamera : MonoBehaviour
{

    public float widthRate;
    public float heightRate;
    // public Camera camera;

    void Awake()
    {
        // camera = GetComponent<Camera>();
    }

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        GetComponent<Camera>().rect = setResoultion();
    }

    void Update()
    {
        // camera.rect = setResoultion();
        Screen.SetResolution(1920, 1080, true);
        transform.position = new Vector3(0, 0, -10);
    }

    private Rect setResoultion()
    {
        Rect rect = new Rect();

        float scaleheight = ((float)Screen.width / Screen.height) / ((float)widthRate / heightRate); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;

        if (scaleheight == 1f)
        {
            rect.height = scaleheight;
            rect.width = scalewidth;
            rect.x = 0;
            rect.y = 0;
        }
        else if (scaleheight < 1f)
        {
            rect.height = 1.0f;
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        else if (scaleheight > 1f)
        {
            rect.height = 1f;
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }

        return rect;
    }
}