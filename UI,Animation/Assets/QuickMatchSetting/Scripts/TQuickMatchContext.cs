using System;
using System.Collections.Generic;
using UnityEngine;
using CO;

public class TQuickMatchContext : QuickMatchContext
{
    public override Action OnClickCustomizeButton => () => Debug.Log("You Clicked CustomizeButton");

    public override Action OnClickSettingButton => () => Debug.Log("You Clicked Setting Button");

    public override Action OnClickBackButton => () => Debug.Log("You Clicked Back Button");

    public override Action CloseSettingDeco => () => Debug.Log("Close Setting");

    public override List<LobbyData> LobbyDatas { get; set; }

    public override Action<string> TryToEnterRoom =>(t) => Debug.Log($"Try to Enter Room : {t}");
}