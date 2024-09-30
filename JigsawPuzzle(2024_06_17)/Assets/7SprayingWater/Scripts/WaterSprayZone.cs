using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SprayingWater
{
    public class WaterSprayZone : MonoBehaviour
    {
        [SerializeField] private WaterCan waterCan;

        private RectTransform rectTransform;
        private RectTransform watercanTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            watercanTransform = waterCan.GetComponent<RectTransform>();
        }

        private void Update()
        {
            rectTransform.localPosition = watercanTransform.localPosition + new Vector3(-300.0f, 0, 0);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            WetFloorFlower wetFloorFlower = collision.GetComponent<WetFloorFlower>();
            if (wetFloorFlower != null)
            {
                waterCan.SetWaterCan(true);
                if (Input.GetMouseButton(0))
                {
                    if (wetFloorFlower.IsGrowwed(waterCan.GrowTime))
                    {
                        if (OVSoundRoot.Instance.Mission.ID7SprayingWater.isPlaying == false)
                            OVSoundRoot.Instance.Mission.ID7SprayingWater.Play();

                        waterCan.SetWaterSpraying(false);
                        return;
                    }
                    waterCan.SetWaterSpraying(true);
                }
                else
                {
                    waterCan.SetWaterSpraying(false);
                    OVSoundRoot.Instance.Mission.ID7SprayingWater.Stop();
                }
            }            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            waterCan.SetWaterCan(false);
            waterCan.SetWaterSpraying(false);
        }
    }
}