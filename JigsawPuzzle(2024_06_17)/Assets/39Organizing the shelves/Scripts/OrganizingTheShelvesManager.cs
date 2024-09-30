using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizingTheShelves
{
    public class OrganizingTheShelvesManager : OVMissionOrigin
    {
        [SerializeField] private MissionObjectManager missionObjectManager;
        [SerializeField] private ShelfObject shelfObject;
        [SerializeField] private GoalPoint goalPoint;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            SetRndPlace();
        }

        private void SetRndPlace()
        {
            List<int> rndList = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                rndList.Add(i);
            }

            for (int i = 0; i < 4; i++)
            {
                int rnd = Random.Range(0, rndList.Count);

                shelfObject.SetRndObject(i, rndList[rnd]);
                goalPoint.SetRndZone(i, rndList[rnd]);

                rndList.RemoveAt(rnd);
            }
        }
    }
}