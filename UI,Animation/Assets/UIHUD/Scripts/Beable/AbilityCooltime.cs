using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbilityCooltime : MonoBehaviour
{
    private ContextHolder holder;

    [SerializeField] private Image imgAbiltyCooltime;
    [SerializeField] private Text txtAbilityCooltime;
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        ShowCooltime();
    }
    protected virtual void Init()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
    }

    /// <summary>
    /// Update 함수에서 실행 중
    /// </summary>
    protected virtual void ShowCooltime()
    {
        imgAbiltyCooltime.fillAmount = holder.BeableButtonContext.AbilityCoolTimeCount / holder.BeableButtonContext.AbilityCoolTime;
        txtAbilityCooltime.text = holder.BeableButtonContext.AbilityCoolTimeCount.ToString("F0");

        if(holder.BeableButtonContext.AbilityCoolTimeCount <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
