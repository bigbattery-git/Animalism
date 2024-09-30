using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIHUDBeableButtonContext
{
    /*
    private string killKey;
    private bool canKill;
    private float killCooltime;

    private string abilityImagePath;
    private float abilityCoolTime;
    private string abilityKey;
    */
    public void OnClickedKillButton();
    public void OnClickedAbilityButton();
    #region 프로퍼티
    public string KillKey { get; }
    public bool CanKill { get; }
    public float KillCooltime { get; }
    public float KillCooltimeCount { get; }
    public float KillCooltimeSniper { get; }
    public float KillCooltimeSniperCount { get; }

    public string AbilityImagePath { get; }
    public float AbilityCoolTime { get; }
    public float AbilityCoolTimeCount { get; }
    public string AbilityKey { get; }
    public bool IsActiveAbility { get; }
    #endregion
}
