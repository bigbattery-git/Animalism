using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCooltimeSniperCount : KillCoolTime
{
    [SerializeField] private GameObject objKillCoolTime;
    public override void ShowCoolTime()
    {
        txtKillCooltime.text = holder.BeableButtonContext.KillCooltimeSniperCount.ToString("F0");
        imgKillCooltimeCount.fillAmount = holder.BeableButtonContext.KillCooltimeSniperCount / holder.BeableButtonContext.KillCooltimeSniper;

        if (holder.BeableButtonContext.KillCooltimeSniperCount <= 0)
        {
            objKillCoolTime.SetActive(true);
            gameObject.SetActive(false);
        }            
    }
}
