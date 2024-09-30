using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Missons.Village.OrganizingTheKeys
{
    public class OrganizingTheKeysManager : OVMissionOrigin
    {
        [Header("Key Texture")]
        [SerializeField] private Image[] keyTextures;
        [SerializeField] private Sprite[] keyTectureSprites;

        [Header("Key Color")]
        [SerializeField] private Image[] keyColors;
        [SerializeField] private Sprite[] KeyColorSprites;

        [Header("Key Box")]
        [SerializeField] private KeyBox[] keyBoxes;

        [Header("Key")]
        [SerializeField] private GameObject keyParents;

        [Header("Data")]
        [SerializeField] private int[] keyBoxNumbers;
        [SerializeField] private int[] keyColorNumbers;
        [SerializeField] private int[] keyTextureNubers;

        [Header("Debug")]
        [SerializeField] TextMeshProUGUI[] debugText;
        [SerializeField] TextMeshProUGUI[] debugTextureText;
        [SerializeField] TextMeshProUGUI[] debugColorText;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            ResetTexture();
        }

        private void ResetTexture()
        {
            keyBoxNumbers = new int[keyBoxes.Length];
            keyColorNumbers = new int[keyColors.Length];
            keyTextureNubers = new int[keyTextures.Length];

            SetRandomNumber(keyColorNumbers, 0, 1, 2, 3);
            SetRandomNumber(keyTextureNubers, 0, 4, 8, 12);

            SetKeyBoxNumber();

            SetTextureSprites(keyTextures, keyTectureSprites);
            SetColorSprites(keyColors, KeyColorSprites);

            // SetDebugKeyBoxText(debugText, keyBoxNumbers);
            // SetDebugKeyBoxText(debugTextureText, keyTextureNubers);
            // SetDebugKeyBoxText(debugColorText, keyColorNumbers);
        }
        private void SetRandomNumber(int[] _numbers, int _a, int _b, int _c, int _d)
        {
            List<int> list = new List<int>() { _a,_b,_c,_d};

            for(int i = 0; i< _numbers.Length; ++i)
            {
                int rnd = Random.Range(0, list.Count);
                _numbers[i] = list[rnd];
                list.RemoveAt(rnd);
            }
        }
        private void SetKeyBoxNumber(int[] _keyTextureNubmers, int[] _KeyColorNumbers)
        {
            int plusArrayNumber = 0;
            for(int i = 0; i< _keyTextureNubmers.Length; ++i)
            {
                for(int j = 0; j< _KeyColorNumbers.Length; ++j)
                {
                    keyBoxNumbers[j + plusArrayNumber] = _keyTextureNubmers[i] + _KeyColorNumbers[j];
                }
                plusArrayNumber += 4;
            }
        }
        private void SetKeyBoxNumber()
        {
            SetKeyBoxNumber(keyTextureNubers, keyColorNumbers);
            Key[] keys = keyParents.GetComponentsInChildren<Key>();

            for(int i = 0; i<keyBoxes.Length; i++)
            {
                keyBoxes[i].KeyCaseID = keyBoxNumbers[i];
            }

            foreach(var key in keys)
            {
                key.SetMyKeyBox(keyBoxes);
            }
        }
        private void SetTextureSprites(Image[] _keyTextures, Sprite[] _keyTextureSprites)
        {
            for(int i = 0; i<_keyTextures.Length; ++i)
            {
                int num = keyTextureNubers[i] / 4;
                _keyTextures[i].sprite = _keyTextureSprites[num];
            }
        }
        private void SetColorSprites(Image[] _keyTextures, Sprite[] _keyTextureSprites)
        {
            for (int i = 0; i < _keyTextures.Length; ++i)
            {
                int num = keyColorNumbers[i];
                _keyTextures[i].sprite = _keyTextureSprites[num];
            }
        }
        private void SetDebugKeyBoxText(TextMeshProUGUI[] _debugText, int[] data)
        {
            for(int i = 0; i<data.Length; ++i)
            {
                _debugText[i].text = data[i].ToString();
            }
        }
    }
}