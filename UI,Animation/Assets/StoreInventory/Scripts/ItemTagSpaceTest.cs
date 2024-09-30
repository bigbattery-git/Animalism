using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTagSpaceTest : MonoBehaviour
{
    [SerializeField] private StoreInventory storeInventory;
    [SerializeField] private ItemTag[] itemTags;

    private const int MaxCategorySize = (int)Category.MaxSize - 4; // 최대 태그 표시 개수
    private int currentTagNum = 0;                                 // 현재 태그 번호

    private void Awake()
    {
        SetItemTag();
    }

    public void OnClickNextArrowLeft()
    {
        if (currentTagNum == 0) return;
        currentTagNum--;

        SetItemTag();
    }

    public void OnClickNextArrowRight() 
    {
        if (currentTagNum >= MaxCategorySize) return;
        currentTagNum++;

        SetItemTag();
    }

    private void SetItemTag()
    {
        for(int i = 0; i < itemTags.Length; i++)
        {
            itemTags[i].Init((Category)(currentTagNum + i), storeInventory);
        }
    }
}