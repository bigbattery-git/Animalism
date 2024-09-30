using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.TakingMoney
{
    public class Money : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;
        [SerializeField] private TakingMoneyManager manager;
        [SerializeField] private RectTransform spawnPoint;
        [SerializeField] private RectTransform layerTransform;
        private Vector2 resetVector;

        private bool canTake;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
           SetSpawnPosition();
            resetVector = rectTransform.anchoredPosition;

            canTake = false;
        }
        private void SetSpawnPosition()
        {
            float x = spawnPoint.anchoredPosition.x + Random.Range(-spawnPoint.sizeDelta.x / 2f , spawnPoint.sizeDelta.x / 2f);
            float y = spawnPoint.anchoredPosition.y + Random.Range(-spawnPoint.sizeDelta.y / 2f, spawnPoint.sizeDelta.y / 2f);
            rectTransform.anchoredPosition = new Vector3(x, y, 0);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            canTake = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            canTake = false;
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!Input.GetMouseButton(0))
            {
                manager.currentClearCount++;
                if(manager.currentClearCount == manager.FinishClearCount)
                {
                    manager.MissionClear();
                }
                gameObject.SetActive(false);
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        private void Update()
        {
            LimitPiecePosition();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (canTake == true) return;
            rectTransform.anchoredPosition = resetVector;
        }
        private void LimitPiecePosition()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);
        }
    }
}