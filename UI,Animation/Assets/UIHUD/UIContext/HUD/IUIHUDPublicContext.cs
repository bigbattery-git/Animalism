using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIHUDPublicContext
{
    public enum Team
    {
        TownPeople, Mafia, Variation
    }
    public void OnClickRingButton();
    public void OnClickOptionButton();
    public void OnClickMapButton();
    public void OnClickMikeButton();
    public void OnEnterJobInfoImage();
    public void OnExitJobInfoImage();
    public void OnClickReportButton();
    #region 프로퍼티
    public string RingKey { get; }

    public bool IsRing { get; }

    public bool IsInCorpse { get; }

    public string ReportKey { get; }

    public string JobImagePath { get; }

    public string JobName { get; }

    public string JobExplain { get; }

    public bool WasTrunOnMike { get; }

    public string MikeKey { get; }

    public string MikeImagePath { get; }

    public Team Team_ { get; }

    #endregion
}