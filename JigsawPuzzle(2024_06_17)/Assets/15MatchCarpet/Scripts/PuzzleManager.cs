using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MatchCarpet
{
    public class PuzzleManager : MonoBehaviour
    {
        [Header("미션 오브젝트 관련")]
        [SerializeField] private GameObject[] pieces;
        [SerializeField] private GameObject[] piecePlaces;

        private RectTransform[] pieceRects;
        private RectTransform[] piecePlaceRects;

        [Header("전체 미션 관련")]
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerRectTransform;

        public OVMissionOrigin origin { get; set; }
        public bool IsClear { get; private set; }
        private void Awake()
        {
            pieceRects = new RectTransform[pieces.Length];
            piecePlaceRects = new RectTransform[piecePlaces.Length];

            for(int i = 0; i< pieces.Length; i++)
            {
                Piece piece = pieces[i].GetComponent<Piece>();

                if(!piece) piece = pieces[i].AddComponent<Piece>();

                piece.PieceID = i;
                piece.canvas = this.canvas;
                piece.LayerRectTransform = this.layerRectTransform;
                piece.manager = this;

                pieceRects[i] = piece.GetComponent<RectTransform>();
            }

            for(int i = 0; i<piecePlaces.Length; i++)
            {
                PiecePlace place = piecePlaces[i].GetComponent<PiecePlace>();

                if (!place) place = piecePlaces[i].AddComponent<PiecePlace>();

                place.PlaceID = i;

                piecePlaceRects[i] = place.GetComponent<RectTransform>();
            }
        }

        private void OnEnable()
        {
            for(int i = 0; i<pieces.Length; i++)
            {
                pieces[i].transform.SetSiblingIndex(i);
            }

            foreach(var rect in pieceRects)
            {
                float x = Random.Range(0, layerRectTransform.sizeDelta.x);
                float y = Random.Range(0, layerRectTransform.sizeDelta.y);

                rect.anchoredPosition = new Vector2(x, y);
            }

            for( int i = 0; i<pieces.Length; i++)
            {
                pieces[i].transform.SetSiblingIndex(i);
            }
            IsClear = false;
        }

        public bool IsInPlace(Piece _piece)
        {
            RectTransform pieceRect = _piece.GetComponent<RectTransform>();
            for (int i = 0; i < piecePlaces.Length; i++)
            {
                if (Vector2.Distance(pieceRect.anchoredPosition, piecePlaceRects[i].anchoredPosition) < 50f)
                {
                    if (_piece.PieceID == piecePlaces[i].GetComponent<PiecePlace>().PlaceID)
                    {
                        pieceRect.anchoredPosition = piecePlaceRects[i].anchoredPosition;
                        _piece.transform.SetAsFirstSibling();

                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckClear()
        {
            Piece[] pieceComponents = new Piece[pieces.Length];

            for (int i = 0; i < pieces.Length; i++)
            {
                pieceComponents[i] = pieces[i].GetComponent<Piece>();
            }
            foreach (var pieceCompo in pieceComponents)
            {
                if (!pieceCompo.isInPlace)
                    return;
            }
            // ==================================================================
            IsClear = true;

            if (!origin)
                Debug.Log("Mission Clear");
            else
                origin.MissionClear();
        }
    }
}