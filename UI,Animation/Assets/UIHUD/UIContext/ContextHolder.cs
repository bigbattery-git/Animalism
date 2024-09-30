using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextHolder : MonoBehaviour
{
    [SerializeField] private UIHUDMissionContext missionContext;
    [SerializeField] private UIHUDPublicContext publicContext;
    [SerializeField] private UIHUDMafiaContext mafiaContext;
    [SerializeField] private UIHUDBeableButtonContext beableButtonContext;
    [SerializeField] private UIHUDRoleContext roleContext;
    [SerializeField] private UIHUDItemContext itemContext;
    public UIHUDMafiaContext MafiaContext => mafiaContext;
    public UIHUDMissionContext MissionContext => missionContext;
    public UIHUDPublicContext PublicContext => publicContext;
    public UIHUDBeableButtonContext BeableButtonContext => beableButtonContext;
    public UIHUDRoleContext RoleContext => roleContext;
    public UIHUDItemContext ItemContext => itemContext;
}