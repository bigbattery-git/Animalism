using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/OVRoleContext", fileName = "OVRoleContext")]
public class UIHUDRoleContext : ScriptableObject, IUIHUDRoleContext
{

    [SerializeField] private bool isKillable;
    [SerializeField] private bool hasSpectialAbility;
    [SerializeField] private IUIHUDRoleContext.KillerJob killerJobList;
    public bool IsKillable => isKillable;

    public bool HasSpectialAbility => hasSpectialAbility;

    public IUIHUDRoleContext.KillerJob KillerJobList => killerJobList;
}
