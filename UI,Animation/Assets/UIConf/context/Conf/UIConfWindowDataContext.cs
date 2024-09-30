using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Context/Conf/WindowData", fileName = "WindowDataContext", order = 1)]
public class UIConfWindowDataContext : ScriptableObject, IUIConfWindowContext
{
    [SerializeField] private int totalPlayerCount;
    [SerializeField] private bool isOpenedConfWindow;
    [SerializeField] private bool hasPlayerList;
    [SerializeField] private List<IUIConfWindowContext.PlayerConfInfo> playerList;

    public int TotalPlayerCount => totalPlayerCount;

    public bool IsOpenedConfWindow => isOpenedConfWindow;

    public bool HasPlayerList => hasPlayerList;

    public List<IUIConfWindowContext.PlayerConfInfo> PlayerList => playerList;

    public void OnClickedMap()
    {
        Debug.Log("Map이 열렸습니다.");
    }
}
