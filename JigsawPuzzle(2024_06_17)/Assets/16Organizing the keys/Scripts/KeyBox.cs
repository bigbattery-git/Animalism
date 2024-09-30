using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.OrganizingTheKeys
{
    public class KeyBox : MonoBehaviour
    {
        public int KeyCaseID;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void TurnOnImage()
        {
            image.enabled = true;
            image.color = Color.red;
        }
    }
}