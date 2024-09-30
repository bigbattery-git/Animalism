using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuickMatchMatchingHandler : MonoBehaviour
{
    [SerializeField] private Button btnCancel;
    private QuickMatchScreen quickMatchScreen;
    private void Awake()
    {
        btnCancel.onClick.AddListener(() => gameObject.SetActive(false));
        quickMatchScreen = FindObjectOfType<QuickMatchScreen>(true);
        
    }

    private void Start()
    {
       quickMatchScreen.AddOnHide(OnHide);
    }

    public void Setup(UnityAction _btnCancelEvent)
    {
        btnCancel.onClick.AddListener(_btnCancelEvent);
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}