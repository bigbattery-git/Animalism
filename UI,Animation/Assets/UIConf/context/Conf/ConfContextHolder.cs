using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfContextHolder : MonoBehaviour
{
    [SerializeField] private UIConfMafiaAbilityContext mafiaAbility;
    [SerializeField] private UIConfWindowDataContext windowData;
    [SerializeField] private UIConfChatData chatData;
    [SerializeField] private UIConfPublicData publicData;
    [SerializeField] private UIConfETCEvent etcEvent;
    public UIConfMafiaAbilityContext MafiaAbility => mafiaAbility;
    public UIConfWindowDataContext WindowData => windowData;
    public UIConfChatData ChatData => chatData;
    public UIConfPublicData PublicData => publicData;
    public UIConfETCEvent ETcEvent => etcEvent;
}
