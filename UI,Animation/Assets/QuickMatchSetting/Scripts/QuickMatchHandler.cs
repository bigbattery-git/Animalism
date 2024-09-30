using CO;
using UnityEngine;
using UnityEngine.UI;

public class QuickMatchHandler : MonoBehaviour
{
    private QuickMatchContext context;

    [SerializeField] private Button btnCustomize;
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnSetting;
    [SerializeField] private QuickMatchFailedEnterRoomHandler failedHandler;
    [SerializeField] private QuickMatchMatchingHandler matchingHandler;

                     private QuickMatchScreen quickMatchScreen;
    public LobbyData lobbyData { get; set; }

    private bool isMatching;

    private float findLobbyTime = 3f;
    private float findLobbyTimeCount = 0f;

    private void Awake()
    {
        context = FindObjectOfType<QuickMatchContext>();

        btnCustomize.onClick.AddListener(() => context.OnClickCustomizeButton?.Invoke());
        btnPlay.onClick.AddListener(() => { isMatching = true; matchingHandler.gameObject.SetActive(true); }); // Matching start, Matching Screen Open
        btnSetting.onClick.AddListener(() => context.OnClickSettingButton?.Invoke());
        btnBack.onClick.AddListener(() => context.OnClickBackButton?.Invoke());

        quickMatchScreen = GetComponent<QuickMatchScreen>();        

        matchingHandler.Setup(() => { isMatching = false; findLobbyTimeCount = 0; });
    }
    private void OnHide()
    {
        isMatching = false;
        findLobbyTimeCount = 0;
        context.CloseSettingDeco();
    }
    private void OnShow()
    {
        lobbyData = new LobbyData();

        lobbyData.Mode = ModeType.OVIlLAGE;
    }
    private void Start()
    {
        quickMatchScreen.AddOnShow(OnShow);

        quickMatchScreen.AddOnHide(OnHide);
    }

    private void Update()
    {
        if (isMatching)
        {
            findLobbyTimeCount += Time.deltaTime;

            if(findLobbyTimeCount > findLobbyTime)
            {
                findLobbyTime = 3f;
                MatchLobby();
                findLobbyTimeCount = 0f;
            }
        }
    }

    private void MatchLobby()
    {
        LobbyData _tringToEnterLobbyData = null;

        if (context.LobbyDatas == null) return;

        // Find correct lobbydata 
        for(int i = 0; i<context.LobbyDatas.Count; i++)
        {
            LobbyData _lobbydata = context.LobbyDatas[i];

            if (!_lobbydata.IsPublic) continue;

            if(_lobbydata.Mode == lobbyData.Mode && _lobbydata.Language == lobbyData.Language && _lobbydata.VoiceType == lobbyData.VoiceType)
            {
                if (!_lobbydata.IsStarted)
                {
                    _tringToEnterLobbyData = _lobbydata;
                    break;
                }
            }
        }

        // Tring to enter lobby if '_tringToEnterLobbyData isn't Null'
        if(_tringToEnterLobbyData != null)
        {
            context.TryToEnterRoom?.Invoke(_tringToEnterLobbyData.RoomName);
            findLobbyTime = 5f;
        }
    }
}