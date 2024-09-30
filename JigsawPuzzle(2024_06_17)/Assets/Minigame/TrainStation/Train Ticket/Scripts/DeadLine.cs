using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Missons.Village.TrainTicket
{
    public class DeadLine : MonoBehaviour, IPointerEnterHandler
    {
        public UnityEvent onTouchDeadLine;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(Input.GetMouseButton(0))
            onTouchDeadLine.Invoke();
        }
    }
}