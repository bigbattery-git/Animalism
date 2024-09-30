using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Missons.Village.TrainTicket
{
    public class TicketLineTrigger : MonoBehaviour, IPointerEnterHandler
    {
        public UnityEvent onDisableTrigger;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Input.GetMouseButton(0))
            {
                onDisableTrigger.Invoke();

                this.gameObject.SetActive(false);
            }
        }
    }
}