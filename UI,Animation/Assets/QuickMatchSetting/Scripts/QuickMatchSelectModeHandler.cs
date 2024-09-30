using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CO;
using System.Linq;

public class QuickMatchSelectModeHandler : MonoBehaviour
{
    [SerializeField] private QuickMatchSelectMode[] quickMatchSelectModes;
    private QuickMatchHandler quickMatchHandler;

    [SerializeField] private Sprite[] defaultSprite;
    [SerializeField] private Sprite[] selectSprite;

    private QuickMatchScreen quickMatchScreen;
    private void Awake()
    {
        quickMatchHandler = FindObjectOfType<QuickMatchHandler>(true);

        for(int i = 0; i< quickMatchSelectModes.Length; i++)
        {
            int actionNum = i;
            quickMatchSelectModes[i].Setup(() => SelectMode(actionNum));
        }

        quickMatchScreen = FindObjectOfType<QuickMatchScreen>(true);        
    }

    private void Start()
    {
        SelectMode(0);

        quickMatchScreen.AddOnShow(() => SelectMode(0));
    }
    public void SelectMode(int _modeNum)
    {
        SetDefaultSelectImage();

        quickMatchSelectModes[_modeNum].Image.sprite = selectSprite[_modeNum];

        quickMatchHandler.lobbyData.Mode = (ModeType)_modeNum;
    }

    private void SetDefaultSelectImage()
    {
        for(int i = 0; i<defaultSprite.Length; i++)
        {
            quickMatchSelectModes[i].Image.sprite = defaultSprite[i];
        }
    }
}
