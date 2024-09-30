using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TrainTicket
{
    public class TrainTicketManager : MonoBehaviour
    {
        [SerializeField] int clearCount;
        int currentClearCount;
        private void Awake()
        {
            FindObjectOfType<TicketLine>().ManagerCall += IncreaseCurrentClearCount;
        }
        private void IsClear()
        {
            Debug.Log("Clear!");
        }
        public void IncreaseCurrentClearCount()
        {
            currentClearCount++;

            if (currentClearCount == clearCount)
                IsClear();
        }
    }
}