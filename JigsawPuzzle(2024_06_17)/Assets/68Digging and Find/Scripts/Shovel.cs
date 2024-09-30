using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.DiggingAndFinding
{
    public class Shovel : MonoBehaviour
    {
        private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
        }
    }
}