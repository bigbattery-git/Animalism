using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIHUDRoleContext
{
    /*
    private bool isKillable;
    private bool hasSpectialAbility;
    */
    public enum KillerJob
    {
        CleanerTool, SniperTool, BlackmailerTool, AssassinTool, PartyDuckTool, PartisanTool
    }

    #region ������Ƽ
    public bool IsKillable { get; }
    public bool HasSpectialAbility { get; }
    public KillerJob KillerJobList { get; }
    #endregion
}