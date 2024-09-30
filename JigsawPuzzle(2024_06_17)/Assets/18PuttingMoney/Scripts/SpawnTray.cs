using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PuttingMoney
{
    public class SpawnTray : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        [SerializeField] private GameObject billPrefab;
        [SerializeField] private GameObject coinPrefab;

        [SerializeField] private Sprite[] billSprites;
        [SerializeField] private Sprite[] coinSprites;

        [SerializeField] private Transform moneyParentTransform;
        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private RectTransform billPlaceTransform;
        [SerializeField] private RectTransform coinPlaceTransform;

        [SerializeField] private PuttingMoneyManager manager;

        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void SpawnMoney(bool _isManual, int _billCount = 0, int _coinCount =0)
        {
            if (rectTransform == null) rectTransform = GetComponent<RectTransform>();

            int billCount = 0;
            int coinCount = 0;

            if (_isManual)
            {
                billCount = _billCount;
                coinCount = _coinCount;
            }

            else
            {
                billCount = Random.Range(0, manager.SpawnMoneyCount);
                coinCount = manager.SpawnMoneyCount - billCount;
            }

            for (int i = 0; i < billCount; i++)
            {
                Money money = Instantiate(billPrefab, moneyParentTransform).GetComponent<Money>();
                RectTransform moneyRect = money.GetComponent<RectTransform>();

                moneyRect.anchorMin = new Vector2(0, 0);
                moneyRect.anchorMax = new Vector2(0, 0);

                moneyRect.anchoredPosition = SpawnMoneyPlace();

                money.Init(canvas, layerTransform, billPlaceTransform, billSprites[Random.Range(0, billSprites.Length)], manager);
            }

            for (int i = 0; i < coinCount; i++)
            {
                Money money = Instantiate(coinPrefab, moneyParentTransform).GetComponent<Money>();
                RectTransform moneyRect = money.GetComponent<RectTransform>();

                moneyRect.anchorMin = new Vector2(0, 0);
                moneyRect.anchorMax = new Vector2(0, 0);

                moneyRect.anchoredPosition = SpawnMoneyPlace();

                money.Init(canvas, layerTransform, coinPlaceTransform, coinSprites[Random.Range(0, coinSprites.Length)], manager);
            }
        }
        private Vector3 SpawnMoneyPlace()
        {
            float sizeX = rectTransform.sizeDelta.x;
            float sizeY = rectTransform.sizeDelta.y;

            float rndPosX = Random.Range(- sizeX, sizeX) / 2;
            float rndPosY = Random.Range(- sizeY, sizeY) / 2;

            Vector3 spawnVec = rectTransform.anchoredPosition + new Vector2(rndPosX, rndPosY);
            return spawnVec;
        }
    }
}