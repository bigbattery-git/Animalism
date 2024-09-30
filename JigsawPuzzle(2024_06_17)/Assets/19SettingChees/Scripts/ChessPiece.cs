using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.SettingChess
{
    public class ChessPiece : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public bool IsInPosition { get; set; }
        public int PieceID => pieceID;

        // UI 요소
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;

        // 체스 기물 정보
        [SerializeField] private int pieceID;

        // 체스 기물 자리 정보
        private Vector2 trayPosition;

        // 기타
        [SerializeField] private RectTransform layerRectTransform;
        private SettingChessManager manager;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (IsInPosition) return;

            OVMissionUtility.ObjectMoveToDrag(rectTransform, canvas, eventData);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (IsInPosition) return;

            if (!manager.CheckIsInPosition(this))
            {
                rectTransform.anchoredPosition = trayPosition;
            }
            else
            {
                manager.CheckClear();
            }
        }

        private void Update()
        {
            OVMissionUtility.HoldInLayer(rectTransform, layerRectTransform);
        }

        public void SetTrayPosition(Vector2 _trayPosition) => trayPosition = _trayPosition;
        public void SetManager(SettingChessManager _origin) => manager = _origin;
    }
}