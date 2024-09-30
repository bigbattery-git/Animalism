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
        // ���� ��� ������ �ؽ�Ʈ ���� �ѱ��, 999999+�� ���
        if(_moneyAmount > MAXTXTMONEY)
        {
            return "999999+";
        }

        // ���� ������ �ִ� ��ȭ�� ���
        return _moneyAmount.ToString(); 
    }

    public void OnClickPlusButton()
    {
        Debug.Log("��ư Ŭ��");
    }
}