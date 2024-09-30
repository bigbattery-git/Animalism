using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using CO;

public class FilterHandler : MonoBehaviour
{
    [SerializeField] private CustomMatchContext customMatchContext;
    
    [Header("Dropdown")]
    [SerializeField] private TMP_Dropdown dropdownLanguage;
    [SerializeField] private TMP_Dropdown dropdownMode;
    [SerializeField] private TMP_Dropdown dropdownVoiceType;

                     private const string DropdownUpper = "ALL";
                     /// <summary>
                     /// 0 : Language
                     /// 1 : Mode
                     /// 2 : Type
                     /// </summary>
                     private int[] beforeDropdownValue = new int[3];

    [Header("Title")]
    [SerializeField] private Button btnBack;
    [SerializeField] private GameObject filterContext;

    private void Awake()
    {
        Setup();
        
        btnBack.onClick.AddListener(OnClickBackButton);
    }

    public void ResetBeforeDropdownValue()
    {
        for (int i = 0; i < beforeDropdownValue.Length; i++)
            beforeDropdownValue[i] = 0;
    }

    public void OnShowHandler()
    {
        filterContext.SetActive(true);        
    }

    public void OnHideHandler()
    {
        filterContext.SetActive(false);
    }

    public void OnClickBackButton()
    {
        dropdownLanguage.value = beforeDropdownValue[0];
        dropdownMode.value = beforeDropdownValue[1];
        dropdownVoiceType.value = beforeDropdownValue[2];

        OnHideHandler();
    }

    private void Setup()
    {
        List<TMP_Dropdown.OptionData> languageData = new List<TMP_Dropdown.OptionData>();
        List<TMP_Dropdown.OptionData> modeData = new List<TMP_Dropdown.OptionData>();
        List<TMP_Dropdown.OptionData> voiceTypeData = new List<TMP_Dropdown.OptionData>();

        languageData.Add(new TMP_Dropdown.OptionData(DropdownUpper));
        modeData.Add(new TMP_Dropdown.OptionData(DropdownUpper));
        voiceTypeData.Add(new TMP_Dropdown.OptionData(DropdownUpper));

        for(int i = 0; i< (int)Language.MAXSIZE; i++)
            languageData.Add(new TMP_Dropdown.OptionData(((Language)i).ToString()));

        for (int i = 0; i < (int)ModeType.MAXSIZE; i++)
            modeData.Add(new TMP_Dropdown.OptionData(((ModeType)i).ToString()));

        for (int i = 0; i < (int)ServerVoiceType.MAXSIZE; i++)
            voiceTypeData.Add(new TMP_Dropdown.OptionData(((ServerVoiceType)i).ToString()));

        dropdownLanguage.options.Clear();
        dropdownMode.options.Clear();
        dropdownVoiceType.options.Clear();

        dropdownLanguage.AddOptions(languageData);
        dropdownMode.AddOptions(modeData);
        dropdownVoiceType.AddOptions(voiceTypeData);
    }

    /// <summary>
    /// [0] : GameSeverLanguageSO
    /// [1] : GameModeSO
    /// [2] : ServerVoiceType
    /// </summary>
    /// <returns></returns>
    public List<int> GetFilterData()
    {
        List<int> returnData = new List<int>()
        {
            dropdownLanguage.value,
            dropdownMode.value,
            dropdownVoiceType.value 
        };

        return returnData;
    }

    public void ResetDropdown()
    {
        dropdownLanguage.value = 0;
        dropdownMode.value = 0;
        dropdownVoiceType.value = 0;
    }

    public void SetBeforeDropdownValue(int _languageValue, int _modeValue, int _voiceValue)
    {
        beforeDropdownValue[0] = _languageValue;
        beforeDropdownValue[1] = _modeValue;
        beforeDropdownValue[2] = _voiceValue;
    }
}