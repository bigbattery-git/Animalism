using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoreInventory : MonoBehaviour
{
    [SerializeField] private List<StoreInventoryItemCommonData> itemDatas = new List<StoreInventoryItemCommonData>();

    public Action<Category> OnClickItemTagHandler;
    public List<StoreInventoryItemCommonData> GetItemData(Category _category = Category.Skin)
    {
        var linQItemData = from data in itemDatas
                             where data.Category == _category
                             select data;

        List<StoreInventoryItemCommonData> returnData = linQItemData.ToList<StoreInventoryItemCommonData>();

        return returnData;
    }

    public void OnClickItemTag(Category _category)
    {
        OnClickItemTagHandler?.Invoke(_category);
    }
}