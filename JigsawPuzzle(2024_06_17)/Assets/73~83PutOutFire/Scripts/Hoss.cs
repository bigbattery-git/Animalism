using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutOutFire
{
    public class Hoss : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;

        [Header("Water")]
        [SerializeField] private RectTransform waterPosition;
        [SerializeField] private RectTransform water;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);

            water.position = waterPosition.position;

            if (Input.GetMouseButton(0))
            {
                water.gameObject.SetActive(true);
            }
            else
            {
                water.gameObject.SetActive(false);
            }
        }
    }
}