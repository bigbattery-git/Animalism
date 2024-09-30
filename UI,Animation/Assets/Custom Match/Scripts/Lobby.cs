using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using CO;

public class Lobby : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtHost;
    [SerializeField] private TextMeshProUGUI txtLanguage;
    [SerializeField] private TextMeshProUGUI txtMode;
    [SerializeField] private TextMeshProUGUI txtPlayerCount;
    [SerializeField] private TextMeshProUGUI txtVoiceType;

    private string roomName;

    [SerializeField] private Button btnLobby;

    [SerializeField] private Image lobbyImage;
    public Image LobbyImage => lobbyImage;
    public void Setup(LobbyData _data, Action<string, Image> _act)
    {
        txtHost.text = GetHostName(_data.HostName);
        txtLanguage.text = GetLanguageString((int)_data.Language);
        txtMode.text = _data.Mode.ToString();
        txtPlayerCount.text = $"{_data.CurrentPlayerCount} / {_data.TotalPlayerCount}";
        txtVoiceType.text = GetServerVoiceType((int)_data.VoiceType);

        roomName = _data.RoomName;

        btnLobby.onClick.RemoveAllListeners();
        btnLobby.onClick.AddListener(() => _act(roomName, lobbyImage));
    }

    private string GetHostName(string _hostName)
    {
        if(_hostName.Length <= 6)
        return _hostName;

        return _hostName.Substring(0, 6) + "...";
    }
    private string GetLanguageString(int _num)
    {
        switch ((Language)(_num))
        {
            case Language.KO:
                return "Korean";
            case Language.EN:
                return "English";
            default:
                return null;
        }
    }
    public string GetServerVoiceType(int _num)
    {
        if (_num != (int)ServerVoiceType.VOICE)
            return "Text";

        return "Text/Voice";
    }
}