using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.ClearingTheTable
{
    public class Stain : MonoBehaviour
    {
        public int clearCount = 0;
        public Image image;
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        public void SetImageAlpha(int _totalCount)
        {
            image.color = new Color(1, 1, 1, 1 - ((float)clearCount/_totalCount ));

            OVSoundRoot.Instance.Mission.ID12CleaningTable.Play();
        }

        private void OnDisable()
        {
            clearCount = 0;
            image.color = new Color(1, 1, 1, 1);
        }
    }
}