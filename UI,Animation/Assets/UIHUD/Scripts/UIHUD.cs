using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIHUDComponent
{
    public string componentName;
    public GameObject component;
}
public class UIHUD : MonoBehaviour, IHUDContainer
{
    private bool isOperated;
    private float deactiveTime = 3f;
    public bool IsOperated => isOperated;

    public IHUDContainer.STATE State => throw new System.NotImplementedException();

    [SerializeField] private UIHUDComponent[] huds;

    [ContextMenu("IHUDContainer/Hide")]
    public void Hide()
    {
        foreach(UIHUDComponent h in huds)
            h.component.SetActive(false);
    }

    [ContextMenu("IHUDContainer/PlayReport")]
    public void PlayReport()
    {
        ShowWannaHUD("Report");
        StartCoroutine(DeactiveHUD());
    }

    [ContextMenu("IHUDContainer/PlayRing")]
    public void PlayRing()
    {
        ShowWannaHUD("Ring");
        StartCoroutine(DeactiveHUD());
    }

    [ContextMenu("IHUDContainer/Show")]
    public void Show()
    {
        ShowWannaHUD("HUDButton");
    }

    private void ShowWannaHUD(string _wannaHUDName)
    {
        foreach (UIHUDComponent h in huds)
        {
            if (h.componentName == _wannaHUDName)
            {
                h.component.SetActive(true);
                break;
            }
        }
    }
    private IEnumerator DeactiveHUD()
    {
        yield return new WaitForSeconds(deactiveTime);

        Hide();
    }
}
