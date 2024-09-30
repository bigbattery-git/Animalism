using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Missons.Village.PuttingMoney
{
    public class PuttingMoneyManager : OVMissionOrigin
    {
        public float TillMoneyDistance => tillMoneyDistance;
        public int SpawnMoneyCount => spawnMoneyCount;
        public bool IsClear { get; private set; }

        [SerializeField] private float tillMoneyDistance;
        

        [SerializeField] private Transform moneyParentTransform;
        [SerializeField] private SpawnTray spawnTray;

        private List<Money> moneys = new List<Money>();

        [Header("Money Count Manual")]
        [SerializeField] private bool activeManual;

        [SerializeField] private int spawnMoneyCount;

        [SerializeField] private int billCountControl;
        [SerializeField] private int coinCountControl;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            IsClear = false;

            spawnTray.SpawnMoney(activeManual, billCountControl, coinCountControl);
            Init();

            OVSoundRoot.Instance.Mission.ID18StartPuttingMoney.Play();
        }

        [ContextMenu("Override Hide")]
        public override void Hide()
        {
            base.Hide();

            foreach (var money in moneys)
                Destroy(money.gameObject);

            moneys.Clear();
        }

        private void Init()
        {
            moneys = moneyParentTransform.GetComponentsInChildren<Money>().ToList<Money>();
        }

        public void CheckClear()
        {
            foreach(var money in moneys)
            {
                if (!money.IsClear) return;
            }

            IsClear = true;
            MissionClear();
        }
    }
}