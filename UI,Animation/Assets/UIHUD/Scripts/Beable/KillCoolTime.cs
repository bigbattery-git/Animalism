using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class KillCoolTime : MonoBehaviour
{
    [SerializeField] protected Image imgKillCooltimeCount;

    protected ContextHolder holder;

    protected Text txtKillCooltime;

    public virtual void Init()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        txtKillCooltime = GetComponentInChildren<Text>();

        txtKillCooltime.text = null;
        imgKillCooltimeCount.fillAmount = 0;

        gameObject.SetActive(false);
    }
    public virtual void ShowCoolTime()
    {
        txtKillCooltime.text = holder.BeableButtonContext.KillCooltimeCount.ToString("F0");
        imgKillCooltimeCount.fillAmount = holder.BeableButtonContext.KillCooltimeCount / holder.BeableButtonContext.KillCooltime;

        if (holder.BeableButtonContext.KillCooltimeCount <= 0)
            gameObject.SetActive(false);
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        ShowCoolTime();
    }
}
