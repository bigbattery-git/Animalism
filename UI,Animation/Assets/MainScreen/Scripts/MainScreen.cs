using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private GameObject screen;

    private Action OnShow;
    private Action OnHide;

    private MainScreenContext context;

    private void Awake()
    {
        context = FindObjectOfType<MainScreenContext>();

        gameObject.SetActive(false);
    }
    public void Show()
    {
        screen.SetActive(true);
    }

    public void Hide()
    {
        screen.SetActive(false);
        context.CloseSettingDeco?.Invoke();
    }

    public void AddOnShow(Action _func) => OnShow += _func;
    public void AddOnHide(Action _func) => OnHide += _func;
}
