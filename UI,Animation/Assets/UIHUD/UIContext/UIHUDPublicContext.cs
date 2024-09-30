using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/OVPublicContext", fileName = "OVPublicContext")]
public class UIHUDPublicContext : ScriptableObject, IUIHUDPublicContext
{

    [SerializeField] private string ringKey;
    [SerializeField] private bool isRing;
    [SerializeField] private bool isInCorpse;
    [SerializeField] private string reportKey;
    [SerializeField] private string jobImagePath;
    [SerializeField] private string jobName;
    [SerializeField] private string jobExplain;
    [SerializeField] private bool wasTurnOnMike;
    [SerializeField] private string mikeKey;
    [SerializeField] private string mikeImagePath;
    [SerializeField] private IUIHUDPublicContext.Team team_;

    public string RingKey => ringKey;

    public bool IsRing => isRing;

    public bool IsInCorpse => isInCorpse;

    public string JobImagePath => jobImagePath;

    public string JobName => jobName;

    public string JobExplain => jobExplain;

    public IUIHUDPublicContext.Team Team_ => team_;

    public bool WasTrunOnMike => wasTurnOnMike;

    public string MikeKey => mikeKey;

    public string MikeImagePath => mikeImagePath;

    public string ReportKey => reportKey;

    public void OnClickOptionButton()
    {
        Debug.Log("You Clicked Option Button");
    }

    public void OnClickMapButton()
    {
        Debug.Log("You clicked map button");
    }

    public void OnClickMikeButton()
    {
        Debug.Log("You Clicked Mike Button");
        wasTurnOnMike = WasTrunOnMike == false ? true : false;

        if (WasTrunOnMike) Debug.Log("Mike on!");
        else Debug.Log("Mike off!");
    }
    public void OnClickSelectButton()
    {
        Debug.Log("Select Button");
    }

    public void OnClickRingButton()
    {
        Debug.Log("Ring Ring");
    }

    public void OnEnterJobInfoImage()
    {
        Debug.Log(jobExplain);
    }

    public void OnExitJobInfoImage()
    {
        Debug.Log("Stop introduce job");
    }

    public void OnClickReportButton()
    {
        if (!isInCorpse)
            return;
        Debug.Log("Report Corpse");
    }
}