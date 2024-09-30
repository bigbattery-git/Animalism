using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.RemoveHive
{
    public class Hive : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] int clickCount;
        int currentClickCount = 0;

        [SerializeField] private RemoveHiveManager manager;
        private void OnEnable()
        {
            clickCount = 0;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            currentClickCount++;
            if (currentClickCount == clickCount)
            {
                manager.MissionClear();
                GetComponent<Rigidbody2D>().gravityScale = 100f;
            }
        }
    }
}