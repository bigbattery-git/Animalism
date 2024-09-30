using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CO;

public class HostGameMode : MonoBehaviour
{
    [SerializeField] private Image modeImage;
    [SerializeField] private Button btnMode;
    [SerializeField] private TextMeshProUGUI txtModeName;
                     private ModeType gameMode;
                     private int gameModeID;

    public Image ModeImage => modeImage;
    public ModeType GameMode => gameMode;

    public void Setup(ModeType _gameMode, Action<ModeType> _func)
    {
        gameMode = _gameMode;

        btnMode.onClick.AddListener(() => _func(gameMode));
    }
}