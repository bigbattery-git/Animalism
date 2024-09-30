using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenHandler : MonoBehaviour
{
    
    private MainScreenContext context;

    [Header("Button")]
    [SerializeField] private Button btnQuickPlay;
    [SerializeField] private Button btnCustomGame;
    [SerializeField] private Button btnPropShop;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        context = FindObjectOfType<MainScreenContext>();

        btnQuickPlay.onClick.AddListener(() => context.OnClickQuickPlay?.Invoke());
        btnCustomGame.onClick.AddListener(() => context.OnClickCustomGame?.Invoke());
        btnPropShop.onClick.AddListener(() => context.OnClickPropShop?.Invoke());
        btnSetting.onClick.AddListener(() => context.OnClickSetting?.Invoke());
        btnExit.onClick.AddListener(() => context.OnClickExit?.Invoke());        
    }
}