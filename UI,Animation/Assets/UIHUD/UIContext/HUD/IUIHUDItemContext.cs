using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIHUDItemContext
{
    public string ItemKey { get; }
    public string ItemImagePath { get; }
    public string ItemExplain { get; }
    public bool HasResultHUD { get; }
    public string ResultHUD { get; }
    public bool HasItem { get; }
    public bool CanUseItem { get; }
    public Sprite ResultImage { get; }

    public void OnClickedItemButton();
    public void OnEnterItemButton();
    public void OnExitItemButton();
}
