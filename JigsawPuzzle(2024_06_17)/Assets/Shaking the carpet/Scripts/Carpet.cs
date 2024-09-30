using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Missons.Village.ShakingTheCarpet
{
    public class Carpet : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent TouchEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            TouchEvent.Invoke();
        }
    }
}