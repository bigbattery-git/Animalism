using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSpace : MonoBehaviour
{
    [SerializeField] private StoreInventoryItemCommonData itemData;

    [SerializeField] private Button btnItemSpace;
    [SerializeField] private Image imgItemSprite;
    [SerializeField] private TextMeshProUGUI txtItemName;


    [Header("Equip Button")]
    [SerializeField] private TextMeshProUGUI txtCurrentItemState;
    [SerializeField] private Image imgPriceType;
    [SerializeField] private Button btnEquipment;

    [Header("Price Type")]
    [SerializeField] private Sprite goldPriceImage;
    [SerializeField] private Sprite rainbowPriceImage;
    private void Awake()
    {
        InitItemSpace(itemData);

        txtItemName.raycastTarget = false;
        txtCurrentItemState.raycastTarget = false;
    }

    public void InitItemSpace(StoreInventoryItemCommonData _itemData = null)
    {
        if (_itemData == null) return;

        itemData = _itemData;
        imgItemSprite.sprite = itemData.Image;
        txtItemName.text = itemData.Name;

        btnItemSpace.onClick.RemoveAllListeners();
        btnItemSpace.onClick.AddListener(OnClickItemSpace);

        SetPriceTypeImage(itemData.PriceType);
        txtCurrentItemState.text = itemData.Price.ToString();

        if (itemData.Category == Category.GoldMoney || itemData.Category == Category.RainbowMoney) return;

        SetEquipMentButton(itemData.IsPurchased);

        if (!itemData.IsPurchased)
        {
            return;
        }
        else if (!itemData.IsEquiped)
        {
            txtCurrentItemState.text = "Equip";
        }
        else
        {
            txtCurrentItemState.text = "Equiped";
        }
    }

    public void OnClickItemSpace()
    {
        Debug.Log($"이름 : {itemData.Name}");
        Debug.Log($"가격 : {itemData.Price}");
        Debug.Log($"이름 : {itemData.Category}");
    }
    private void SetEquipMentButton(bool _isPurchased)
    {
        var imgEquipment = btnEquipment.GetComponent<Image>();
        if( !_isPurchased)
        {
            btnEquipment.enabled = false;
            imgEquipment.raycastTarget = false;
            return;
        }

        btnEquipment.enabled = true;
        imgEquipment.raycastTarget = true;
    }
    private void SetPriceTypeImage(PriceType _priceType)
    {
        imgPriceType.gameObject.SetActive(true);
        switch (_priceType)
        {
            case PriceType.Gold:
                imgPriceType.sprite = goldPriceImage;
                break;
            case PriceType.Rainbow:
                imgPriceType.sprite = rainbowPriceImage;
                break;
            case PriceType.Money:
                imgPriceType.gameObject.SetActive(false);
                break;
        }
    }
}