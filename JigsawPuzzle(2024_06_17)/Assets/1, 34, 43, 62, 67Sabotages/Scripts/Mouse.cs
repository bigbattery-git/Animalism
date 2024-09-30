using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.Sabotage_Trashbox
{
    public class Mouse : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;
        private void OnEnable()
        {
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            Cursor.visible = true;
        }

        private void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
        }
    }
}