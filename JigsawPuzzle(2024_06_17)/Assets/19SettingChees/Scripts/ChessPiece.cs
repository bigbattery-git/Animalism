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

        // UI ���
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;

        // ü�� �⹰ ����
        [SerializeField] private int pieceID;

        // ü�� �⹰ �ڸ� ����
        private Vector2 trayPosition;

        // ��Ÿ
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