using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class QuickMatchFailedEnterRoomHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text txtErrorTitle;
    [SerializeField] private TMP_Text txtErrorExplain;
    [SerializeField] private Button btnErrorExit;

    private void Awake()
    {
        btnErrorExit.onClick.RemoveAllListeners();
        btnErrorExit.onClick.AddListener(() => gameObject.SetActive(false));
    }
    public void Init()
    {
        gameObject.SetActive(true);
    }
}
