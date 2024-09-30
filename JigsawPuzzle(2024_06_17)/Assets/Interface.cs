using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOVMisison
{
    public void Show();
    public void Hide();
    public void OnMissionCleared();
    public bool IsAppeared { get; }
    public event Action MissionCompletedHandler;
    public event Action MissionCancleHandler;
}
