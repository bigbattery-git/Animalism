using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SwipFloor
{
    public class Dust : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}