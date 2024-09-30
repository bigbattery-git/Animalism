using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.OpeningBlanket
{
    [System.Serializable]
    public struct BlanketObject
    {
        public Image image;
        public Sprite beforeBlanket;
        public Sprite afterBlanket;

        [HideInInspector] public bool isOpening;
    }
    public class Blanket : MonoBehaviour
    {
        [SerializeField] private BlanketObject[] blanketObjects;
        [SerializeField] private RectTransform CenterPosition;

        private bool isClickCenter = false;

        private RectTransform rectTransform;
        private Vector3 startClickPosition;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            for(int i = 0; i< blanketObjects.Length; i++)
            {
                blanketObjects[i].image.sprite = blanketObjects[i].beforeBlanket;
                blanketObjects[i].isOpening = false;
            }
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && IsInMousePosition())
            {
                Debug.Log(Input.mousePosition);

                startClickPosition = Input.mousePosition;
                isClickCenter = true;
            }
            if (isClickCenter)
            {
                CheckBlanket();
            }
            if (Input.GetMouseButtonUp(0))
            {
                isClickCenter = false;
            }
        }

        private bool IsInMousePosition()
        {
            float distance = 400f;

            bool isWidthPosition = (Input.mousePosition.x < rectTransform.position.x + distance) && (Input.mousePosition.x > rectTransform.position.x - distance);
            bool isHeightPosition = (Input.mousePosition.y < rectTransform.position.y + distance) && (Input.mousePosition.y > rectTransform.position.y - distance);

            return isWidthPosition && isHeightPosition;
        }
        private void CheckBlanket()
        {
            Vector3 wannaVec = (Input.mousePosition - startClickPosition).normalized;
            float wannaDistance = (Input.mousePosition - startClickPosition).magnitude;
            if(Mathf.Abs(wannaDistance) > 400f)
            {
                if (wannaVec.x < 0 && wannaVec.y > 0)
                {
                    SetBlanket(ref blanketObjects[0]);
                }
                if (wannaVec.x > 0 && wannaVec.y > 0)
                {
                    SetBlanket(ref blanketObjects[1]);
                }
                if (wannaVec.x < 0 && wannaVec.y < 0)
                {
                    SetBlanket(ref blanketObjects[2]);
                }
                if (wannaVec.x > 0 && wannaVec.y < 0)
                {
                    SetBlanket(ref blanketObjects[3]);
                }
            }
        }

        private void SetBlanket(ref BlanketObject blanketObject)
        {
            blanketObject.image.sprite = blanketObject.afterBlanket;
            blanketObject.isOpening = true;
            isClickCenter = false;

            CheckClear();
        }

        private void CheckClear()
        {
            foreach(var blank in blanketObjects)
            {
                if (!blank.isOpening) 
                {
                    return;
                } 
            }

            Debug.Log("Clear");
        }
    }
}