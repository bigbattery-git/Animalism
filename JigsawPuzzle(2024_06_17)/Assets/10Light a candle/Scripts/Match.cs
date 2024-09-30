using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LigthACandle
{
    public class Match : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            rectTransform.rotation = Quaternion.Euler(0, 0, -70f);
        }
        private void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);

            if (Input.GetMouseButtonDown(0))
            {
                rectTransform.rotation = Quaternion.Euler(0, 0, -50f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                rectTransform.rotation = Quaternion.Euler(0, 0, -70f);
            }
        }
    }
}