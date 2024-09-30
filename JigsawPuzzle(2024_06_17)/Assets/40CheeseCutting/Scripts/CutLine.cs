using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.CakeCutting
{
    public class CutLine : MonoBehaviour
    {
        public bool IsCutted => isCutted;

        private bool isCutted;
        private Image image;
        private Color beforeCutColor = new Color(1, 1, 1, 0);
        private Color afterCutColor = new Color(1, 1, 1, 1);

        [SerializeField] private SliceLine sliceLine;
        public SliceLine SliceLine => sliceLine;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetCutLine()
        {
            image.color = afterCutColor;
            isCutted = true;
            OVSoundRoot.Instance.Mission.ID44CuttingCake.Play();

            sliceLine.CheckClear();
        }
        public void ResetCutLine()
        {
            if(image == null)
            {
                image = GetComponent<Image>();
            }
            image.color = beforeCutColor;
            isCutted = false;
        }
    }
}