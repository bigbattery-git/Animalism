using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.Ruling
{
    public class Hammer : MonoBehaviour, IDragHandler
    {
        RectTransform rectTransform;
        [SerializeField] private OVMissionOrigin manager;
        [SerializeField] private Canvas canvas;

        [SerializeField] float snapOffset;
        [SerializeField] RectTransform propPosition;
        [SerializeField] RectTransform layerTransform;
        private bool isCanClick = false;

        private Vector2 startVector;

        private IEnumerator SetCount;

        [SerializeField] private PropExit propExit;

        private int hitCount = 0;
        private const int MissionClearCount = 3;

        private bool isInPosition = false;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            startVector = rectTransform.anchoredPosition;
        }
        private void OnEnable()
        {
            if (SetCount != null)
            {
                StopCoroutine(SetCount);
            }

            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            isCanClick = false;
            isInPosition = false;

            hitCount = 0;
            rectTransform.anchoredPosition = startVector;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (!IsClosePropPosition())
            {
                OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
            }
        }
        private bool IsClosePropPosition()
        {
            float mag = Vector2.Distance(propPosition.anchoredPosition, rectTransform.anchoredPosition);

            if (mag < snapOffset)
            {
                this.rectTransform.position = propPosition.position;

                if (!isInPosition)
                {
                    isCanClick = true;
                }
                isInPosition = true;
                return true;
            }
            return false;
        }
        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerTransform);

            if (Input.GetMouseButtonDown(0) && isCanClick == true)
            {
                isCanClick = false;

                SetCount = SetCountClear();
                StartCoroutine(SetCount); 
            }
        }

        IEnumerator SetCountClear()
        {            
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            propExit.hammerEffects[hitCount].SetActive(true);

            OVSoundRoot.Instance.Mission.ID69Hammering.Play();
            yield return new WaitForSeconds(0.5f);

            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            propExit.hammerEffects[hitCount].SetActive(false);
           
            yield return new WaitForSeconds(0.01f);

            hitCount++;

            if (hitCount >= MissionClearCount)
            {
                Debug.Log("Clear");
                manager.MissionClear();
            }
            else
            {
                isCanClick = true;
            }
        }
    }
}
