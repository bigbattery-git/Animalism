using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LoadingCargo
{
    public class CargoManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] cargos;

        private void OnEnable()
        {
            for(int i = 0; i< cargos.Length; i++)
            {
                if (!cargos[i].activeInHierarchy)
                {
                    cargos[i].SetActive(true);
                }
            }
        }
    }

}