using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListSpace : MonoBehaviour
{
    [SerializeField] private StoreInventory storeInventory;
    [SerializeField] private GameObject itemSpacePrefab;
    [SerializeField] private Transform contentTransform;
    
    private List<ItemSpace> itemSpaces = new List<ItemSpace>();

    private const int SpawnItemSpaceCount = 100;
    private void Awake()
    {
        Init();
        storeInventory.OnClickItemTagHandler += SetItemSpace;
        SetItemSpace(Category.Skin);
    }

    private void Init()
    {
        for(int i = 0; i< SpawnItemSpaceCount; i++)
        {
            var itemSpace = Instantiate(itemSpacePrefab, contentTransform).GetComponent<ItemSpace>();

            itemSpaces.Add(itemSpace);
        }
    }

    public void SetItemSpace(Category _category)
    {
        List<StoreInventoryItemCommonData> data = storeInventory.GetItemData(_category);

        int i = 0;
        for(;i<data.Count; i++)
        {
            itemSpaces[i].InitItemSpace(data[i]);
            itemSpaces[i].gameObject.SetActive(true);
        }

        for(;i<SpawnItemSpaceCount; i++)
        {
            itemSpaces[i].gameObject.SetActive(false);
        }
    }
}
