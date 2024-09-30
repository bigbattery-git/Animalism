using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CO;

public class THostGameContext : HostGameContext
{
    public override Action<LobbyData> OnClickPlay => (t) => Debug.Log($"you Make Room Mode : {t.Mode} \n you make room public : {t.IsPublic} ");

    public override Action OnFailedCreateRoom { get; set; }

    public override Action OnClickSettingButton => () => Debug.Log("You Clicked SettingButton");

    public override Action CloseSettingDeco => () => Debug.Log("Your Setting is Close");

    [ContextMenu("Failed Make Room")]
    public void OnFailedMakingRoom()
    {
        OnFailedCreateRoom?.Invoke();
    }
}