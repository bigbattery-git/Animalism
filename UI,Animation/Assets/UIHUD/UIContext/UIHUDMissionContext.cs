using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/OVMissionContext", fileName = "OVMissionContext")]
public class UIHUDMissionContext : ScriptableObject, IUIHUDMissionContext
{
    [SerializeField] [Range(0,1)] private float missionGage;
    [SerializeField] private int completedMissionCount;
    [SerializeField] private int needToCompletedMissionCount;
    [SerializeField] private int missionItemMaxCount;
    [SerializeField] private List<IUIHUDMissionContext.OVUIMission> ovUIMissions;
    [SerializeField] private bool isOpenedMissionBox;
    [SerializeField] private IUIHUDMissionContext.OVUIMission grabbedMission;
    public float MissionGage => missionGage;

    public int CompletedMissionCount => completedMissionCount;

    public int NeedToCompletedMissionCount => needToCompletedMissionCount;

    public int MissionItemMaxCount => missionItemMaxCount;

    public List<IUIHUDMissionContext.OVUIMission> OVUIMissions => ovUIMissions;

    public bool IsOpenedMissionBox { get { return isOpenedMissionBox; } set { isOpenedMissionBox = value; } }

    public IUIHUDMissionContext.OVUIMission GrabbedMission => grabbedMission;

    public void Init()
    {
        grabbedMission = null;
        isOpenedMissionBox = false;
    }

    public void OnClickedMisisonPanal()
    {
        isOpenedMissionBox = isOpenedMissionBox == false ? true : false;
    }

    public void OnClickedMissionList(IUIHUDMissionContext.OVUIMission _mission)
    {
        if(grabbedMission == _mission)
        {
            grabbedMission = null;
            return;
        }
        grabbedMission = _mission;
        Debug.Log(grabbedMission.Name);
    }
}