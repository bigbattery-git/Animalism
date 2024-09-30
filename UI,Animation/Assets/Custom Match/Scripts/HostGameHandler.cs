using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CO;

public class HostGameHandler : MonoBehaviour
{
    [SerializeField] private HostGameContext context;

    [SerializeField] private GameObject hostGameScreen;
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnPrivate;
    [SerializeField] private Button btnPublic;

    [SerializeField] private HostGameMode[] hostGameModes;

    [SerializeField] private Sprite[] roomStateClickedSprites;
    [SerializeField] private Sprite[] roomStateSprites;

    [SerializeField] private Sprite[] modeSprites;
    [SerializeField] private Sprite[] modeClickedSprites;

    [SerializeField] private CustomMatchFailedEnterRoom failedMakeRoom;

    private LobbyData lobbyData = new LobbyData();
    private void Awake()
    {
        btnBack.onClick.AddListener(Onhide);
        btnPlay.onClick.AddListener(OnClickPlay);
        btnSetting.onClick.AddListener(() => context.OnClickSettingButton());

        btnPrivate.onClick.AddListener(() => SetRoomOpenOrNot(false));
        btnPublic.onClick.AddListener(() => SetRoomOpenOrNot(true));
        
        ResetCurrentGameMode();        
    }
    private void Start()
    {
        Setup();

        context.OnFailedCreateRoom += () => failedMakeRoom.gameObject.SetActive(true);
    }
    public void OnShow()
    {
        hostGameScreen.SetActive(true);

        SetLobbyDataOnShow();
    }

    private void SetLobbyDataOnShow()
    {
        lobbyData = new LobbyData();

        lobbyData.Mode = ModeType.OVIlLAGE;
        lobbyData.IsPublic = false;
    }

    public void Onhide()
    {
        ResetCurrentGameMode();
        hostGameScreen.SetActive(false);
        context.CloseSettingDeco();
    }

    public void Setup()
    {
        for (int i = 0; i < hostGameModes.Length; i++)
        {
            hostGameModes[i].Setup((ModeType)i, OnClickGameMode);
        }

        ResetCurrentGameMode();
    }

    public void OnClickGameMode(ModeType _gameModeSO)
    {
       // Debug.Log("You Clicked GameMode : " + _gameModeSO);

        lobbyData.Mode = _gameModeSO;
        SetModeImage();
    }

    private void SetModeImage()
    {
        for(int i = 0; i < hostGameModes.Length; i++)
        {
            Image image = hostGameModes[i].ModeImage;

            image.sprite = modeSprites[i];
        }

        hostGameModes[(int)lobbyData.Mode].ModeImage.sprite = modeClickedSprites[(int)lobbyData.Mode];
    }
    public void OnClickPlay()
    {
        context.OnClickPlay?.Invoke(lobbyData);
    }

    public void SetRoomOpenOrNot(bool _isPublic)
    {
        InitRoomStateButtonSprite();

        lobbyData.IsPublic = _isPublic;

        int privateSprite = 0;
        int publicSprite = 1;
        if (!_isPublic)
        {
            btnPrivate.GetComponent<Image>().sprite = roomStateClickedSprites[privateSprite];
        }
        else 
        {
            btnPublic.GetComponent<Image>().sprite = roomStateClickedSprites[publicSprite];
        }
    }
    
    private void InitRoomStateButtonSprite()
    {
        int privateSprite = 0;
        int publicSprite = 1;

        btnPrivate.GetComponent<Image>().sprite = roomStateSprites[privateSprite];
        btnPublic.GetComponent<Image>().sprite = roomStateSprites[publicSprite];
    }
    private void ResetCurrentGameMode()
    {
        SetLobbyDataOnShow();
        SetRoomOpenOrNot(false);
        SetModeImage();
    }
}