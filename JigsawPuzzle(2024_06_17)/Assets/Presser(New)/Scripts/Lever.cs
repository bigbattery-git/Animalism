using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.Presser
{
    public class Lever : MonoBehaviour, IPointerClickHandler
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            animator.SetTrigger("ActiveLever");
        }

        public void OnEndAnimation()
        {
            Debug.Log("Active presser");
        }
    }
}