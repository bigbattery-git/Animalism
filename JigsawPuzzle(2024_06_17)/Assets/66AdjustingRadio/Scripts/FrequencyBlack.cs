using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.AdjustingRadio
{
    public class FrequencyBlack : Frequency
    {
        private Image image;
        private float alphaValue;

        public bool IsClearReady { get { return alphaValue > 0.95f; } }
        public float SoundValue01 { get { return Mathf.PingPong(alphaValue, 1); } } 

        protected override void Awake()
        {
            base.Awake();
            image = GetComponent<Image>();
        }

        public override void OnMoveGear(float _beforeAngle, float _currentAngle)
        {
            if (_beforeAngle > _currentAngle)
            {
                SetColorAlphaRepeat(-0.01f);
            }
            else if (_beforeAngle < _currentAngle)
            {
                SetColorAlphaRepeat(0.01f);
            }

            manager.CheckClear();
        }

        private void SetColorAlphaRepeat(float _alphaValueAmount)
        {
            alphaValue -= _alphaValueAmount;
            float alpha = Mathf.PingPong(alphaValue, 1f);

            image.color = new Color(0, 0, 0, alpha);
        }

        private void Update()
        {
            
        }

        public void SetAlphaAndSoundValueWhenShowMission(float _alphaValue)
        {
            alphaValue = _alphaValue;

            float alpha = Mathf.PingPong(alphaValue, 1f);

            image.color = new Color(0, 0, 0, alpha);
        }
    }
}