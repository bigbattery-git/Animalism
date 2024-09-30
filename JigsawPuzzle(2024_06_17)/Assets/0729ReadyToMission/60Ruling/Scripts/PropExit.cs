using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.Ruling
{
    public class PropExit : MonoBehaviour
    {
        public GameObject[] hammerEffects;

        private void OnEnable()
        {
            TurnOffEffect();
        }

        private void TurnOffEffect()
        {
            foreach(var effect in hammerEffects)
            {
                effect.SetActive(false);
            }
        }
    }
}

