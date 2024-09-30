using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMatchScreen : MonoBehaviour
{
    private Action OnShow;
    private Action OnInit;
    private Action OnHide;

    [SerializeField] private GameObject screen;

    private QuickMatchContext context;

    private bool isAlreadyShowed = false;
    private void Awake()
    {
        screen.SetActive(false);
        context = FindObjectOfType<QuickMatchContext>();
    }

    [ContextMenu("OnShow")]
    public void Show()
    {
        if (!isAlreadyShowed)
        {
            OnInit?.Invoke();
            isAlreadyShowed = true;
        }                   
        screen.SetActive(true);

        OnShow?.Invoke();
    }

    [ContextMenu("OnHide")]
    public void Hide()
    {
        screen.SetActive(false);
        OnHide?.Invoke();
    }
    public void AddOnShow(Action _func) => OnShow += _func;
    public void AddOnHide(Action _func) => OnHide += _func;
    public void AddOnInit(Action _func) => OnInit += _func;
}
