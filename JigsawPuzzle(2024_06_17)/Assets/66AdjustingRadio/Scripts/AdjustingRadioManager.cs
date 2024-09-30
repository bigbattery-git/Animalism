using Missons.Village.AdjustingRadio;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AdjustingRadioManager : OVMissionOrigin
{
    private bool isClear = false;
    private Gear[] gears;
    private Frequency[] frequencys;

    private FrequencyBlack frequencyBlack;


    [SerializeField]
    private float frequencyDistance = 1.0f;
    public bool IsClear => isClear;

    private void Start()
    {
        gears = GetComponentsInChildren<Gear>(true);
        frequencys = GetComponentsInChildren<Frequency>(true);

        Canvas canvas = GetComponent<Canvas>();
        foreach (Gear gear in gears)
        {
            gear.Setup(this, canvas);
        }
        foreach (Frequency frequency in frequencys)
        {
            frequency.Setup(this, canvas);
            if (frequencyBlack == null)
            {
                frequencyBlack = frequency.GetComponent<FrequencyBlack>();
            }
        }
    }

    [ContextMenu("Override Show")]
    public override void Show()
    {
        base.Show();

        isClear = false;

        foreach(var frequency in frequencys)
        {
            frequency.SetAnchorTransform(Random.Range(0f, 1f));
        }

        foreach(var gear in gears)
        {
            gear.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        frequencyBlack.SetAlphaAndSoundValueWhenShowMission(Random.Range(0f, 0.4f));
    }

    public override void Hide()
    {
        base.Hide();
    }
    public void CheckClear()
    {
        int beforeindex = 0;
        for(int i = 0; i<frequencys.Length; i++)
        {
            if (i == 0) continue;

            float distance = Mathf.Abs(frequencys[beforeindex].anchorTransform.x - frequencys[i].anchorTransform.x);

            if (distance > frequencyDistance)
                return;

            beforeindex++;
        }

        if (!frequencyBlack.IsClearReady) return;

        beforeindex = 0;

        for(int i = 0; i<frequencys.Length; i++)
        {
            if(i == 0) continue;

            frequencys[i].SetAnchorRectTransformPosition(frequencys[beforeindex].anchorTransform);
        }

        MissionClear();
    }

    public override void MissionClear()
    {
        base.MissionClear();

        isClear = true;
    }
}