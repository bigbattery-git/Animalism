using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SprayingWater
{
    public class WetFloorFlower : MonoBehaviour
    {
        [SerializeField] private RectTransform wetFloorFlowerTransform;

        [SerializeField] private SprayWaterManager origin;
        public bool IsCleard => IsGrowwed(0);
        private void OnEnable()
        {
            wetFloorFlowerTransform.localScale = Vector3.zero;
        }

        public bool IsGrowwed(float growTime)
        {
            if (growTime <= 0) return wetFloorFlowerTransform.localScale.x >= 1;

            wetFloorFlowerTransform.localScale += Vector3.one * (Time.deltaTime / growTime);

            if(wetFloorFlowerTransform.localScale.x > 1)
            {
                wetFloorFlowerTransform.localScale = Vector3.one;
                origin.CheckClear();
            }
            return wetFloorFlowerTransform.localScale.x >= 1;
        }
    }
}