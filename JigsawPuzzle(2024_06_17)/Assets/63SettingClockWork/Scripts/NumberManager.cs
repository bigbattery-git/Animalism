using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SettingClockWork
{
    public class NumberManager : MonoBehaviour
    {
        [SerializeField] private List<Number> numbers = new List<Number>();

        private void OnEnable()
        {
            foreach(Number number in numbers)
            {
                number.gameObject.SetActive(false);
            }
            SetRandomNum();
            SetNumPlace();
        }

        private void SetRandomNum()
        {
            int a = 0;

            for(int i = 0; i< numbers.Count; i++)
            {
                a = Random.Range(i, numbers.Count);

                var temp = numbers[a];
                numbers[a] = numbers[i];
                numbers[i] = temp;
            }
        }
        private void SetNumPlace()
        {
            for (int i = 0; i< numbers.Count;i++)
            {
                float angle = i * (360 / 12);
                Vector2 numPlace = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * 300f;

                numbers[i].GetComponent<RectTransform>().anchoredPosition = numPlace;
                numbers[i].gameObject.SetActive(true);
            }
        }
    }
}