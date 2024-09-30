using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CO;

public class QuickMatchGameModeLanghageHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    private int currentOptionValue = 0;

    private QuickMatchHandler quickMatchHandler;
    private QuickMatchScreen quickMatchScreen;
    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        quickMatchHandler = FindObjectOfType<QuickMatchHandler>(true);
        Init();

        quickMatchScreen = FindObjectOfType<QuickMatchScreen>(true);
    }

    private void Start()
    {
        quickMatchScreen.AddOnShow(() => OnValueChanged(0));
    }

    public void Init()
    {
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> optionDatas = new List<TMP_Dropdown.OptionData>();

        for(int i = 0; i<(int)Language.MAXSIZE; i++)
        {
            optionDatas.Add(new TMP_Dropdown.OptionData(GetLanguageString(i)));
        }

        dropdown.AddOptions(optionDatas);

        dropdown.onValueChanged.AddListener(OnValueChanged);
    }

    public void OnValueChanged(int _num)
    {
        currentOptionValue = _num;
        dropdown.value = currentOptionValue;
        quickMatchHandler.lobbyData.Language = (Language)_num;
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
}
