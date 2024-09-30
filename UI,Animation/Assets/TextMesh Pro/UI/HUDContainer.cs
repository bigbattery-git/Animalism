using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDContainer : MonoBehaviour, IHUDContainer
{
    private bool isOperated;
    private IHUDContainer.STATE state;
    public bool IsOperated => isOperated;

    public IHUDContainer.STATE State => state;

    public void Hide()
    {
        
    }

    public void PlayReport()
    {
        
    }

    public void PlayRing()
    {
        
    }

    public void Show()
    {
       
    }
}
