using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MakeFirewood
{
    public class Firewood : MonoBehaviour
    {
        [SerializeField] private GameObject original;
        [SerializeField] private GameObject[] firewoods;

        private void OnEnable()
        {
            MakeFirewood(false);
        }

        public void MakeFirewood(bool _isMade)
        {
            original.SetActive(!_isMade);

            foreach (var firewood in firewoods)
                firewood.SetActive(_isMade);
        }
    }
}