using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMatchScreen : MonoBehaviour
{
    private Action OnShow;
    private Action OnHide;

    [SerializeField] private GameObject context;

    private void Awake()
    {
        context.SetActive(false);
    }
    [ContextMenu("Show Plses")]
    public void Show()
    {
        context.SetActive(true);

        OnShow?.Invoke();
    }

    [ContextMenu("Hide Plses")]
    public void Hide()
    {
        context.SetActive(false);

        OnHide?.Invoke();
    }

    public void AddOnShow(Action _func) => OnShow += _func;
    public void AddOnHide(Action _func) => OnHide += _func;
}
