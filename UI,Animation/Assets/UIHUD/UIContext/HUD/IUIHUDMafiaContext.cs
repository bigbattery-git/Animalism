using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIHUDMafiaContext
{
    /*
    private string sabotageKey;
    private float sabotageCoolTime;
    private bool canSabotage;
    private bool isOpenedSabotagePanel;
    */
    public void OnClickedSabotageButtonAction();
    #region 프로퍼티
    public string SabotageKey { get; }
    public float SabotageCoolTime { get; }
    public bool CanSabotage { get; }
    public bool IsOpenedSabotagePanel { get; }
    #endregion
}
