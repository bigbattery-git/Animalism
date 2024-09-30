using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/OVBeableButtonContext", fileName = "OVBeableButtonContext")]
public class UIHUDBeableButtonContext : ScriptableObject, IUIHUDBeableButtonContext
{

    [SerializeField] private string killKey;
    [SerializeField] private bool canKill;
    [SerializeField] private float killCooltime;
    [SerializeField] private float killCooltimeCount;
    [SerializeField] private float killCooltimeSniper;
    [SerializeField] private float killCooltimeSniperCount;
    [SerializeField] private string abilityImagePath;
    [SerializeField] private float abilityCoolTime;
    [SerializeField] private float abilityCoolTimeCount;
    [SerializeField] private string abilityKey;
    [SerializeField] private bool isActiveAbility;
    public string KillKey => killKey;

    public bool CanKill => canKill;

    public float KillCooltime => killCooltime;

    public string AbilityImagePath => abilityImagePath;

    public float AbilityCoolTime => abilityCoolTime;
    public float AbilityCoolTimeCount => abilityCoolTimeCount;

    public string AbilityKey => abilityKey;

    public bool IsActiveAbility => isActiveAbility;

    public float KillCooltimeCount => killCooltimeCount;

    public float KillCooltimeSniper => killCooltimeSniper;

    public float KillCooltimeSniperCount => killCooltimeSniperCount;

    public void OnClickedAbilityButton()
    {
        if (!isActiveAbility)
        {
            Debug.Log("이건 패시브 능력입니다.");
            return;
        }
        Debug.Log("능력 사용!");
    }

    public void OnClickedKillButton()
    {
        if (!canKill) return;
        if(killCooltimeCount > 0)
        {
            Debug.Log("아직 쿨타임이 있습니다!");
            return;
        }

        killCooltimeCount = killCooltime;
        Debug.Log("킬 사용!");
    }
    public void ResetKillCooltimeCount() => killCooltimeCount = 0;
}
