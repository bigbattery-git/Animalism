using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMainScreenContext : MainScreenContext
{
    public override Action OnClickQuickPlay => QuickPlay;

    public override Action OnClickCustomGame => CustomGame;

    public override Action OnClickPropShop => PropShop;

    public override Action OnClickSetting => Setting;

    public override Action OnClickExit => Exit;

    public override Action CloseSettingDeco => () => Debug.Log("OnClcikedCloseSettingDeco");

    private void QuickPlay()
    {
        Debug.Log("You Clicked QuickPlay");
    }

    private void CustomGame()
    {
        Debug.Log("You Clicked CustomGame");
    }

    private void PropShop()
    {
        Debug.Log("You Clicked PropShop");
    }

    private void Setting()
    {
        Debug.Log("You Clicked Setting");
    }

    private void Exit() 
    {
        Debug.Log("You Clicked Exit");
    }
}
