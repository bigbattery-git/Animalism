using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LigthACandle
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private RectTransform firePlaceTransform;

        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void Update()
        {
            rectTransform.position = firePlaceTransform.position;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            CandlePoint point = collision.GetComponent<CandlePoint>();
            if (!point) return;

            if (Input.GetMouseButton(0))
            {
                point.BurnCandle(Time.deltaTime);
            }
        }
    }
}