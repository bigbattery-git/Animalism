using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CleanUpTrash 
{
    public class TrashBox : MonoBehaviour
    {
        [SerializeField] private TrashManager manager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
            manager.CheckClear();
        }
    }
}