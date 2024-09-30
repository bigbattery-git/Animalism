using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.CakeCutting
{
    public class Knife : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private SlidePoint slidePoint;
        public bool canTurn { get; set; }

        private void OnEnable()
        {
            canTurn = true;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (canTurn)
            {
                slidePoint.ResetCutLine();
                slidePoint.SetTurn(true);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (canTurn)
            {
                slidePoint.CheckCutLine();
                slidePoint.SetTurn(false);
            }
        }
    }
}