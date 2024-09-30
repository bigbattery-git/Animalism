using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIHUDMissionContext
{
    /*
    private float missionGage;
    private int missionCount;
    private int missionItemMaxCount;
    private List<OVUIMission> ovUIMissions;
    private bool isOpenedMissionBox;
    */
    [System.Serializable]
    public class OVUIMission
    {
        public int Id;
        public string Name;
        public bool IsCompleted;
        public bool IsGrabbed;
    }
    #region 프로퍼티
    public float MissionGage { get; }

    public int CompletedMissionCount { get; }

    public int NeedToCompletedMissionCount { get; }
    public int MissionItemMaxCount { get;}

    public List<OVUIMission> OVUIMissions { get; }

    public bool IsOpenedMissionBox { get; set; }
    public OVUIMission GrabbedMission { get; }
    #endregion
    public void OnClickedMisisonPanal();
    public void OnClickedMissionList(OVUIMission _mission);
}