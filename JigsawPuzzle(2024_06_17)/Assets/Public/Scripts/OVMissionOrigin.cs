using System;
using UnityEngine;
using UnityEngine.UI;
public abstract class OVMissionOrigin : MonoBehaviour
{
    public bool IsAppeared => missionObject.activeInHierarchy;

    public event Action<int> MissionCompleteHandler;
    public int MissionInstanceId { get { return missionID; } set { missionID = value; } }

    public int missionID;
    public GameObject missionObject;
    public Button backButton;

    public const float WaitTime = 3f;
    public virtual void Awake()
    {
        backButton.onClick.AddListener(Hide);

        Hide();
    }
    [ContextMenu("Show")]
    public virtual void Show()
    {
        CancelInvoke(nameof(Hide));

        missionObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }
    [ContextMenu("Hide")]
    public virtual void Hide()
    {
        missionObject.gameObject.SetActive(false);
    }
    [ContextMenu("MissionClear")]
    public virtual void MissionClear()
    {
        if (MissionCompleteHandler != null) MissionCompleteHandler(missionID);
        backButton.gameObject.SetActive(false);

        Invoke(nameof(Hide), WaitTime);
    }
    public virtual void MissionFailed()
    {
        backButton.gameObject.SetActive(false);        
        Invoke(nameof (Hide), WaitTime);
    }
}
