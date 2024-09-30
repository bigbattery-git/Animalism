using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CO;

public class CustomMatchHandler : MonoBehaviour
{
    private CustomMatchContext customMatchContext;
    [SerializeField] private CustomMatchScreen customMatchScreen;
    [Header("Back, Setting")]
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnSetting;

    [Header("Lobby")]
    [SerializeField] private GameObject lobbyPrefab;
    [SerializeField] private Transform lobbySpawnTransform;
    [SerializeField] private List<LobbyData> LobbyDatas => customMatchContext.LobbyDatas;
                     private float refreshTime = 0;
                     private float refreshCoolTime = 1f;
                     private float doubleClickTime = 0;
                     private float doubleClickCoolTime = 0.5f;

                     private List<Lobby> lobbies = new List<Lobby>();
    [SerializeField] private Sprite lobbySprite;
    [SerializeField] private Sprite lobbyClickedSprite;

    [Header("Under Button")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnHostGame;
    [SerializeField] private TMP_InputField roomCodeInputField;
    [SerializeField] private Button btnJoinGame;

    [Header("Left Button")]
    [SerializeField] private Button btnRefresh;
    [SerializeField] private Button btnFilter;

    [Header("HostGame")]
    [SerializeField] private HostGameHandler hostGameHandler;

    [Header("Filter")]
    [SerializeField] private FilterHandler filterContext;
                     private List<LobbyData> filterLobbyDatas = new List<LobbyData>();
    [SerializeField] private Button btnFilterApply;

    [Header("Error")]
    [SerializeField] private CustomMatchFailedEnterRoom failedEnterRoom;    

    private string tappedRoomName;
    private void Awake()
    {
        customMatchContext = FindObjectOfType<CustomMatchContext>();        
    }
    private void Start()
    {
        SpawnLobby(LobbyDatas);
        btnPlay.onClick.AddListener(() => JoinRoom(tappedRoomName));
        btnRefresh.onClick.AddListener(RefreshLobby);
        btnHostGame.onClick.AddListener(hostGameHandler.OnShow);
        btnJoinGame.onClick.AddListener(TryToEnterGame);
        btnFilter.onClick.AddListener(filterContext.OnShowHandler);
        btnFilterApply.onClick.AddListener(SpawnFilterLobby);

        btnBack.onClick.AddListener(() => customMatchContext.OnClickBackButton());
        btnSetting.onClick.AddListener(() => customMatchContext.OnClickSettingButton());

        customMatchScreen.AddOnShow(OnShow);
        customMatchScreen.AddOnHide(OnHide);

        customMatchContext.RecieveJoinRoomFailMassage = failedEnterRoom.Setup;
    }

    public void OnShow()
    {
        filterContext.OnHideHandler();
        filterLobbyDatas.Clear();
        filterContext.ResetDropdown();
        filterContext.ResetBeforeDropdownValue();

        roomCodeInputField.text = "";

        RemoveAllLobby();
        SpawnLobby(LobbyDatas);

        hostGameHandler.Onhide();
    }

    private void OnHide()
    {
        failedEnterRoom.OnHide();
        customMatchContext.CloseSettingDeco?.Invoke();
        hostGameHandler.Onhide();
    }

    public void OnClickRoomBoxIns(string _roomName, Image _image)
    {
        tappedRoomName = _roomName;

        if(IsDoubleClick() && (_roomName == tappedRoomName))
        {
            JoinRoom(_roomName);
        }

        ResetLobbyImage(_roomName);
        _image.sprite = lobbyClickedSprite;
    }

    private void ResetLobbyImage(string _roomName)
    {
        foreach(var lobby in lobbies)
        {
            lobby.LobbyImage.sprite = lobbySprite;
        }
    }
    public void JoinRoom(string _roomName)
    {
        if (string.IsNullOrEmpty(_roomName))
        {
            Debug.Log("You didn't Click Room");
            return;
        }

        customMatchContext.OnClickedRoomBox?.Invoke(_roomName);
    }

    public void SpawnLobby(List<LobbyData> _lobbyDatas)
    {
        lobbies.Clear();

        List<LobbyData> correctLobbyDatas = new List<LobbyData>();

        int instanceCount = 0;

        for(int i = 0; i<_lobbyDatas.Count; i++)
        {
            if (_lobbyDatas[i].IsStarted) continue;
            if (!_lobbyDatas[i].IsPublic) continue;

            correctLobbyDatas.Add(_lobbyDatas[i]);
        }

        if(correctLobbyDatas.Count > 50)
        {
            instanceCount = 50;
        }
        else
        {
            instanceCount = correctLobbyDatas.Count;
        }

        for (int i = 0; i < instanceCount; i++)
        {
            Lobby clone = Instantiate(lobbyPrefab, lobbySpawnTransform).GetComponent<Lobby>();

            clone.Setup(correctLobbyDatas[i], OnClickRoomBoxIns);

            lobbies.Add(clone);
        }
    }
    public void SpawnFilterLobby()
    {
        RemoveAllLobby();
        filterLobbyDatas.Clear();

        List<int> filterData = filterContext.GetFilterData();

        var filterLinQData = from data in LobbyDatas
                             select data;

        if (filterData[0] != 0)
        {
            filterLinQData = filterLinQData.Where(data => data.Language == (Language)(filterData[0] -1));
        }

        if (filterData[1] != 0)
        {
            filterLinQData = filterLinQData.Where(data => data.Mode == (ModeType)(filterData[1] - 1));
        }

        if (filterData[2] != 0)
        {
            filterLinQData = filterLinQData.Where(data => data.VoiceType == (ServerVoiceType)(filterData[2] - 1));
        }

        filterLobbyDatas = filterLinQData.ToList();

        if (filterData.All(filter => filter == 0))
        {
            SpawnLobby(LobbyDatas);
        }
        else
        {
            SpawnLobby(filterLobbyDatas);
        }

        filterContext.SetBeforeDropdownValue(filterData[0], filterData[1], filterData[2]);
        filterContext.OnHideHandler();
    }
    public void RefreshLobby()
    {
        if (refreshTime < refreshCoolTime)
        {
            Debug.Log("Too much Clicked Refresh Button!");
            return;
        }

        refreshTime = 0f;
        RemoveAllLobby();

        List<int> filterData = filterContext.GetFilterData();

        if (filterData.Any(filter => filter == 0))
        {
            SpawnFilterLobby();
        }
        else
        {
            SpawnLobby(LobbyDatas);
        }

        tappedRoomName = null;
    }
    public void RemoveAllLobby()
    {
        foreach (Transform child in lobbySpawnTransform)
        {
            Destroy(child.gameObject);
        }
    }

    public void TryToEnterGame()
    {
        string roomCode = roomCodeInputField.text;
        int roomCodeCount = 8;

        if (roomCode.Length < roomCodeCount)
        {
            Debug.Log("You need to write code to count 8 ");
            return;
        }
        customMatchContext.TryToJoinGame(roomCode);
    }

    private bool HasLobby(string _roomCode)
    {
        for(int i = 0; i < customMatchContext.LobbyDatas.Count; i++)
        {
            if (customMatchContext.LobbyDatas[i].RoomName == _roomCode)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsDoubleClick()
    {
        if (doubleClickTime > doubleClickCoolTime)
        {
            doubleClickTime = 0;
            return false;
        }
        
        return true;
    }

    private void SetJoinGameButton()
    {
        if(roomCodeInputField.text.Length != 8)
        {
            btnJoinGame.interactable = false;
            return;
        }

        btnJoinGame.interactable = true;
    }
    private void Update()
    {
        refreshTime += Time.deltaTime;
        doubleClickTime += Time.deltaTime;

        SetJoinGameButton();
    }
}