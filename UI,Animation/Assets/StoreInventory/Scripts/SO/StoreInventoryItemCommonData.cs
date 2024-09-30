using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category { Skin, Pet, Emoticon, Tomb, Head, GoldMoney, RainbowMoney, MaxSize }
public enum PriceType { Gold, Rainbow, Money, MaxSize}
[CreateAssetMenu(menuName = "StoreInventory/ItemCommonData", fileName = "CommonData_")]
public class StoreInventoryItemCommonData : ScriptableObject
{
    public string Name;         // ������ �̸�
    public Sprite Image;        // ������ �̹���
    public float Price;         // ������ ����
    public PriceType PriceType; // ������ ���� ����
    public Category Category;   // ������ ����
    public string Explain;      // ������ ����
    public bool IsPurchased;    // ������ ���ſ���
    public bool IsEquiped;      // ������ ��������
}