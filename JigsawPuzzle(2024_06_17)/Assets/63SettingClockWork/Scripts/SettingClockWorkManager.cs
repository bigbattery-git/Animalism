using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Missons.Village.SettingClockWork
{
    public class SettingClockWorkManager : OVMissionOrigin
    {
        private int hourTime;
        private int minuteTime;

        [SerializeField] private TextMeshProUGUI txtTime;
        [SerializeField] private Niddle hourNiddle;
        [SerializeField] private Niddle minuteNiddle;

        public bool IsClear { get; private set; }
        public int HourTime => hourTime;
        public int MinuteTime => minuteTime;
        public override void Awake()
        {
            hourNiddle.Manager = this;
            minuteNiddle.Manager = this;

            base.Awake();
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            StopAllCoroutines();

            IsClear = false;

            hourTime = Random.Range(0, 24);
            if (hourTime >= 12)
                hourTime -= 12;

            StartCoroutine(SetRandomMinuteTime());
            SetTime();
        }

        private IEnumerator SetRandomMinuteTime()
        {
            do
            {
                minuteTime = Random.Range(0, 12);
                yield return null;
            }
            while(minuteTime == hourTime);
        }

        private void SetTime()
        {
            string printMinTime = minuteTime * 5 > 10 ? (minuteTime * 5).ToString() : (minuteTime * 5).ToString("D2");
            txtTime.text = $"{hourTime} : {printMinTime}";
        }
        public void CheckClear()
        {
            if (IsClear) return;

            if (hourNiddle.TouchedNum || minuteNiddle.TouchedNum) OVSoundRoot.Instance.Mission.ID72MatchingTime.Play();

            if (!hourNiddle.TouchedNum || !minuteNiddle.TouchedNum) return;

            if (hourNiddle.TouchedNum.Number_ != hourTime) return;
            if (minuteNiddle.TouchedNum.Number_ != minuteTime) return;

            IsClear = true;
            MissionClear();
        }
    }
}