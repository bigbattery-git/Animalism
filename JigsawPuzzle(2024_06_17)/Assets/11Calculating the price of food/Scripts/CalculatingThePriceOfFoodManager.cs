using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Missons.Village.CalculatingThePriceOfFood
{
    public class CalculatingThePriceOfFoodManager : MonoBehaviour
    {
        [Header("Text & Image")]
        [SerializeField] private TextMeshProUGUI[] priceTexts;
        [SerializeField] private Image[] foodImages;
        [SerializeField] private TextMeshProUGUI totalPriceText;
        
        [Header("Food")]
        [SerializeField] private Button[] foodButtons;
        [SerializeField] private Sprite[] foodSprites;
        [SerializeField] float[] foodPrices;

        [Header("Settings")]
        [SerializeField] private float ResetTime;
        [SerializeField] private Button DebugButton;

        [Header("Food Price")]
        [SerializeField] private TextMeshProUGUI[] txtFoodPrices;

        [Header("Drink Price")]
        [SerializeField] private TextMeshProUGUI[] txtDrinkPrices;

        private decimal[] pricesData;

        private decimal startTotalPrice;
        private decimal currentTotalPrice;    
        
        private int priceSequence = 0;

        [SerializeField] private OVMissionOrigin origin;

        private Coroutine setTotalPrice;
        private void Awake()
        {
            ResetFoodImage();

            SetMenuPrice();

            for (int i = 0; i < foodButtons.Length; ++i)
            {
                int temp = i;
                foodButtons[temp].onClick.AddListener(() => SetPrice(foodPrices[temp], foodSprites[temp], foodButtons[temp]));
                foodButtons[temp].onClick.AddListener(() => OnStateFood(foodButtons[temp], false));
            }
            DebugButton.onClick.AddListener(ResetCalculating);
        }

        private void OnEnable()
        {
            if(setTotalPrice != null)
            {
                StopCoroutine(setTotalPrice);
                setTotalPrice = null;
            }

            ResetCalculating();
            setTotalPrice = StartCoroutine(SetTotalPrice());
        }

        // 계산해야 하는 총 가격 관련 로직
        IEnumerator SetTotalPrice()
        {
            // 예상하는 메뉴 3가지 고르기. 겹치게 하지 않기 위해 a, b, c 다를 경우에만 while문 벗어나게 함.
            int a = Random.Range(0, foodButtons.Length); ;
            int b = 0;
            int c = 0;

            while(a == b)
            {
                b = Random.Range(0, foodButtons.Length);
                yield return null;
            }

            while (b == c || a == c)
            {
                c = Random.Range(0, foodButtons.Length);
                yield return null;
            }

            float d = foodPrices[a] + foodPrices[b] + foodPrices[c];

            // currentTotalPrice와 startTotalPrice에 이식
            currentTotalPrice = (decimal)d;
            startTotalPrice = (decimal)d;
        }
        private void Update()
        {
            for(int i = 0; i < priceTexts.Length; ++i)
            {
               priceTexts[i].text = pricesData[i].ToString("F1");
            }
            totalPriceText.text = currentTotalPrice.ToString("F1");
        }

        /// <summary>
        /// 각 메뉴에 음식 가격 데이터 추가.
        /// </summary>
        /// <param name="_price"></param>
        /// <param name="_sprite"></param>
        /// <param name="_button"></param>
        public void SetPrice(float _price, Sprite _sprite, Button _button)
        {
            // 클릭 시, 메뉴 밑에 음식 결과 보여주도록 함.(무슨 음식을 클릭했으며, 그 가격이 얼마인지)
            pricesData[priceSequence] = (decimal)_price;
            foodImages[priceSequence].sprite = _sprite;
            foodImages[priceSequence].color = new Color(1, 1, 1, 1); 
            foodImages[priceSequence].GetComponent<RectTransform>().sizeDelta = _button.GetComponent<RectTransform>().sizeDelta;

            // 현재 남은 총 가격에 클릭한 버튼의 음식값을 빼도록 함
            currentTotalPrice -= pricesData[priceSequence];

            priceSequence++;

            CheckClear();
        }

        // 메뉴판에서 가격을 표기하도록 함.
        private void SetMenuPrice()
        {
            int menuNum = 0;

            for(;menuNum < txtFoodPrices.Length; menuNum++)
            {
                txtFoodPrices[menuNum].text = foodPrices[menuNum].ToString();
            }

            for(int i = 0; i<txtDrinkPrices.Length; menuNum++)
            {
                txtDrinkPrices[i].text = foodPrices[menuNum].ToString();
                i++;
            }

        }

        // 음식가격 계산하기
        private void CheckClear()
        {
            // 음식을 3개 고르지 않으면 음식가격 체크 건너뜀
            if (priceSequence == 3)
            {
                FoodReset(false);
                Debug.Log("Current Total Price: " + currentTotalPrice);
                if (currentTotalPrice == 0)
                {
                    MissionClear();
                }
                else
                {
                    Invoke(nameof(ResetCalculating), ResetTime);
                }
            }
        }
        private void ResetFoodImage()
        {
            for(int i = 0; i< foodImages.Length; ++i)
            {
                foodImages[i].color = new Color(1, 1, 1, 0);
            }
        }

        // 버튼 비활성화 함수
        public void OnStateFood(Button _button, bool _buttonState)
        {
            _button.interactable = _buttonState;
        }

        // 메뉴 선택 결과판 초기화
        private void PriceReset()
        {
            pricesData = new decimal[priceTexts.Length];

            // 가격 초기화
            for (int i = 0; i<pricesData.Length; ++i)
            {
                pricesData[i] = 0;
            }

            // 선택한 메뉴 이미지 초기화
            for(int i = 0; i<foodImages.Length; ++i)
            {
                foodImages[i].sprite = null;
            }

            priceSequence = 0;

            // 총 음식값 초기화 및 초기 음식값과 동일하게
            currentTotalPrice = startTotalPrice;
        }
        
        // 모든 버튼 비활성화
        private void FoodReset(bool _foodState)
        {
            for (int i = 0; i < foodButtons.Length; ++i)
            {
                OnStateFood(foodButtons[i], _foodState);
            }
        }

        // 계산 다시 하게 하는 함수
        private void ResetCalculating()
        {
            PriceReset(); // 메뉴 선택 결과값 초기화
            FoodReset(true); // 버튼 클릭 가능하게 함
            ResetFoodImage();
        }
        private void MissionClear()
        {
            origin.MissionClear();
            Debug.Log("클리어 했다고 보내!");
        }
    }
}