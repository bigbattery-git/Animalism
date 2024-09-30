using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MakeBlueprint
{
    public class PuzzleManager : MonoBehaviour
    {
        [Header("퍼즐 관련")]
        [SerializeField] private GameObject[] pieces;
        [SerializeField] private GameObject[] pieceStates;

        private RectTransform[] pieceRectTransforms;
        private RectTransform[] stateRectTransforms;

        [Header("미션 관련")]
        [SerializeField] private RectTransform layerRectTransform;
        [SerializeField] private Canvas canvas;

        public OVMissionOrigin origin { get; set; }

        private void Awake()
        {
            pieceRectTransforms = new RectTransform[pieces.Length];
            stateRectTransforms = new RectTransform[pieceStates.Length];

            for (int i = 0; i < pieces.Length; i++)
            {
                Piece piece = pieces[i].GetComponent<Piece>();

                if(piece == null)
                {
                    piece = pieces[i].AddComponent<Piece>();
                }
                piece.LayerRectTransform = this.layerRectTransform;
                piece.canvas = this.canvas;
                piece.PieceId = i;
                piece.manager = this;

                pieceRectTransforms[i] = piece.GetComponent<RectTransform>();
            }
            for(int i = 0; i < pieceStates.Length; i++)
            {
                PieceState state = pieceStates[i].GetComponent<PieceState>();
                if(state == null)
                {
                    state = pieceStates[i].AddComponent<PieceState>();
                }

                state.PieceStateID = i;

                stateRectTransforms[i] = pieceStates[i].GetComponent<RectTransform>();
            }
        }

        private void OnEnable()
        {
            foreach(var piece in pieces)
            {
                float x = Random.Range(0, layerRectTransform.sizeDelta.x);
                float y = Random.Range(0, layerRectTransform.sizeDelta.y);
                piece.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }

        public bool IsInPlace(Piece _piece)
        {
            RectTransform pieceRect = _piece.GetComponent<RectTransform>();
            for (int i = 0; i < pieceStates.Length; i++)
            {
                if(Vector2.Distance(pieceRect.anchoredPosition, stateRectTransforms[i].anchoredPosition) < 50f)
                {
                    if (_piece.PieceId == pieceStates[i].GetComponent<PieceState>().PieceStateID)
                    {
                        // Debug.Log("Is In Place");
                        return true;
                    }                        
                }
            }
            return false;
        }
        public void CheckClear()
        {
            Piece[] pieceComponents = new Piece[pieces.Length];

            for(int i = 0; i<pieces.Length; i++)
            {
                pieceComponents[i] = pieces[i].GetComponent<Piece>();
            }
            foreach(var pieceCompo in pieceComponents)
            {
                if (!pieceCompo.isInPlace)
                    return;
            }
            // ==================================================================
            for(int i = 0; i<pieceRectTransforms.Length;i++)
                pieceRectTransforms[i].anchoredPosition = stateRectTransforms[i].anchoredPosition;

            for(int i = 0; i< pieces.Length; i++)
                pieceComponents[i].CanMove = false;

            if (!origin)
                Debug.Log("Mission Clear");
            else
                origin.MissionClear();
        }
    }
}