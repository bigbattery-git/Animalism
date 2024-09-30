using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTagSpace : MonoBehaviour
{
    [SerializeField] private GameObject itemTagPrefab;
    [SerializeField] private Transform contentTransform;
    [SerializeField] private StoreInventory storeInventory;
    private void Awake()
    {
        for(int i = 0; i < (int)Category.MaxSize; i++)
        {
            SpawnItemTag((Category)i);
        }
    }
    private void SpawnItemTag(Category _category)
    {
        var tag = Instantiate(itemTagPrefab, contentTransform);
        tag.GetComponentInChildren<TextMeshProUGUI>().text = _category.ToString();
        ItemTag itemTag = tag.AddComponent<ItemTag>();

        itemTag.Init(_category, storeInventory);
    }
}
