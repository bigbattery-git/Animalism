using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CO;

public abstract class CustomMatchContext : MonoBehaviour
{
    public abstract Action<string> OnClickedRoomBox { get; }
    public abstract Action RecieveJoinRoomFailMassage {set; }
    public abstract Action <string> TryToJoinGame { get; }
    public abstract List<LobbyData> LobbyDatas { get;}
    public abstract Action OnClickBackButton { get; }
    public abstract Action OnClickSettingButton { get; }
    public abstract Action CloseSettingDeco { get; }
}