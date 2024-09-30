using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.LigthACandle
{
    public class LightACandleManager : OVMissionOrigin
    {
        public float WaitBurningTime => waitBurningTime;

        [SerializeField] private float waitBurningTime;

        [SerializeField] private CandlePoint[] points;

        public override void Awake()
        {
            base.Awake();

            foreach(var point in points)
            {
                point.manager = this;
            }
        }

        [ContextMenu("OverrideShow")]
        public override void Show()
        {
            base.Show();
            // OVSoundRoot.Instance.Mission.ID10StartingBurning.Play();
            Cursor.visible = false;
        }

        public override void Hide()
        {
            base.Hide();
            Cursor.visible = true;
        }

        public void CheckClear()
        {
            for(int i = 0; i< points.Length; i++)
            {
                if (!points[i].isBurning) return;
            }

            MissionClear();
        }
    }
}