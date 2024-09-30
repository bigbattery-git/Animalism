using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ConfJobAbilityImgData
{
    public string name;
    public GameObject imageObject;
    public GameObject nameObject;
}
public class ConfJobAbility : MonoBehaviour
{
    private ConfContextHolder holder;

    [Header("Button")]
    [SerializeField] private Button btnLeft;
    [SerializeField] private Button btnRight;

    [Header("Image Data")]
    [SerializeField] private ConfJobAbilityImgData[] imgDatas;
    [SerializeField] private GameObject jobImageBox;
    [SerializeField] private GameObject jobNameBox;

    [Header("Panal")]
    [SerializeField] private GameObject[] jobPanals;
    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ConfContextHolder>();

        btnLeft.onClick.AddListener(() => holder.MafiaAbility.OnClickArrowButton(0));
        btnLeft.onClick.AddListener(ChangeJobPannal);
        btnRight.onClick.AddListener(() => holder.MafiaAbility.OnClickArrowButton(1));
        btnRight.onClick.AddListener(ChangeJobPannal);

        SpawnJobImageName(holder.MafiaAbility.JobPrefabPaths[0].prefabPath.Length, (int)IUIConfMafiaAblilityContext.PanalType.TownPeople, IUIConfMafiaAblilityContext.PanalType.TownPeople);
        SpawnJobImageName(holder.MafiaAbility.JobPrefabPaths[1].prefabPath.Length, (int)IUIConfMafiaAblilityContext.PanalType.Variation, IUIConfMafiaAblilityContext.PanalType.Variation);
        SpawnJobImageName(holder.MafiaAbility.JobPrefabPaths[2].prefabPath.Length, (int)IUIConfMafiaAblilityContext.PanalType.Mafia, IUIConfMafiaAblilityContext.PanalType.Mafia);

        ChangeJobPannal();
    }

    private void SpawnJobImageName(int _spawnCount, int _jobType, IUIConfMafiaAblilityContext.PanalType _type)
    {
        for(int i = 0; i < _spawnCount; ++i)
        {
            GameObject jobObj = Instantiate(jobImageBox, imgDatas[_jobType].imageObject.transform);
            Image name = Instantiate(jobNameBox, imgDatas[_jobType].nameObject.transform).GetComponent<Image>();

            Image image = jobObj.GetComponent<Image>();
            ConfJobIcon jobIcon = jobObj.AddComponent<ConfJobIcon>();
            Button btn = jobObj.GetComponent<Button>();

            image.sprite = Resources.Load<Sprite>($"RoleData/{holder.MafiaAbility.JobPrefabPaths[(int)_type].prefabPath[i]}");
            jobIcon.iconInfo = new ConfJobIconInfo { jobID = Convert.ToInt32(holder.MafiaAbility.JobPrefabPaths[(int)_type].prefabPath[i]) };
            btn.onClick.AddListener(() => holder.MafiaAbility.OnClickedJobIcon(jobIcon.iconInfo));


            name.sprite = Resources.Load<Sprite>($"RoleDataName/{holder.MafiaAbility.JobPrefabPaths[(int)_type].prefabPath[i]}");
        } 
    }

    private void ChangeJobPannal()
    {
        for(int i = 0; i < (int)IUIConfMafiaAblilityContext.PanalType.MaxSize; ++i)
        {
            if (i == (int)holder.MafiaAbility.MafiaAbliityPanalState)
            {
                jobPanals[i].SetActive(true);
                continue;
            }
            jobPanals[i].SetActive(false);
        }
    }
}