using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Button btnMap;

    private ContextHolder holder;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        btnMap.onClick.AddListener(holder.PublicContext.OnClickMapButton);
    }
}
