using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MakeAFire
{
    public enum MissionState {None, Deployment, MakeFire, Firing, Picking, Clear, Length}
    public class MakingAFireManager : OVMissionOrigin
    {
        public MissionState state { get; set; } = MissionState.None;

        [SerializeField] private GameObject[] fireWoods;
        [SerializeField] private GameObject fire;
        [SerializeField] private GameObject ashes;
        [SerializeField] private GameObject box;
        [SerializeField] FirewoodManager firewoodManager;

        [Header("Object Moving")]
        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private Match match;

        [Header("Deployment")]
        [SerializeField] private RectTransform firewoodPlace;

        [Header("Mission Time")]
        [SerializeField] private float makeFireTime;
        [SerializeField] private float waitTime;
        public float MakeFireTime => makeFireTime;
        public override void Awake()
        {
            base.Awake();
            var canvas = GetComponent<Canvas>();

            firewoodManager.AwakeInit(this, layerTransform, canvas);

            match.layerTransform = layerTransform;
            match.canvas = canvas;
            match.manager = this;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            DeploayMent();
        }

        public override void Hide()
        {
            base.Hide();
            StopAllCoroutines();
        }

        private void BurnFirewood(bool _isBurned)
        {
            foreach (var firewood in fireWoods)
                firewood.SetActive(!_isBurned);

            ashes.SetActive(_isBurned);
            box.SetActive(_isBurned);
        }

        public void DeploayMent()
        {
            BurnFirewood(false);
            fire.SetActive(false);

            firewoodPlace.gameObject.SetActive(true);
            match.gameObject.SetActive(false);

            firewoodManager.ShowInit();
            state = MissionState.Deployment;
        }

        public void MakeFire()
        {
            firewoodPlace.gameObject.SetActive(false);    
            match.gameObject.SetActive(true);

            OVSoundRoot.Instance.Mission.ID56FiringWood.Play();
            state = MissionState.MakeFire;            
        }

        public void ReadyToFire()
        {
            state = MissionState.Firing;

            foreach (var firewood in fireWoods)
                firewood.SetActive(false);

            firewoodManager.HideFirewood();
            match.gameObject.SetActive(false);

            StartCoroutine(FiringCo());
        }
        
        private IEnumerator FiringCo()
        {
            fire.SetActive(true);
            OVSoundRoot.Instance.Mission.ID56Firing.Play();

            yield return new WaitForSeconds(waitTime);

            state = MissionState.Picking;

            BurnFirewood(true);
            fire.SetActive(false);
        }

        public void PickBox()
        {
            if (state != MissionState.Picking) return;

            box.SetActive(false);

            state = MissionState.Clear;
            MissionClear();

            Debug.Log("Clear");
        }
    }
}