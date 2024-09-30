using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.FixFloor
{
    public class Nail : MonoBehaviour
    {
        public FixFloorManager Manager { get; set; }
        public bool IsNailing { get { return nailingCount == nailings.Length - 1; } }

        [SerializeField] private Sprite[] nailings;
        private Image image;

        private int nailingCount;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            nailingCount = 0;
            image.sprite = nailings[nailingCount];
        }

        public void Nailing()
        {
            if (IsNailing) return;

            nailingCount++;
            image.sprite = nailings[nailingCount];
        }
    }
}