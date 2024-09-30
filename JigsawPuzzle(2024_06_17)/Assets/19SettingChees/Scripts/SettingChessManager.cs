using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SettingChess
{
    public class SettingChessManager : OVMissionOrigin
    {
        [Header("Chess Pieces")]
        [SerializeField] private ChessPiece[] chessPieces;
        private RectTransform[] chessPiecesRectTransforms;
        private Vector2[] chessPieceStartPosition;

        [Header("Chess Place")]
        [SerializeField] private ChessPlace[] chessPlaces;
        private RectTransform[] chessPlaceRectTransforms;

        [Header("Tray Pieces")]
        [SerializeField] private RectTransform[] trayPiecesZones;

        private const float chessPlaceDistance = 100f;
        public override void Awake()
        {
            base.Awake();
            SetChessPiecesPosition();
            SetChessPlacePosition();

        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            OVSoundRoot.Instance.Mission.ID19PrefaringChess.Play();
            SetRndChessPiece();
        }
        private void SetChessPiecesPosition()
        {
            chessPiecesRectTransforms = new RectTransform[chessPieces.Length];
            chessPieceStartPosition = new Vector2[chessPieces.Length];

            for(int i = 0; i< chessPieces.Length; i++)
            {
                chessPiecesRectTransforms[i] = chessPieces[i].GetComponent<RectTransform>();
                chessPieceStartPosition[i] = chessPiecesRectTransforms[i].anchoredPosition;
            }
        }

        private void SetChessPlacePosition()
        {
            chessPlaceRectTransforms = new RectTransform[chessPlaces.Length];

            for(int i = 0; i< chessPlaces.Length; i++)
            {
                chessPlaceRectTransforms[i] = chessPlaces[i].GetComponent<RectTransform>();

                // 체스 말에 오리진 클래스 할당하기
                chessPieces[i].SetManager(this);
            }
        }

        public void CheckClear()
        {
            for(int i = 0; i< chessPieces.Length; i++)
            {
                if (!chessPieces[i].IsInPosition) return;
            }

            MissionClear();
        }
        private void SetRndChessPiece()
        {
            for(int i = 0; i < chessPiecesRectTransforms.Length; i++)
            {
                // 기물의 정보 초기화
                chessPiecesRectTransforms[i].anchoredPosition = chessPieceStartPosition[i];
                chessPieces[i].IsInPosition = true;

                // 체스 자리의 배치 여부 초기화
                chessPlaces[i].HasPiece = true;
            }

            int[] rndList = GetRndNum(0, chessPieces.Length, trayPiecesZones.Length).ToArray();

            for(int i = 0; i< rndList.Length; i++)
            {
                // 랜덤 기물의 정보 초기화
                chessPieces[rndList[i]].IsInPosition = false;
                chessPiecesRectTransforms[rndList[i]].anchoredPosition = trayPiecesZones[i].anchoredPosition;
                chessPieces[rndList[i]].SetTrayPosition(trayPiecesZones[i].anchoredPosition);

                // 체스 자리의 배치 여부 초기화
                chessPlaces[rndList[i]].HasPiece = false;
            }
        }
        public bool CheckIsInPosition(ChessPiece _chessPiece)
        {
            RectTransform chessPieceRect = _chessPiece.GetComponent<RectTransform>();

            for (int i = 0; i < chessPlaces.Length; i++)
            {
                if (Vector2.Distance(chessPieceRect.anchoredPosition, chessPlaceRectTransforms[i].anchoredPosition) < chessPlaceDistance)
                {
                    if (_chessPiece.PieceID == chessPlaces[i].PlaceID)
                    {
                        if (!chessPlaces[i].HasPiece)
                        {
                            chessPieceRect.anchoredPosition = chessPlaceRectTransforms[i].anchoredPosition;
                            _chessPiece.IsInPosition = true;
                            chessPlaces[i].HasPiece = true;

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private List<int> GetRndNum(int _Min, int _Max, int _countOfNum)
        {
            List<int> outputNums = new List<int>();
            List<int> candidateNums = new List<int>();

            for(int i = _Min; i<_Max - _Min; i++)
            {
                candidateNums.Add(i);
            }

            for(int i = 0; i< _countOfNum; i++)
            {
                int a = UnityEngine.Random.Range(0, candidateNums.Count);

                outputNums.Add(candidateNums[a]);
                candidateNums.RemoveAt(a);
            }

            return outputNums;
        }
    }
}