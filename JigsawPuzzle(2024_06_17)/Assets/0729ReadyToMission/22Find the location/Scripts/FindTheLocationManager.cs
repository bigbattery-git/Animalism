using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Missons.Village.FindTheLocation
{
    [System.Serializable]
    public class StationInfo
    {
        public Button stationButton;
        public int timeOfArrival;
        public TextMeshProUGUI txtTimeOfArrival;
    }
    [System.Serializable]
    public class StationDiraction
    {
        public string diractionName;
        public string diractionColorHex;
        public StationInfo closeStationInfo;
        public StationInfo longStationInfo;

        public string GetDirectionName()
        {
            return $"<color={diractionColorHex}>{diractionName}</color>";
        }
    }
    public enum Country { Eng, Kor}
    public class FindTheLocationManager : OVMissionOrigin
    {
        [SerializeField] private StationDiraction[] diractions;
        [SerializeField] private TextMeshProUGUI txtNowTime;
        [SerializeField] private TextMeshProUGUI txtIntroduceCorrectStation;

        [SerializeField] private int manualHalfTime = 720;

        [SerializeField] private Country country;
        private StationDiraction correctDiraction;
        private StationInfo correctStation; 

        private int nowTime;        
        private const int maxTime = 1499;
        private bool isClear = false;
        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            Init();
            isClear = false;
        }
        private string GetTimeFormat(int _inputTime)
        {
            int timeFormatCount = 2;
            int[] timeFormat = new int[timeFormatCount];

            timeFormat[0] = _inputTime / 60;
            timeFormat[1] = _inputTime % 60;

            string hour = timeFormat[0].ToString("00");
            string minute = timeFormat[1].ToString("00");

            return hour + ":" + minute;
        }

        private string GetCorrectString(StationDiraction _direction, int _inputTime)
        {
            switch (country)
            {
                case Country.Eng:
                    return $"From here, you will arrive at the station that takes time {GetTimeFormat(_inputTime - nowTime)} in the direction of {_direction.GetDirectionName()}";
                case Country.Kor:
                    return $"여기서부터 {_direction.GetDirectionName()} 방면으로 {GetTimeFormat(_inputTime - nowTime)} 시간 걸리는 역에 도착할 것";
            }
            throw new UnityException($"GetCorrectString {_direction}, {_inputTime}");
        }
        public void Init()
        {
            foreach(var dir in diractions)
            {
                dir.closeStationInfo.stationButton.onClick.RemoveAllListeners();
                dir.longStationInfo.stationButton.onClick.RemoveAllListeners();
            }

            SetStationArrivalTimes();
            SetNowTime();
            SetCorrectStation();

            txtIntroduceCorrectStation.text = GetCorrectString(correctDiraction, correctStation.timeOfArrival);
        }
        private void SetShortStationArrivalTimes()
        {
            foreach(var dir in diractions)
            {
                dir.closeStationInfo.timeOfArrival = Random.Range(0, manualHalfTime);
                dir.closeStationInfo.txtTimeOfArrival.text = GetTimeFormat(dir.closeStationInfo.timeOfArrival);
                dir.closeStationInfo.stationButton.onClick.AddListener(() => CheckClear(dir.closeStationInfo.timeOfArrival));
            }
        }
        private void SetLongStationArrivalTimes()
        {
            foreach (var dir in diractions)
            {
                dir.longStationInfo.timeOfArrival = Random.Range(dir.closeStationInfo.timeOfArrival, maxTime);
                dir.longStationInfo.txtTimeOfArrival.text = GetTimeFormat(dir.longStationInfo.timeOfArrival);
                dir.longStationInfo.stationButton.onClick.AddListener(() => CheckClear(dir.longStationInfo.timeOfArrival));
            }                
        }
        private void SetStationArrivalTimes()
        {
            SetShortStationArrivalTimes();
            SetLongStationArrivalTimes();
        }
        private void SetNowTime()
        {
            nowTime = diractions[0].closeStationInfo.timeOfArrival;

            for(int i = 0; i< diractions.Length; i++)
            {
                if (nowTime > diractions[i].closeStationInfo.timeOfArrival)
                    nowTime = diractions[i].closeStationInfo.timeOfArrival;
            }

            nowTime -= Random.Range(0, nowTime + 1);

            txtNowTime.text = "Now Time : " + GetTimeFormat(nowTime);
        }
        private void SetCorrectStation()
        {
            int correctDirectionCount = Random.Range(0, diractions.Length);
            int correctStationCount = Random.Range(0, 2);

            correctDiraction = diractions[correctDirectionCount];
            switch (correctStationCount)
            {
                case 0:
                    correctStation = correctDiraction.closeStationInfo;
                    break;
                case 1:
                    correctStation = correctDiraction.longStationInfo;
                    break;
            }
        }
        private void CheckClear(int _arrivalTime)
        {
            if (isClear) return;
            if (correctStation.timeOfArrival != _arrivalTime) return; 
            MissionClear();
        }
    }
} 