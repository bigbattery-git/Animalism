using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainScreenContext : MonoBehaviour
{
    public abstract Action OnClickQuickPlay { get; }
    public abstract Action OnClickCustomGame { get; }
    public abstract Action OnClickPropShop { get; }
    public abstract Action OnClickSetting { get; }
    public abstract Action OnClickExit { get; }

    public abstract Action CloseSettingDeco { get; }
}
