using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MikeButton : MonoBehaviour
{
    private ContextHolder holder;

    [SerializeField] private Button btnMikeButton;
    [SerializeField] private Image imgMikeButton;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        btnMikeButton.onClick.AddListener(holder.PublicContext.OnClickMikeButton);
    }

    private void Update()
    {
        imgMikeButton.sprite = Resources.Load<Sprite>(holder.PublicContext.MikeImagePath);
    }
}
