using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnBar : MonoBehaviour
{
    private Slider slider;

    [SerializeField] private Text txtVolumn;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        txtVolumn.text = (slider.value * 100).ToString("F0"); 
    }
}
