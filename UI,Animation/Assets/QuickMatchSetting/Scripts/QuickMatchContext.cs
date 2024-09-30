using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CO;
using System;
public abstract class QuickMatchContext : MonoBehaviour
{
    public abstract List<LobbyData> LobbyDatas { get; set; }
    public abstract Action<string> TryToEnterRoom { get; }
    public abstract Action OnClickCustomizeButton { get; }
    public abstract Action OnClickSettingButton { get; }
    public abstract Action OnClickBackButton {get;}
    public abstract Action CloseSettingDeco { get; }
}