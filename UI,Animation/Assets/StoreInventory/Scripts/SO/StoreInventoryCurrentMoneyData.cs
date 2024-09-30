using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StoreInventory/CurrentMoneyData", fileName = "CurrentMoney_")]
public class StoreInventoryCurrentMoneyData : ScriptableObject
{
    public float CurrentGoldMoney;
    public float CurrentRainbowMoney;
}