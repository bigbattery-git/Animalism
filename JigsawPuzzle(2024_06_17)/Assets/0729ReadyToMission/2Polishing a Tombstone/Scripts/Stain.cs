using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.PolishingATombstone
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
        public void OnTouchedDuster(int _totalCount)
        {
            cleanCount++;
            image.color = new Color(1, 1, 1, 1 - ((float)cleanCount / _totalCount));

            OVSoundRoot.Instance.Mission.ID2CleanTombstone.Play();
        }
    }
}