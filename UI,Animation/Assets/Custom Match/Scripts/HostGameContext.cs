using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CO;
public abstract class HostGameContext : MonoBehaviour
{
    public abstract Action<LobbyData> OnClickPlay { get; }
    public abstract Action OnFailedCreateRoom { get; set; }
    public abstract Action OnClickSettingButton { get; }
    public abstract Action CloseSettingDeco { get; }
}