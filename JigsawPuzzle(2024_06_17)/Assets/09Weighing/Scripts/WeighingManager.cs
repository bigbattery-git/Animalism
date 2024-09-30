using Missons.Village.TakeBottle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.weighing
{
    public class WeighingManager : OVMissionOrigin
    {

        [Header("==========================")]
        [SerializeField] private GDish gDish;
        [SerializeField] private SackSO sackData;

        [SerializeField] private Image sackImage;
        [SerializeField] private int sackWeigh = 10;

        [Header("Dish Place")]
        [SerializeField] private RectTransform horizontalStand;
        [SerializeField] private RectTransform sackDishPlace;
        [SerializeField] private RectTransform gDishPlace;
        [SerializeField] private RectTransform sackDish;
        [SerializeField] private RectTransform gDish_;
        [SerializeField] private RectTransform arrow;
        [SerializeField] private float angle;
        public bool IsClear { get; private set; }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            IsClear = false;

            SetSack();
            gDish.ResetTotalWeigh();
            SetHorizontalStand();

            OVSoundRoot.Instance.Mission.ID9StartingWeigh.Play();
        }
        private void SetSack()
        {
            int rnd = Random.Range(0, sackData.sackDatas.Length);

            var rndData = sackData.sackDatas[rnd];
            sackImage.sprite = rndData.sackSprite;
            sackWeigh = Random.Range( rndData.minWeigh, rndData.maxWeigh );
        }
        public void CheckClear()
        {
            if (gDish.TotalWeigh != sackWeigh) return;

            IsClear = true;
            MissionClear();
        }
        public void SetHorizontalStand()
        {
            /*
            if (gDish.TotalWeigh > sackWeigh)
            {
                horizontalStand.rotation = Quaternion.Euler(new Vector3(0, 0, -10f));
            }
            else if (gDish.TotalWeigh < sackWeigh)
            {
                horizontalStand.rotation = Quaternion.Euler(new Vector3(0, 0, 10f));
            }
            else
            {
                horizontalStand.rotation = Quaternion.identity;
            }
            */

            float z = Mathf.Clamp((sackWeigh - gDish.TotalWeigh) * angle, -15f, 15f);

            horizontalStand.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            sackDish.position = sackDishPlace.position;
            gDish_.position = gDishPlace.position;

            SetArrowAngle(z);

            if(!IsClear)
            OVSoundRoot.Instance.Mission.PlayRndSound(new AudioSource[] { OVSoundRoot.Instance.Mission.ID9Weighing1, OVSoundRoot.Instance.Mission.ID9Weighing2 });
        }

        private void SetArrowAngle(float _angle)
        {
            if(_angle > 0)
            {
                 arrow.transform.rotation = Quaternion.Euler(new Vector3(0,0,-90f));
            }
            else if(_angle < 0)
            {
                 arrow.transform.rotation = Quaternion.Euler(new Vector3(0,0,90f));
            }
            else
            {
                arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180f));
            }
        }
    }
}