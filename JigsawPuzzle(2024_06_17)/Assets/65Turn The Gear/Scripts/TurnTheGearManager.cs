using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.TurnTheGear
{
    public class TurnTheGearManager : OVMissionOrigin
    {
        [Header("Lamp")]
        [SerializeField] private Image lampImage;
        [SerializeField] private Sprite redLampSprite;
        [SerializeField] private Sprite blueLampSprite;
        private GearColor questionColor;
        public GearColor QuestionColor => questionColor;

        [Header("Gears")]
        [SerializeField] private GearManager gearManager;

        [Header("Little Lamp")]
        [SerializeField] private Image littleLampLeftImage;
        [SerializeField] private Image littleLampRightImage;
        [SerializeField] private Sprite turnOffSprite;
        [SerializeField] private Sprite turnOnSprite;

        public bool IsClear { get; private set; }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            Init();
        }
        private void Init()
        {
            questionColor = (GearColor)Random.Range(0, (int)GearColor.MaxSize);

            switch(questionColor)
            {
                case GearColor.Red:
                    lampImage.sprite = redLampSprite;
                    break;
                case GearColor.Blue:
                    lampImage.sprite = blueLampSprite;
                    break;
            }

            gearManager.Init();
            IsClear = false;
        }

        public void CheckClear()
        {
            if (gearManager.GearColor0 != questionColor) return;
            if (gearManager.GearColor1 != questionColor) return;
            if (gearManager.GearColor2 != questionColor) return;

            IsClear = true;
            MissionClear();
        }
        public void TurnOnLittleLeftLamp(bool _isTurnOn)
        {
            if (_isTurnOn)
                littleLampLeftImage.sprite = turnOnSprite;
            else
                littleLampLeftImage.sprite = turnOffSprite;
        }
        public void TurnOnLittleRightLamp(bool _isTurnOn)
        {
            if (_isTurnOn)
                littleLampRightImage.sprite = turnOnSprite;
            else
                littleLampRightImage.sprite = turnOffSprite;
        }
    }
}