using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CleanUpTrash
{
    public class GasPool : MonoBehaviour
    {
        [SerializeField] private RectTransform[] gasRectTransform;

        private void OnEnable()
        {
            foreach(Transform t in gasRectTransform)
            {
                t.gameObject.SetActive(false);
            }
        }

        public GameObject GetGasEffect(Vector2 _vec)
        {
            for(int i = 0; i < gasRectTransform.Length; i++)
            {
                if(gasRectTransform[i].gameObject.activeInHierarchy == false)
                {
                    gasRectTransform[i].gameObject.SetActive(true);
                    gasRectTransform[i].anchoredPosition = _vec;

                    return gasRectTransform[i].gameObject;
                }
            }

            return null;
        }
    }
}