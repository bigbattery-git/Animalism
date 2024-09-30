using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LostAndFound_Church
{
    public class Effect : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                gameObject.SetActive(false);
        }
    }
}