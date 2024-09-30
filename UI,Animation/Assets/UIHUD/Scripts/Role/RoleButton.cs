using UnityEngine;

public class RoleButton : MonoBehaviour
{
    private ContextHolder holder;

    [SerializeField] private GameObject killButton;
    [SerializeField] private GameObject abilityButton;

    private void Start()
    {
        holder = transform.root.GetComponentInChildren<ContextHolder>();
    }
    private void Update()
    {
        if(holder != null)        {
            UpdateButtonState(killButton, holder.RoleContext.IsKillable);
            UpdateButtonState(abilityButton, holder.RoleContext.HasSpectialAbility);
        }
    }
    private void UpdateButtonState(GameObject button, bool isActive)
    {
        if (button != null)
        {
            button.SetActive(isActive);
        }
    }
}