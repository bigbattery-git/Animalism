using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
public class MissinDropbox : MonoBehaviour, IPointerClickHandler
{
    [Header("UI")]
    [SerializeField] private Image imgTotalMissionGage;
    [SerializeField] private Text txtMissionCount;

    [Header("Prefab")]
    [SerializeField] private GameObject missionText;
    [SerializeField] private GameObject missionTextDropbox;

    private ContextHolder holder;
    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();

        InstantiateTextDropbox();

        holder.MissionContext.Init();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        holder.MissionContext.OnClickedMisisonPanal();
    }

    private void Update()
    {
        missionTextDropbox.SetActive(holder.MissionContext.IsOpenedMissionBox);
        SetUI();
    }

    private void SetUI()
    {
        txtMissionCount.text = $"{holder.MissionContext.CompletedMissionCount}/{holder.MissionContext.MissionItemMaxCount}";
        imgTotalMissionGage.fillAmount = holder.MissionContext.MissionGage;
    }
    private void InstantiateTextDropbox()
    {
        if (holder.MissionContext.OVUIMissions.Count < 1)
            return;

        for(int i = 0; i<holder.MissionContext.OVUIMissions.Count; i++)
        {
            MissionText txt = Instantiate(missionText.gameObject, missionTextDropbox.transform).AddComponent<MissionText>();
            txt.ovUIMission = holder.MissionContext.OVUIMissions[i];
            txt.OnClickedMissionListHandler += holder.MissionContext.OnClickedMissionList;
        }
    }
}