using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    private ContextHolder holder;
    private Button btnOptionButton;
    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        btnOptionButton = GetComponent<Button>();
        btnOptionButton.onClick.AddListener(holder.PublicContext.OnClickOptionButton);
    }
}