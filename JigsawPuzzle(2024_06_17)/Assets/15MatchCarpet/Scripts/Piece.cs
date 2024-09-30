using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.MatchCarpet
{
    public class Piece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        // 전체 미션 관련
        public Canvas canvas { get; set; }
        public RectTransform LayerRectTransform { get; set; }
        private RectTransform rectTransform;

        // piece 관련
        public int PieceID { get; set; }
        public PuzzleManager manager { get; set; }
        public bool IsClear { get { return manager.IsClear; } }
        public bool isInPlace { get; private set; }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            isInPlace = false;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isInPlace) return;
            transform.SetAsLastSibling();

            OVSoundRoot.Instance.Mission.MissionObjectSelectSound.Play();
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (isInPlace) return;
            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (IsClear) return;
            if (isInPlace) return;

            if(manager.IsInPlace(this))
            {
                isInPlace = true;
                manager.CheckClear();
            }
        }
        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, LayerRectTransform);
        }
    }
 }
