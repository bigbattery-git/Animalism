using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportButton : MonoBehaviour
{
    [SerializeField] Button btnReportButton;

    private ContextHolder holder;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        btnReportButton.onClick.AddListener(holder.PublicContext.OnClickReportButton);
    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(holder.PublicContext.ReportKey))
        {
            if(Input.GetKeyDown(holder.PublicContext.ReportKey))
            {
                holder.PublicContext.OnClickReportButton();
            }
        }
    }
}
