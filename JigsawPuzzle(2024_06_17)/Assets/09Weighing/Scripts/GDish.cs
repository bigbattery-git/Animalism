using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.weighing
{
    public class GDish : MonoBehaviour
    {
        [SerializeField] private int totalWeigh;
        [SerializeField] private Transform spawnerTransform;
        [SerializeField] private Transform setupTransform;
        public int TotalWeigh => totalWeigh;

        [SerializeField] private WeighingManager manager;
        public void ResetTotalWeigh() => totalWeigh = 0;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Weigh weigh = collision.GetComponent<Weigh>();
            if (weigh)
            {
                totalWeigh += weigh.Weigh_;

                weigh.transform.SetParent(this.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision) return;

            Weigh weigh = collision.GetComponent<Weigh>();
            if (weigh)
            {
                totalWeigh -= weigh.Weigh_;

                if(gameObject.activeInHierarchy)
                weigh.transform.SetParent(spawnerTransform);

                manager.SetHorizontalStand();
            }           
        }
    }
}