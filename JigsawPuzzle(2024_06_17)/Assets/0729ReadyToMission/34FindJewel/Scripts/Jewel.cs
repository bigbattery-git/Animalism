using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FindJewel
{
    public class Jewel : MonoBehaviour, IPointerClickHandler
    {
        public static event Action OnClickedJewelHandler;
        private RectTransform rectTransform;
        private Transform jewelSpawnPointTransform;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            jewelSpawnPointTransform = GameObject.Find("Trash").GetComponent<Transform>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickedJewelHandler?.Invoke();
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            SetJewelSpawnTransform();
        }
        private void SetJewelSpawnTransform()
        {
            int jewelHidePoint = UnityEngine.Random.Range(0, jewelSpawnPointTransform.childCount);
            rectTransform.position = jewelSpawnPointTransform.GetChild(jewelHidePoint).position;
        }
    }
}