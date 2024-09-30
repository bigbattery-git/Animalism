using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.BreakCoal
{
    public class Chisel : MonoBehaviour
    {
        private RectTransform rectTransform;
        [SerializeField] Canvas canvas;
        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
        }
    }
}