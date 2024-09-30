using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CustomMatchFailedEnterRoom : MonoBehaviour
{
    [SerializeField] private TMP_Text txtErrorTitle;
    [SerializeField] private TMP_Text txtErrorExplain;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnExit.onClick.RemoveAllListeners();
        btnExit.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void OnHide()
    {
        //Debug.Log(gameObject.name);
        gameObject.SetActive(false);
    }
}
