using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Context/Conf/MafiaAbility", fileName = "MafiaAbilityContext", order = 0)]
public class UIConfMafiaAbilityContext : ScriptableObject, IUIConfMafiaAblilityContext
{
    [SerializeField] private bool isSelectedJob;
    [SerializeField] private bool isSelectedPlayer;
    [SerializeField] private IUIConfMafiaAblilityContext.JobPrefabPath[] jobPrefabPath;
    [SerializeField] IUIConfMafiaAblilityContext.PanalType mafiaAbilityPanalState;
    public bool IsSelectedJob => isSelectedJob;

    public bool IsSelectedPlayer => isSelectedPlayer;

    public IUIConfMafiaAblilityContext.PanalType MafiaAbliityPanalState => mafiaAbilityPanalState;

    public IUIConfMafiaAblilityContext.JobPrefabPath[] JobPrefabPaths => jobPrefabPath;

    public void OnClickedJobIcon(ConfJobIconInfo _info)
    {
        Debug.Log(_info.jobID);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_direction">0 : ¿ÞÂÊ, 1 : ¿À¸¥ÂÊ</param>
    public void OnClickArrowButton(int _direction)
    {
        int nowPanalType = (int)mafiaAbilityPanalState;
        switch (_direction)
        {
            case 0:
                if ((int)mafiaAbilityPanalState == 0)
                    mafiaAbilityPanalState = (IUIConfMafiaAblilityContext.PanalType)2;
                else
                {
                    nowPanalType--;
                    mafiaAbilityPanalState = (IUIConfMafiaAblilityContext.PanalType)nowPanalType;
                }
                break;
            case 1:
                if ((int)mafiaAbilityPanalState == 2)
                    mafiaAbilityPanalState = (IUIConfMafiaAblilityContext.PanalType)0;
                else
                {
                    nowPanalType++;
                    mafiaAbilityPanalState = (IUIConfMafiaAblilityContext.PanalType)nowPanalType;
                }
                break;

            default:
                break;
        }
    }
}