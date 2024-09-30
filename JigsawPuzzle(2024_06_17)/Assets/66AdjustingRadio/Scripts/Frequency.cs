using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.AdjustingRadio
{
    public abstract class Frequency : MonoBehaviour
    {
        protected AdjustingRadioManager manager;
        protected Canvas canvas;

        protected RectTransform rectTransform;

        public Vector2 anchorTransform { get { return rectTransform.anchoredPosition; } }
        protected virtual void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public abstract void OnMoveGear(float _beforeAngle, float _currentAngle);
        public void Setup(AdjustingRadioManager _manager, Canvas _canvas)
        {
            manager = _manager;
            canvas = _canvas;
        }
        public void SetAnchorTransform(float _positionXValue)
        {
            float limitLeft = 164f;
            float limitRight = 1075f;
            float xValue = Mathf.Lerp(limitLeft, limitRight, _positionXValue);

            rectTransform.anchoredPosition = new Vector2(xValue, rectTransform.anchoredPosition.y);
        }
        public void SetAnchorRectTransformPosition(Vector2 _vector2)
        {
            rectTransform.anchoredPosition = _vector2;
        }
    }
}