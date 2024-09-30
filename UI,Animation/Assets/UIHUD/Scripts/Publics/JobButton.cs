using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

public class JobButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private Image imgJobImabe;
    [SerializeField] private Text txtJobName;
    [SerializeField] private GameObject jobExplain;
    private Text txtJobExplain;

    private ContextHolder holder;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        txtJobExplain = jobExplain.GetComponentInChildren<Text>();
        jobExplain.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        holder.PublicContext.OnEnterJobInfoImage();
        jobExplain.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        holder.PublicContext.OnExitJobInfoImage();
        jobExplain.SetActive(false);
    }
    private void Update()
    {
        txtJobName.text = holder.PublicContext.JobName;
        imgJobImabe.sprite = Resources.Load<Sprite>(holder.PublicContext.JobImagePath);
        txtJobExplain.text = holder.PublicContext.JobExplain;
    }
}
