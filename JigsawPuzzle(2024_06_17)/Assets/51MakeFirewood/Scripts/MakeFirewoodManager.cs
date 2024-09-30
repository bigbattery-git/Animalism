using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MakeFirewood
{
    public class MakeFirewoodManager : OVMissionOrigin
    {
        [Header("해당 미션관련")]
        [SerializeField] private Firewood[] firewoods;
        [SerializeField] private Breaker breaker;
        [SerializeField] private float breakWaitTime = 1f;
        [SerializeField] private GameObject line;

        public bool CanMove { get; private set; }
        public bool isClear { get; private set; }
        public bool isWaitingTime { get; private set; }

        private int firewoodNum;
        public override void Awake()
        {
            base.Awake();
            breaker.manager = this;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            StopAllCoroutines();

            firewoodNum = 0;

            ActiveNextFirewood();

            isClear = false;

            CanMove = true;
        }

        private void ActiveNextFirewood()
        {
            foreach (var firewood in firewoods)
                firewood.gameObject.SetActive(false);

            firewoods[firewoodNum].gameObject.SetActive(true);

            line.SetActive(true);
        }

        public override void MissionClear()
        {
            base.MissionClear();
            isClear = true;
        }

        public void BreakFirewood()
        {
            StartCoroutine(BreakFirewoodCo());
        }

        private IEnumerator BreakFirewoodCo()
        {
            firewoods[firewoodNum].MakeFirewood(true);
            line.SetActive(false);
            CanMove = false;

            if (firewoodNum == firewoods.Length - 1)
            {
                MissionClear();
                yield break;
            }

            yield return new WaitForSeconds(breakWaitTime);

            CanMove = true;
            firewoodNum++;
            ActiveNextFirewood();
        }
    }
}