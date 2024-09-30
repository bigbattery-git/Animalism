using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixingHandle : MonoBehaviour
{
    [SerializeField] private float scrollbarSize = 0.125f;
    private Scrollbar scrollbar;

    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    public void OnMoveHandle(float _size)
    {
        scrollbar.size = _size;
    }
    private void LateUpdate()
    {
        OnMoveHandle(scrollbarSize);
    }
}
