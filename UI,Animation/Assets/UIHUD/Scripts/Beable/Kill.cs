using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    private ContextHolder holder;

    [SerializeField] private GameObject imgKillBox;
    [SerializeField] private GameObject objKillCooltimeCount;
    [SerializeField] private GameObject objKillCooltimeSniperCount;

    private Button btnKillBox;
    private Text txtKillKey;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        txtKillKey = imgKillBox.GetComponentInChildren<Text>();
        btnKillBox = GetComponent<Button>();

        btnKillBox.onClick.AddListener(OnClickKillButton);
    }
    private void Update()
    {
        if (Input.GetKeyDown(holder.BeableButtonContext.KillKey))
        {
            OnClickKillButton();
        }

        txtKillKey.text = holder.BeableButtonContext.KillKey;
    }

    private void OnClickKillButton()
    {
        if (holder.BeableButtonContext.CanKill)
        {
            holder.BeableButtonContext.OnClickedKillButton();
            if(holder.RoleContext.KillerJobList == IUIHUDRoleContext.KillerJob.SniperTool)
            {
                objKillCooltimeSniperCount.SetActive(true);
            }
            else
            {
                objKillCooltimeCount.SetActive(true);
            }
        }
    }
}
