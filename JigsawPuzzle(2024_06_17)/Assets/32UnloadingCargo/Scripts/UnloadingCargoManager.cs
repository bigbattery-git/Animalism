using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.UnloadingCargo
{
    public class UnloadingCargoManager : OVMissionOrigin
    {
        public enum CargoState {Regular, Random, Preset}
        [SerializeField] private RectTransform[] cargoTransforms;
        [SerializeField] private RectTransform[] cargoPresetTransforms;
        [SerializeField] private RectTransform cartTransform;
        private Vector3[] startCargoTransforms;
        private int clearCount = 0;

        [SerializeField] private CargoState cargoState = CargoState.Regular;

        [Header("프리셋 번호 미리 설정여부")]
        [SerializeField] private int presetNum;
        [SerializeField][Tooltip("프리셋 번호 설정을 할 것인가")] private bool isSetPresetNum;
        public override void Awake()
        {
            base.Awake();
            SetStartCargoTransforms();
        }
        private void SetStartCargoTransforms()
        {
            startCargoTransforms = new Vector3[cargoTransforms.Length];
            for(int i = 0; i<cargoTransforms.Length; ++i)
            {
                startCargoTransforms[i] = cargoTransforms[i].anchoredPosition;
            }
        }

        [ContextMenu("OverrideShow")]
        public override void Show()
        {
            base.Show();

            clearCount = 0;

            switch (cargoState)
            {
                case CargoState.Regular:
                    SetCargosRegular();
                    break;
                case CargoState.Random:
                    SetCargosRandom();
                    break;
                case CargoState.Preset:
                    SetCargosPreset();
                    break;
            }
        }
        private void SetCargosRegular()
        {
            for(int i = 0; i<cargoTransforms.Length; ++i)
            {
                cargoTransforms[i].anchoredPosition = startCargoTransforms[i];
            }
        }
        private void SetCargosRandom()
        {            
            for(int i = 0; i<cargoTransforms.Length; ++i)
            {
                cargoTransforms[i].anchoredPosition = GetRandomCartPlace(cartTransform);
            }
        }
        private void SetCargosPreset()
        {
            int presetNumber = 0;
            if (isSetPresetNum)
                presetNumber = presetNum;
            else
                presetNumber = UnityEngine.Random.Range(0, cargoPresetTransforms.Length);

            for(int i = 0; i< cargoPresetTransforms[presetNumber].childCount; ++i)
            {
                cargoTransforms[i].anchoredPosition =
                    cargoPresetTransforms[presetNumber].GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            }
        }
        private Vector2 GetRandomCartPlace(RectTransform _cartTransform, float _spaceX = 0, float _spaceY = 0)
        {
            float width = _cartTransform.rect.width - _spaceX;
            float height = _cartTransform.rect.height - _spaceY;
            
            float rndWidth = UnityEngine.Random.Range(-(width/2), width/2);
            float rndHeight = UnityEngine.Random.Range(-(height/2), height/2);
            return _cartTransform.anchoredPosition + new Vector2(rndWidth , rndHeight);
        }
        public void CheckClear()
        {
            clearCount++;
            if (clearCount == 4)
                MissionClear();
        }
    }
}