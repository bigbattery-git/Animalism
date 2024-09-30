using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyLayer : MonoBehaviour
{
    [SerializeField] private StoreInventory storeInventory;

    [SerializeField] private StoreInventoryCurrentMoneyData currentMoneyData;

    [SerializeField] private Button btnGoldMoney;
    [SerializeField] private Button btnRainbowMoney;

    [SerializeField] private Text txtGoldMoney;
    [SerializeField] private Text txtRainbowMoney;

    private const float MAXTXTMONEY = 999999F;

    private void Awake()
    {
        btnGoldMoney.onClick.AddListener(() => storeInventory.OnClickItemTag(Category.GoldMoney));
        btnRainbowMoney.onClick.AddListener(() => storeInventory.OnClickItemTag(Category.RainbowMoney));
    }
    private void Update()
    {
        txtGoldMoney.text = GetMoneyText(currentMoneyData.CurrentGoldMoney);
        txtRainbowMoney.text = GetMoneyText(currentMoneyData.CurrentRainbowMoney);
    }

    private string GetMoneyText(float _moneyAmount) 
    {
        // 만약 출력 가능한 텍스트 수를 넘기면, 999999+를 출력
        if(_moneyAmount > MAXTXTMONEY)
        {
            return "999999+";
        }

        // 현재 가지고 있는 재화를 출력
        return _moneyAmount.ToString(); 
    }

    public void OnClickPlusButton()
    {
        Debug.Log("버튼 클릭");
    }
}