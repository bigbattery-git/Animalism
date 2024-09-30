using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ContextHolder holder;

    [SerializeField] private Text txtItemKey;
    [SerializeField] private GameObject itemExplainBox;
    [SerializeField] private HUDAlramPanel hudAlramPanel;

    [Header("ItemImage GameObject Name")]
    [SerializeField] private string itemImageName;

    private Text txtExplain;
    private Image imgItemButton;
    private Button btnItemButton;

    private bool isOnMouseEnter = false;
    private GameObject itemImageGameObj;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();

        btnItemButton = GetComponent<Button>();
        imgItemButton = GetComponent<Image>();
        txtExplain = itemExplainBox.GetComponentInChildren<Text>();

        btnItemButton.onClick.AddListener(ActiveItem);
        hudAlramPanel.gameObject.SetActive(false);
    }
    private void Update()
    {

        if (!String.IsNullOrEmpty(holder.ItemContext.ItemKey))
        {
            if (Input.GetKeyDown(KeyChecker(holder.ItemContext.ItemKey)))
            {
                ActiveItem();
            }
        }

        // imgItemImage.sprite = Resources.Load<Sprite>(holder.ItemContext.ItemImagePath);

        txtItemKey.text = holder.ItemContext.ItemKey;
        txtExplain.text = holder.ItemContext.ItemExplain;
        
        if(itemImageGameObj == null &&  holder.ItemContext.HasItem == true)
        {
            itemImageGameObj = Instantiate(Resources.Load<GameObject>(itemImageName),this.transform);
        }

        // SetItemIconColor();
    }
    private void ActiveItem()
    {        
        if (holder.ItemContext.HasResultHUD && holder.ItemContext.HasItem)
        {
            hudAlramPanel.gameObject.SetActive(true);
        }

        holder.ItemContext.OnClickedItemButton();

        Destroy(itemImageGameObj);
        itemImageGameObj = null;
    }
    private string KeyChecker(string _key)
    {
        switch (_key)
        {
            case "ESC":
                return "Escape";
            default:
                return _key;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        holder.ItemContext.OnExitItemButton();
        itemExplainBox.SetActive(false);

        isOnMouseEnter = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (holder.ItemContext.HasItem)
        {
            holder.ItemContext.OnEnterItemButton();
            itemExplainBox.SetActive(true);

            isOnMouseEnter = true;
        }
    }

    private void SetItemIconColor(Image imgItemImage)
    {
        if(btnItemButton.interactable == false)
        {
            imgItemImage.color = btnItemButton.colors.disabledColor;
        }

        else if(isOnMouseEnter == true)
        {
            imgItemImage.color = btnItemButton.colors.highlightedColor;
        }

        else
        {
            imgItemImage.color = btnItemButton.colors.normalColor;
        }
    }
}
