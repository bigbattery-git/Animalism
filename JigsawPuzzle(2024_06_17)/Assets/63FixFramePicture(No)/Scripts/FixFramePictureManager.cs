using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.FixFramePicture
{
    public struct PlaceInfo
    {
        public int placeID;
        public Vector2 placeVector;
    }
    public class FixFramePictureManager : OVMissionOrigin
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform layerTransform;

        [Header("===============================================")]
        [SerializeField] private Piece[] pieces;
        [SerializeField] private float pieceDistance = 50f;
        private PlaceInfo[] placeInfos;

        public override void Awake()
        {
            base.Awake();
            placeInfos = new PlaceInfo[pieces.Length];

            for(int i = 0; i<pieces.Length; i++)
            {
                pieces[i].manager = this;
                pieces[i].canvas = canvas;
                pieces[i].layerTransform = layerTransform;
                pieces[i].pieceID = i;
                placeInfos[i].placeVector = pieces[i].GetComponent<RectTransform>().anchoredPosition;
                placeInfos[i].placeID = i;
            }
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            foreach(var piece in pieces)
            {
                piece.GetComponent<RectTransform>().anchoredPosition = SetPieceTransform();
            }
        }
        private Vector2 SetPieceTransform()
        {
            float rndX = Random.Range(0, layerTransform.sizeDelta.x);
            float rndY = Random.Range(-layerTransform.sizeDelta.y, 0);

            // Vector2 returnVec = new Vector2(layerTransform.anchoredPosition.x + rndX, layerTransform.anchoredPosition.x + rndY);
            Vector2 returnVec = layerTransform.anchoredPosition + new Vector2(rndX, rndY);
            return returnVec;
        }
        public bool IsInPlace(Piece _piece, RectTransform _rectTransform)
        {
            for(int i = 0; i < placeInfos.Length; i++)
            {
                if(_piece.pieceID == placeInfos[i].placeID)
                {
                    if(Vector2.Distance(_rectTransform.anchoredPosition, placeInfos[i].placeVector) < pieceDistance)
                    {
                        _rectTransform.anchoredPosition = placeInfos[i].placeVector;
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckClear()
        {
            for(int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].canMove) return;
            }

            MissionClear();
        }
    }
}