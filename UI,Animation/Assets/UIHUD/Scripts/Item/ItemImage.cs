using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ItemImage : MonoBehaviour
{
    private ContextHolder holder;

    private Image imgItemImage;

    private void Awake()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        imgItemImage = GetComponent<Image>();

        imgItemImage.sprite = Resources.Load<Sprite>($"Item/{holder.ItemContext.ItemImagePath}");
    }
}
