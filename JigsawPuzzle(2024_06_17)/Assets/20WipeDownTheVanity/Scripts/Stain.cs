using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.WipeDownTheVanity
{
    public class Stain : MonoBehaviour
    {
        private Image image;
        private Color defaultColor { get { return new Color(1, 1, 1, 1); } }
        private int touchCount;

        public StainManager manager;
        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetDefaultStain() 
        { 
            image.color = defaultColor;
            touchCount = 0;
        }

        public void OnTouchStain(int _cleanCount)
        {
            touchCount++;
            image.color = new Color(1, 1, 1, 1 - ((float)touchCount / _cleanCount));

            OVSoundRoot.Instance.Mission.ID20CleaningMirror.Play();
            if (touchCount == _cleanCount)
            {                
                gameObject.SetActive(false);
                manager.CheckClear();
            }
        }
    }
}