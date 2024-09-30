using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CO;

public class QuickMatchGameModeVoiceHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private int currentOptionValue;
    private QuickMatchHandler quickMatchHandler;
    private QuickMatchScreen quickMatchScreen;
    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        quickMatchHandler = FindObjectOfType<QuickMatchHandler>(true);
        quickMatchScreen = FindObjectOfType<QuickMatchScreen>(true);
       
        Init();
    }

    private void Start()
    {
        quickMatchScreen.AddOnShow(() => OnValueChanged(0));
    }

    public void Init()
    {
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData> ();

        for(int i = 0; i < (int)ServerVoiceType.MAXSIZE; i++)
        {
            data.Add(new TMP_Dropdown.OptionData(GetServerVoiceType(i)));
        }

        dropdown.AddOptions(data);

        dropdown.onValueChanged.AddListener (OnValueChanged);
    }

    private void OnValueChanged(int _num)
    {
        currentOptionValue = _num;

        dropdown.value = currentOptionValue;

        quickMatchHandler.lobbyData.VoiceType = (ServerVoiceType)_num;
    }
    public string GetServerVoiceType(int _num)
    {
        if (_num != (int)ServerVoiceType.VOICE)
            return "Text";

        return "Text/Voice";
    }
}
