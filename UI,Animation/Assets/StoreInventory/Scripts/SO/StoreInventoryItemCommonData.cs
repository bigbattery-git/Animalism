using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category { Skin, Pet, Emoticon, Tomb, Head, GoldMoney, RainbowMoney, MaxSize }
public enum PriceType { Gold, Rainbow, Money, MaxSize}
[CreateAssetMenu(menuName = "StoreInventory/ItemCommonData", fileName = "CommonData_")]
public class StoreInventoryItemCommonData : ScriptableObject
{
    public string Name;         // 아이템 이름
    public Sprite Image;        // 아이템 이미지
    public float Price;         // 아이템 가격
    public PriceType PriceType; // 아이템 가격 종류
    public Category Category;   // 아이템 종류
    public string Explain;      // 아이템 설명
    public bool IsPurchased;    // 아이템 구매여부
    public bool IsEquiped;      // 아이템 장착여부
}