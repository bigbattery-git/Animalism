using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.AdjustingRadio
{
    public class FrequencyRed : Frequency
    {
        public override void OnMoveGear(float _beforeAngle, float _currentAngle)
        {
            if(_beforeAngle < _currentAngle)
            {
                // 오른쪽으로 이동
                MoveBox(1);
            }
            else if(_beforeAngle > _currentAngle) 
            {
                // 왼쪽으로 이동
                MoveBox(-1);
            }

            manager.CheckClear();
        }

        private void MoveBox(float _moveSpeed)
        {
            rectTransform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);

            float limitLeft = 164f;
            float limitRight = 1075f;
            if(rectTransform.anchoredPosition.x < limitLeft)
            {
                rectTransform.anchoredPosition = new Vector2(limitLeft, rectTransform.anchoredPosition.y);
            }

            if (rectTransform.anchoredPosition.x > limitRight)
            {
                rectTransform.anchoredPosition = new Vector2(limitRight, rectTransform.anchoredPosition.y);
            }
        }
    }
}

