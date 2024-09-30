using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.FixFloor
{
    public enum MissionState { PutoffBrokenNail, ChangeBoard_Broken, ChangeBoard_New, PutonNail, Nailing, MissionClear}
    public class FixFloorManager : OVMissionOrigin
    {
        public MissionState MissionState { get; private set; } = MissionState.Nailing;
        [Header("Mission")]
        [SerializeField] private Canvas canvas;

        [Header("Hammer")]
        [SerializeField] private Hammer hammer;
        [SerializeField] private Hammer hammerReverse;
        [SerializeField] private float hammeringTime;
        [Header("Board")]
        [SerializeField] private BrokenBoard brokenBoard;
                         private Vector2 brokenBoardPlace;
        [SerializeField] private Board board;
        [SerializeField] private float boardPlaceDistance = 50f;
        [Header("Nails")]
        [SerializeField] private NailingPosition[] nailingPositions;
        public float HammeringTime => hammeringTime;        

        public override void Awake()
        {
            base.Awake();

            hammer.Manager = this;

            hammerReverse.Manager = this;

            brokenBoard.Manager = this;
            brokenBoard.canvas = this.canvas;
            brokenBoardPlace = brokenBoard.GetComponent<RectTransform>().anchoredPosition;

            board.Manager = this;
            board.canvas = this.canvas;

            foreach (var point in nailingPositions)
            {
                point.Manager = this;
                point.transform.GetComponentInChildren<Nail>(true).Manager = this;
            }
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            PutoffBrokenNail();
        }

        public void PutoffBrokenNail()
        {
            MissionState = MissionState.PutoffBrokenNail;
            brokenBoard.gameObject.SetActive(true);
            hammerReverse.gameObject.SetActive(true);

            hammer.gameObject.SetActive(false);

            Cursor.visible = false;
        }
        public void ChangeBoard_Broken()
        {
            hammerReverse.gameObject.SetActive(false);
            MissionState = MissionState.ChangeBoard_Broken;

            Cursor.visible = true;
        }

        public void ChangeBoard_New()
        {
            MissionState = MissionState.ChangeBoard_New;
        }

        public void PutonNail()
        {
            MissionState = MissionState.PutonNail;
        }
        public void Nailing()
        {
            MissionState = MissionState.Nailing;
            hammer.gameObject.SetActive(true);

            Cursor.visible = false;
        }
        public override void MissionClear()
        {
            foreach (var point in nailingPositions)
                if (!point.IsNailed) return;

            MissionState = MissionState.MissionClear;

            hammer.gameObject.SetActive(false);
            Cursor.visible = true;

            base.MissionClear();
        }

        public override void Hide()
        {
            base.Hide();
            Cursor.visible = true;
        }

        public bool CanChangeNewBoard(RectTransform _rectTransform)
        {
            if (Vector2.Distance(_rectTransform.anchoredPosition, brokenBoardPlace) > 300f)
                return true;

            return false;
        }
        public bool IsInBrokenPosition(RectTransform _rectTransform)
        {
            if(Vector2.Distance(_rectTransform.anchoredPosition, brokenBoardPlace) < boardPlaceDistance)
            {
                _rectTransform.anchoredPosition = brokenBoardPlace;
                return true;
            }
            return false;
        }
        public bool IsReadyToNailing()
        {
            foreach (var position in nailingPositions)
                if (!position.isReadyToNailing) return false;

            return true;
        }
    }
}