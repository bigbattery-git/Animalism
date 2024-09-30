using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SabotageButton : MonoBehaviour, IPointerClickHandler
{
    private ContextHolder holder;
    [SerializeField] private Text txtSabotageKey;
    [SerializeField] private GameObject sabotagePanal;
    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickSabotageButton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(holder.MafiaContext.SabotageKey))
        {
            OnClickSabotageButton();
        }

        txtSabotageKey.text = holder.MafiaContext.SabotageKey.ToUpper();
    }

    private void OnClickSabotageButton()
    {
        holder.MafiaContext.OnClickedSabotageButtonAction();
        sabotagePanal.SetActive(holder.MafiaContext.IsOpenedSabotagePanel);
    }
}
