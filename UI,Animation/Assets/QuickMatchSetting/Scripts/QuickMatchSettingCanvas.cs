using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMatchSettingCanvas : MonoBehaviour
{
    private Canvas canvas;
    private const string MainCamera = "MainCamera";

    private void Awake()
    {
        canvas = GetComponent<Canvas>();

        if(canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = GameObject.FindWithTag(MainCamera).GetComponent<Camera>();
        }
    }
}
