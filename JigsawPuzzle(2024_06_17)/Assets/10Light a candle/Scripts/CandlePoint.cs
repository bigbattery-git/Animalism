using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LigthACandle
{
    public class CandlePoint : MonoBehaviour
    {
        private GameObject fire;

        public LightACandleManager manager { get; set; }        
        private float waitingTime;
        public bool isBurning { get { return fire.activeInHierarchy; } }

        private void Awake()
        {
            fire = transform.GetChild(0).gameObject;
        }

        private void OnEnable()
        {
            waitingTime = 0;
            fire.SetActive(false);
        }

        public void BurnCandle(float _waitingTime)
        {
            if (isBurning) return;

            waitingTime += _waitingTime;
            if(waitingTime >= manager.WaitBurningTime)
            {
                fire.SetActive(true);
                manager.CheckClear();
                OVSoundRoot.Instance.Mission.ID10StartingBurning.Play();
            }
        }
    }
}