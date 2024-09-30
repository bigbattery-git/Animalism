using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.OpenTheBox
{
    public class OpenTheBoxManager : OVMissionOrigin
    {
        [SerializeField] private GameObject jewel;

        public bool IsClear { get; private set; }
        [Header("오브젝트 위치")]
        [SerializeField] private RectTransform layerTransform;

        private int correctBoxNum;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            IsClear = false;
            correctBoxNum = Random.Range(0, 4);

            jewel.SetActive(false);
        }
        public void CheckClear(Box_ _boxNum)
        {
            if (_boxNum.BoxNum != correctBoxNum) return;

            RectTransform rect = _boxNum.GetComponent<RectTransform>();
            jewel.SetActive(true);
            float modify = 50f;

            if (_boxNum.BoxNum == 1)
                modify = 100f;

            jewel.GetComponent<RectTransform>().anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + modify);

            IsClear = true;

            MissionClear();
        }
    }
}