using Missons.Village.PutOutFire;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutOutFire
{
    public class FireFactory : MonoBehaviour
    {
        [SerializeField] private PutOutFireFactoryManager manager;

        [SerializeField] private GameObject bigFire;
        [SerializeField] private GameObject smallFire;

        private bool isEnterWater;
        private float enterWaterTime;
        public bool IsClear { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                isEnterWater = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                isEnterWater = false;
                if (IsSmallFireTime()) enterWaterTime = manager.BigFireOffTime;
                else enterWaterTime = 0;
            }
        }

        private void Awake()
        {
            ResetObject();
        }
        private void Update()
        {
            if (isEnterWater)
            {
                enterWaterTime += Time.deltaTime;
            }

            if (IsSmallFireTime())
            {
                bigFire.SetActive(false);
                smallFire.SetActive(true);
            }

            if (enterWaterTime > manager.TotalFireOffTime)
            {
                IsClear = true;
                manager.CheckClear();
                gameObject.SetActive(false);
            }
        }

        private bool IsSmallFireTime()
        {
            return enterWaterTime > manager.BigFireOffTime;
        }

        public void ResetObject()
        {
            bigFire.SetActive(true);
            smallFire.SetActive(false);

            IsClear = false;
            isEnterWater = false;
            enterWaterTime = 0;
        }
    }
}