using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CutTicket
{
    public class CutTicketManager : OVMissionOrigin
    {
        public bool isClear { get; private set; }

        [Header("해당 미션 관련")]
        [SerializeField] private GameObject ticket;
        [SerializeField] private GameObject[] cuttingTickets;
        [SerializeField] private CutLine cutLine;

        public override void Awake()
        {
            base.Awake();

            cutLine.manager = this;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            isClear = false;
            CutTicket(isClear);
        }

        public override void MissionClear()
        {
            base.MissionClear();

            isClear = true;
            CutTicket(isClear);            
        }

        private void CutTicket(bool _isCutted)
        {
            ticket.SetActive(!_isCutted);

            foreach(var tickets in cuttingTickets)
            {
                tickets.SetActive(_isCutted);
            }
        }
    }
}