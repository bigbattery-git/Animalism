using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.SettingChess
{
    public class ChessPlace : MonoBehaviour
    {
        public bool HasPiece { get; set; }
        public int PlaceID => placeID;

        // 체스판 정보
        [SerializeField] private int placeID;
    }
}