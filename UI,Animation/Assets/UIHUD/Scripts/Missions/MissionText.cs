using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MissionText : MonoBehaviour, IPointerClickHandler
{
    public event Action<IUIHUDMissionContext.OVUIMission> OnClickedMissionListHandler;
    public IUIHUDMissionContext.OVUIMission ovUIMission;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickedMission();
    }
    public void OnClickedMission()
    {
        OnClickedMissionListHandler?.Invoke(ovUIMission);
    }
    private void Update()
    {
        if(ovUIMission != null)
        text.text = ovUIMission.Name;
    }
}