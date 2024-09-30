using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ShakingTheCarpet
{
    public class Dust : MonoBehaviour
    {
        [SerializeField] float deactivateTime;
        private void OnEnable()
        {
            Invoke("Deactivate", deactivateTime);
        }
        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}