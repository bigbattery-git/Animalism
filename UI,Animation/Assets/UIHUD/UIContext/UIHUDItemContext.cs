using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/OV Item Context", fileName = "OVItemContext")]
public class UIHUDItemContext : ScriptableObject, IUIHUDItemContext
{
    [SerializeField] private string itemKey;
    [SerializeField] private string itemImagePath;
    [SerializeField] private string itemExplain;
    [SerializeField] private bool hasResultHUD;
    [SerializeField] private string resultHUD;
    [SerializeField] private bool hasItem;
    [SerializeField] private bool canUseItem;
    [SerializeField] private Sprite resultImage;
    public string ItemKey => itemKey;

    public string ItemImagePath => itemImagePath;

    public string ItemExplain => itemExplain;

    public bool HasResultHUD => hasResultHUD;

    public string ResultHUD => resultHUD;

    public bool HasItem => hasItem;

    public bool CanUseItem => canUseItem;

    public Sprite ResultImage => resultImage;

    public void OnClickedItemButton()
    {
        if (hasItem == false)
        {
            Debug.Log("You aren't have Item!");
            return;
        }
        if(canUseItem == false)
        {
            Debug.Log("Now, You can't use this Item!");
            return;
        }

        Debug.Log("Use Item!");

        hasItem = false;
        itemImagePath = string.Empty;
    }
    public void OnClickedItemButton(Sprite _imagePath, string _explain)
    {
        resultImage = _imagePath;
        resultHUD = _explain;

        OnClickedItemButton();
    }
    public void OnEnterItemButton()
    {
        Debug.Log("Item introduce");
    }

    public void OnExitItemButton()
    {
        Debug.Log("Stop introduce item");
    }

    public void ResetResultHUD()
    {
        hasResultHUD = false;
        resultImage = null;
        itemExplain = null;
    }
}