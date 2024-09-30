using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizingTheShelves
{
    public class ShelfObject : MonoBehaviour
    {
        [SerializeField] private RectTransform[] objectTransform;
        private Vector2[] startObjectTransform;

        private void Awake()
        {
            startObjectTransform = new Vector2[objectTransform.Length];

            for(int i = 0; i< objectTransform.Length; i++)
            {
                startObjectTransform[i] = objectTransform[i].anchoredPosition;
            }
        }
        public void SetRndObject(int _objectNum, int _positionNum)
        {
            objectTransform[_objectNum].anchoredPosition = startObjectTransform[_positionNum];
        }
    }
}