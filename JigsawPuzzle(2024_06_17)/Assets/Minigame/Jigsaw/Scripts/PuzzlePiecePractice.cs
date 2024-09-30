using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace N_JigsawPuzzlePractice
{
    public class PuzzlePiecePractice : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public float snapOffset = 30f;
        public int piece_no;
        public GameObject piecePos;
        public JigsawPuzzlePractice puzzle;

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
        private bool CheckSnapPuzzle()
        {
            for(int i = 0; i<puzzle.puzzlePosSet.transform.childCount; i++)
            {
                if(puzzle.puzzlePosSet.transform.GetChild(i).childCount != 0)
                {
                    continue;
                }
                else if(Vector2.Distance(puzzle.puzzlePosSet.transform.GetChild(i).transform.position, transform.position) < snapOffset && piece_no == i)
                {
                    this.transform.SetParent(puzzle.puzzlePosSet.transform.GetChild(i).transform);
                    transform.localPosition = Vector3.zero;
                    return true;
                }
            }
            return false;
        }
    }
}