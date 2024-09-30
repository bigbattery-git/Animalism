using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTag : MonoBehaviour
{
    private Category tagCategory;
    private StoreInventory storeInventory;

    private Button btn;

    private TMPro.TextMeshProUGUI txtTag;
    public void SetCategory(Category _category) => tagCategory = _category;
    public void Init(Category _category, StoreInventory _storeInventory)
    {
        tagCategory = _category;
        storeInventory = _storeInventory;

        btn = GetComponent<Button>();
        txtTag = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(OnClickItemTag);
    }
    public void OnClickItemTag()
    {
        storeInventory.OnClickItemTag(tagCategory);
    }

    private void Update()
    {
        txtTag.text = tagCategory.ToString();
    }
}