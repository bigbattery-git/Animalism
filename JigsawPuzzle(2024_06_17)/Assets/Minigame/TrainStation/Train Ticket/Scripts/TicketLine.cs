using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TrainTicket
{
    public class TicketLine : MonoBehaviour
    {
        public delegate void managerCall();
        public event managerCall ManagerCall;

        [SerializeField] GameObject[] lineTrigger;
        public void Clear()
        {
            int activeTriggerCount = 0;
            for(int i = 0; i<transform.childCount; ++i)
            {
                if(transform.GetChild(i).gameObject.activeSelf == true)
                    activeTriggerCount++;
            }

            if (activeTriggerCount == 1)
            {
                Debug.Log("이건 클리어");
                transform.parent.gameObject.SetActive(false);
            }
        }
        public void RestartTicketLine()
        {
            for(int i = 0; i< lineTrigger.Length; ++i)
            {
                lineTrigger[i].SetActive(true);
            }
        }
        private void OnDisable()
        {
            ManagerCall.Invoke();
        }
    }
}