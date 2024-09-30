using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/OVMafiaContext", fileName = "OVMafiaContext")]
public class UIHUDMafiaContext : ScriptableObject, IUIHUDMafiaContext
{
    [SerializeField] private string sabotageKey;
    [SerializeField] private float sabotageCoolTime;
    [SerializeField] private bool canSabotage;
    [SerializeField] private bool isOpenedSabotagePanel;
    public string SabotageKey => sabotageKey;

    public float SabotageCoolTime => sabotageCoolTime;

    public bool CanSabotage => canSabotage;

    public bool IsOpenedSabotagePanel => isOpenedSabotagePanel;

    public void OnClickedSabotageButtonAction()
    {
        if (!canSabotage)
        {
            Debug.Log("Not yet to Sabotage!");
            return;
        }

        if (isOpenedSabotagePanel)
        {            
            Debug.Log("Closed Sabotage");
            isOpenedSabotagePanel = false;
        }

        else
        {
            Debug.Log("Opened Sabotage");
            isOpenedSabotagePanel = true;
        }
    }
}
