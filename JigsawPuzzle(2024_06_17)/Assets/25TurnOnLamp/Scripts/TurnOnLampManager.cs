using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TurnOnLamp
{
    public enum MissionState { MovingNozzle, ConnectingNozzle, CoveringLampCover, FiringLamp, Clear}
    public class TurnOnLampManager : OVMissionOrigin
    {
        public MissionState MissionState { get; private set; }

        [Header("Nozzle")]
        [SerializeField] private GasNozzle nozzle;
        [SerializeField] private float gasputtingTime;

        [Header("Cover")]
        [SerializeField] private LampCover cover;
        [SerializeField] private GameObject nozzleCoverSite;

        [Header("Match")]
        [SerializeField] private Match match;
        [SerializeField] private FollowingFire matchFire;
        [SerializeField] private GameObject fire;
        [SerializeField] private float firingTime;
        public float FiringTime => firingTime;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            MovingNozzle();
        }
        public override void Hide()
        {
            Cursor.visible = true;
            StopAllCoroutines();
            base.Hide();
        }
        public void MovingNozzle()
        {
            MissionState = MissionState.MovingNozzle;
            fire.SetActive(false);
            match.gameObject.SetActive(false);
            matchFire.gameObject.SetActive(false);
            cover.gameObject.SetActive(false);            
            nozzle.gameObject.SetActive(true);
            nozzleCoverSite.SetActive(true);
        }
        public void ConnectingNozzle()
        {
            MissionState = MissionState.ConnectingNozzle;
            StartCoroutine(ConnectingNozzleCo());
        }

        private IEnumerator ConnectingNozzleCo()
        {
            // 사운드 재생
            nozzleCoverSite.SetActive(false);

            yield return new WaitForSeconds(gasputtingTime);
            CoveringLampCover();
        }

        private void CoveringLampCover()
        {
            MissionState = MissionState.CoveringLampCover;
            nozzleCoverSite.SetActive(true);
            nozzle.gameObject.SetActive(false);
            cover.gameObject.SetActive(true);
        }

        public void FiringLamp()
        {            
            MissionState = MissionState.FiringLamp;
            Cursor.visible = false;
            nozzleCoverSite.SetActive(false);
            match.gameObject.SetActive(true);
            matchFire.gameObject.SetActive(true);
        }
        public void Clear()
        {            
            MissionState = MissionState.Clear;
            match.gameObject.SetActive(false);
            matchFire.gameObject.SetActive(false);
            fire.SetActive(true);
            Cursor.visible = true;

            OVSoundRoot.Instance.Mission.ID26FiringLamp.Play();

            MissionClear();            
        }
    }
}