using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JigsawPuzzle
{
    public class PuzzlePiece : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public int snapOffset = 30;
        public int piece_no;
        public GameObject piecePos;
        public JigsawPuzzle puzzle;   
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!CheckSnapPuzzle())
            {
                transform.SetParent(puzzle.puzzlePieceSet.transform);
            }
            if (puzzle.IsClear())
            {
                Debug.Log("Clear");
            }
        }
        bool CheckSnapPuzzle()
        {
            for(int i =0; i<puzzle.puzzlePosSet.transform.childCount; i++)
            {
                // 위치에 자식오브젝트가 있다면, 이미 퍼즐조각이 놓여진 것
                if(puzzle.puzzlePosSet.transform.GetChild(i).childCount != 0)
                {
                    continue;
                }
                else if(Vector2.Distance(puzzle.puzzlePosSet.transform.GetChild(i).transform.position, transform.position) < snapOffset && i == piece_no)
                {
                    transform.SetParent(puzzle.puzzlePosSet.transform.GetChild(i).transform);
                    transform.localPosition = Vector3.zero;
                    return true;
                }
            }
            return false;
        }

    }
}

