using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDAlramPanel : MonoBehaviour
{
    [SerializeField] private float setactiveFalseTime = 5f;
    [SerializeField] private Image imgAlramPanel;

    private ContextHolder holder;
    private Text txtAlramPanel;
    
    
    private void Awake()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        txtAlramPanel = GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        txtAlramPanel.text = holder.ItemContext.ResultHUD;
        imgAlramPanel.sprite = holder.ItemContext.ResultImage;

        Invoke("SetActiveFalse", setactiveFalseTime);
    }

    private void SetActiveFalse()
    {
        holder.ItemContext.ResetResultHUD();
        gameObject.SetActive(false);
    }
}
