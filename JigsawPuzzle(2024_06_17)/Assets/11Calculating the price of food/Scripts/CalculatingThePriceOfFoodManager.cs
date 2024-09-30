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

        // ����ؾ� �ϴ� �� ���� ���� ����
        IEnumerator SetTotalPrice()
        {
            // �����ϴ� �޴� 3���� ����. ��ġ�� ���� �ʱ� ���� a, b, c �ٸ� ��쿡�� while�� ����� ��.
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

            // currentTotalPrice�� startTotalPrice�� �̽�
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
        /// �� �޴��� ���� ���� ������ �߰�.
        /// </summary>
        /// <param name="_price"></param>
        /// <param name="_sprite"></param>
        /// <param name="_button"></param>
        public void SetPrice(float _price, Sprite _sprite, Button _button)
        {
            // Ŭ�� ��, �޴� �ؿ� ���� ��� �����ֵ��� ��.(���� ������ Ŭ��������, �� ������ ������)
            pricesData[priceSequence] = (decimal)_price;
            foodImages[priceSequence].sprite = _sprite;
            foodImages[priceSequence].color = new Color(1, 1, 1, 1); 
            foodImages[priceSequence].GetComponent<RectTransform>().sizeDelta = _button.GetComponent<RectTransform>().sizeDelta;

            // ���� ���� �� ���ݿ� Ŭ���� ��ư�� ���İ��� ������ ��
            currentTotalPrice -= pricesData[priceSequence];

            priceSequence++;

            CheckClear();
        }

        // �޴��ǿ��� ������ ǥ���ϵ��� ��.
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

        // ���İ��� ����ϱ�
        private void CheckClear()
        {
            // ������ 3�� ���� ������ ���İ��� üũ �ǳʶ�
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

        // ��ư ��Ȱ��ȭ �Լ�
        public void OnStateFood(Button _button, bool _buttonState)
        {
            _button.interactable = _buttonState;
        }

        // �޴� ���� ����� �ʱ�ȭ
        private void PriceReset()
        {
            pricesData = new decimal[priceTexts.Length];

            // ���� �ʱ�ȭ
            for (int i = 0; i<pricesData.Length; ++i)
            {
                pricesData[i] = 0;
            }

            // ������ �޴� �̹��� �ʱ�ȭ
            for(int i = 0; i<foodImages.Length; ++i)
            {
                foodImages[i].sprite = null;
            }

            priceSequence = 0;

            // �� ���İ� �ʱ�ȭ �� �ʱ� ���İ��� �����ϰ�
            currentTotalPrice = startTotalPrice;
        }
        
        // ��� ��ư ��Ȱ��ȭ
        private void FoodReset(bool _foodState)
        {
            for (int i = 0; i < foodButtons.Length; ++i)
            {
                OnStateFood(foodButtons[i], _foodState);
            }
        }

        // ��� �ٽ� �ϰ� �ϴ� �Լ�
        private void ResetCalculating()
        {
            PriceReset(); // �޴� ���� ����� �ʱ�ȭ
            FoodReset(true); // ��ư Ŭ�� �����ϰ� ��
            ResetFoodImage();
        }
        private void MissionClear()
        {
            origin.MissionClear();
            Debug.Log("Ŭ���� �ߴٰ� ����!");
        }
    }
}