using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InputMode
{
    Random, Artificial
}
namespace Missons.Village
{
    public class PressButtonInOrderManager : MonoBehaviour
    {
        [SerializeField] Button[] buttons;
        [SerializeField] Color brightColor;
        [SerializeField] float brightTime;
        [SerializeField] int inputOrderNumber;
        [SerializeField] int brightCount;
        [SerializeField] InputMode inputMode = InputMode.Random;
        ColorBlock[] buttonColors;
        int[] orderNumber;

        private void Awake()
        {
            buttonColors = new ColorBlock[buttons.Length];
            for(int i = 0; i < buttons.Length; i++)
            {
                buttonColors[i] = buttons[i].colors;
            }
            switch (inputMode)
            {
                case InputMode.Random:
                    orderNumber = new int[brightCount];
                    for(int i = 0; i < brightCount; ++i)
                    {
                        orderNumber[i] = Random.Range(1, 5);
                    }
                    break;
                case InputMode.Artificial:
                    int _length = inputOrderNumber.ToString().Length;
                    Debug.Log("_length : " + _length);
                    orderNumber = new int[_length];
                    for(int i=0; i< orderNumber.Length; ++i)
                    {
                        orderNumber[i] = SplitNumber(inputOrderNumber, _length - i);
                        Debug.Log(orderNumber[i]);
                    }
                    break;
            }
            StartCoroutine(ShowButtonToPress(4));
        }
        IEnumerator BrightButtons(int _buttonNumber)
        {
            /*ColorBlock colorBlock = buttons[_buttonNumber].colors;
            colorBlock.disabledColor = brightColor;
            buttons[_buttonNumber].colors = colorBlock;*/

            yield return new WaitForSeconds(brightTime);

            /*colorBlock.disabledColor = buttonColors[_buttonNumber].disabledColor;
            buttons[_buttonNumber].colors = colorBlock;*/

            yield return new WaitForSeconds(0.1f);
        }
        IEnumerator ShowButtonToPress(int _brightCount)
        {
            for(int i = 0; i < buttons.Length; ++i)
            {
                ButtonInteractable(false);
            }
            for(int i = 0; i < _brightCount; ++i)
            {
                yield return StartCoroutine(BrightButtons(1));
                Debug.Log("¹øÂ½");
            }
            for (int i = 0; i < buttons.Length; ++i)
            {
                ButtonInteractable(true);
            }
        }
        private void ButtonInteractable(bool _turnOnOff)
        {
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].interactable = _turnOnOff;
            }
        }
        private int GetExponentiation(int _intiger, int _count)
        {
            int _currentIntiger = _intiger;

            if(_count < 0 && _count == 0)
                return 1;

            else if(_count == 1)
                return _intiger;

            for(int i = 0; i< _count - 1; ++i)
                _currentIntiger *= _intiger;

            return _currentIntiger;
        }
        private int SplitNumber(int _targetNumber, int _cipher)
        {
            // return (_targetNumber % GetExponentiation(10, _cipher) - _targetNumber % GetExponentiation(10, _cipher - 1))/GetExponentiation(10, _cipher);
            return _targetNumber / GetExponentiation(10, _cipher);
        }
    }
}