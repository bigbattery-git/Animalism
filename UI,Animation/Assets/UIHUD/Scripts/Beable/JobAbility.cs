using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JobAbility : MonoBehaviour
{
    private ContextHolder holder;

    [SerializeField] private GameObject abilityTextBox;
    [SerializeField] private GameObject objAbilityCooltime;

    private Image imgJobAbility;
    private Text txtAbilityKey;

    private Button btnJobAbility;

    [Header("Job Ability Icon Name")]
    private string objJobAbilityIcon = "JobAbilityImage";

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
        txtAbilityKey = abilityTextBox.GetComponentInChildren<Text>();

        btnJobAbility = GetComponent<Button>();
        btnJobAbility.onClick.AddListener(OnClickAbilityButton);

        objAbilityCooltime.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(holder.BeableButtonContext.AbilityKey))
        {
            OnClickAbilityButton();
        }
        txtAbilityKey.text = holder.BeableButtonContext.AbilityKey.ToUpper();

        SpwanJobAbilityImage();
    }
    private void SpwanJobAbilityImage()
    {
        if(imgJobAbility == null)
        {
            imgJobAbility = Instantiate(Resources.Load<GameObject>(objJobAbilityIcon), this.transform).GetComponent<Image>();
        }

        imgJobAbility.transform.SetSiblingIndex(0);
        imgJobAbility.sprite = Resources.Load<Sprite>(holder.BeableButtonContext.AbilityImagePath);
    }
    private void OnClickAbilityButton()
    {
        holder.BeableButtonContext.OnClickedAbilityButton();
        objAbilityCooltime.SetActive(true);
    }
}