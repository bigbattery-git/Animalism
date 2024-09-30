using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace N_JigsawPuzzlePractice
{
    public class JigsawPuzzlePractice : MonoBehaviour
    {
        public GameObject puzzlePosSet;
        public GameObject puzzlePieceSet;
        public bool IsClear()
        {
            for(int i = 0; i<puzzlePosSet.transform.childCount; i++)
            {
                if(puzzlePosSet.transform.GetChild(i).transform.childCount == 0)
                {
                    return false;
                }
                if(puzzlePosSet.transform.GetChild(i).GetChild(0).GetComponent<PuzzlePiecePractice>().piece_no != i)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

