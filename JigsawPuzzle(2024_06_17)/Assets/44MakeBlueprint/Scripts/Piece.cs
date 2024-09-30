using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.MakeBlueprint
{
    public class Piece : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public RectTransform LayerRectTransform { get; set; }
        public Canvas canvas { get; set; }
        public int PieceId { get; set; }
        public PuzzleManager manager { get; set; }
        public bool isInPlace { get { return manager.IsInPlace(this); } }
        public bool CanMove { get; set; }
        private RectTransform rectTransform;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            CanMove = true;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (!CanMove) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!CanMove) return;

            OVSoundRoot.Instance.Mission.ID48MatchPuzzle.Play();

            if (isInPlace)
                manager.CheckClear();
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, LayerRectTransform);
        }
    }
}