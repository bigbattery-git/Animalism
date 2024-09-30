using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRingButton : MonoBehaviour
{
    private ContextHolder holder;
    [SerializeField] Button btnSelectRing;
    [SerializeField] Image imgSelectRing;

    [SerializeField] Sprite ring;
    [SerializeField] Sprite select;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        btnSelectRing.onClick.AddListener(OnClickButton);
    }

    private void Update()
    {
        if(holder.PublicContext.IsRing == true)
        {
            imgSelectRing.sprite = ring;
        }
        else
        {
            imgSelectRing.sprite = select;
        }
        if (!string.IsNullOrEmpty(holder.PublicContext.RingKey))
        {
            if (Input.GetKeyDown(holder.PublicContext.RingKey))
            {
                OnClickButton();
            }
        }
    }
    private void OnClickButton()
    {
        if (holder.PublicContext.IsRing == true)
        {
            holder.PublicContext.OnClickRingButton();
        }
        else
        {
            holder.PublicContext.OnClickSelectButton();
        }
    }
}
