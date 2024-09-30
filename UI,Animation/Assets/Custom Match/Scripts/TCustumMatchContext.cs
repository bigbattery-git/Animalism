using System;
using System.Collections.Generic;
using UnityEngine;
using CO;

public class TCustumMatchContext : CustomMatchContext
{    
    public override Action<string> OnClickedRoomBox =>(t) =>  Debug.Log("You Clicked room ID : " + t);
    [Header("Lobby Data")]
    [SerializeField] private List<LobbyData> lobbyDatas = new List<LobbyData>();

    private ServerVoiceType voiceType;
    public ServerVoiceType VoiceType => voiceType;

    public override Action RecieveJoinRoomFailMassage { set { a =  value; } }
    private Action a;
    public override List<LobbyData> LobbyDatas { get => lobbyDatas;}

    public override Action OnClickBackButton => () => Debug.Log("You Clicked Back Button");

    public override Action OnClickSettingButton => () => Debug.Log("You Clicked Setting Button");

    public override Action CloseSettingDeco => () => Debug.Log("Close Setting");

    public override Action <string> TryToJoinGame => (t) => Debug.Log($"You Tring To Join Game : {t}"); 
    public void AddLobbyData(LobbyData _lobbyData)
    {
        lobbyDatas.Add(_lobbyData);
    }

    [ContextMenu("ActionRecive")]
    public void ActionRecieveFailJoinRoom()
    {
        a?.Invoke();
        RecieveJoinRoomFailMassage = () => Debug.Log("AAA");
    }
}