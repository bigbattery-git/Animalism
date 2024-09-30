using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.CleaningTheFloor
{
    public enum StartPosition
    {
        Left,
        Right
    }
    public class Duster : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        RectTransform rectTransform;
        [SerializeField] float moveSpeed;
        [SerializeField] RectTransform[] stainTransforms;
        [SerializeField] RectTransform[] finishLineTransforms;
        int checkPoint = 1;

        [SerializeField] StartPosition startPosition = StartPosition.Left;
        CleaningTheFloorManager manager;

        [SerializeField] float distanceEventData;
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.position = stainTransforms[0].position;
            stainTransforms[0].GetComponent<Stain>().ChangeStainSprite();

            manager = GameObject.Find("Cleaning the floor").GetComponent<CleaningTheFloorManager>();

            ResetFinishLineWidth();

            StartCoroutine(CheckMissionClear());
        }
        private void ResetFinishLineWidth()
        {
            foreach(var i in finishLineTransforms)
            {
                i.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            float a = eventData.delta.x * moveSpeed;
            Vector2 next = (stainTransforms[checkPoint].position - rectTransform.position).normalized;
            transform.Translate(next * a, Space.World);

            if (GetOutAtEventData(eventData))
            {
                ResetWhenDragEnd();
                return;
            }
        }
        private bool GetOutAtEventData(PointerEventData eventData)
        {
            if(Vector2.Distance(rectTransform.position, eventData.position) > distanceEventData)
            {
                return true;
            }
            return false;
        }
        IEnumerator CheckMissionClear()
        {
            while (true)
            {
                switch (startPosition)
                {
                    case StartPosition.Left:
                        SetGameZoneLeft();
                        break;
                    case StartPosition.Right:
                        SetGameZoneRight();
                        break;
                }
                float distance = (finishLineTransforms[checkPoint - 1].position - rectTransform.position).magnitude;
                finishLineTransforms[checkPoint - 1].sizeDelta = new Vector2(distance, 19.5f);
                if(SetNextPosition() == true)
                {
                    SendClear();
                    break;
                }
                yield return null;
            }
        }
        private bool SetNextPosition()
        {
            if (rectTransform.position == stainTransforms[checkPoint].position)
            {
                stainTransforms[checkPoint].GetComponent<Stain>().ChangeStainSprite();
                Debug.Log("Same position");
                
                if (checkPoint == 4)
                {
                    return true;                    
                }
                else
                {
                    checkPoint++;
                }
            }
            return false;
        }
        private void SendClear()
        {
            Debug.Log("Now Clear");
            manager.AddMissionClearCount();
            if (manager.IsMissionClear())
            {
                manager.Clear();
            }
            else if (!manager.IsMissionClear())
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
        private void SetGameZoneLeft()
        {
            if (rectTransform.position.x < stainTransforms[checkPoint - 1].position.x)
            {
                rectTransform.position = stainTransforms[checkPoint - 1].position;
            }
            if (rectTransform.position.x > stainTransforms[checkPoint].position.x)
            {
                rectTransform.position = stainTransforms[checkPoint].position;
            }
        }
        private void SetGameZoneRight()
        {
            if (rectTransform.position.x > stainTransforms[checkPoint - 1].position.x)
            {
                rectTransform.position = stainTransforms[checkPoint - 1].position;
            }
            if (rectTransform.position.x < stainTransforms[checkPoint].position.x)
            {
                rectTransform.position = stainTransforms[checkPoint].position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!SetNextPosition())
            ResetWhenDragEnd();
        }
        private void ResetWhenDragEnd()
        {
            ResetFinishLineWidth();
            checkPoint = 1;
            rectTransform.position = stainTransforms[checkPoint - 1].position;
        }
    }
}