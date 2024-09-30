using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.ClearChair
{
    public class Stain : MonoBehaviour
    {
        public int CleanCount => cleanCount;

        private int cleanCount;
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }
        private void OnEnable()
        {
            cleanCount = 0;
            image.color = new Color(1, 1, 1, 1);
        }
        public void OnTouchedDuster(int _totalClearcount)
        {
            cleanCount++;
            image.color = new Color(1, 1, 1, 1 - cleanCount / (float)_totalClearcount);

            OVSoundRoot.Instance.Mission.ID31CleaningChair.Play();
        }
    }
}