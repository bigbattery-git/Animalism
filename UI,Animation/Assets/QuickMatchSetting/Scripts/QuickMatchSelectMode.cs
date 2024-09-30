using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CO;
using System;
using UnityEngine.Events;

public class QuickMatchSelectMode : MonoBehaviour
{
    [SerializeField] private Button btnMode;
    [SerializeField] private Image image;

    public Image Image { get => image; set => image = value; }

    public void Setup(UnityAction _buttonAction)
    {
        btnMode.onClick.AddListener(_buttonAction);
    }
}