using Missons.Village.PutOutFire;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutOutFire
{
    public class PutOutFireFactoryManager : OVMissionOrigin
    {
        [SerializeField] private float bigFireOffTime;
        [SerializeField] private float smallFireOffTime;

        [SerializeField] private FireFactory[] fires;
        private RectTransform[] fireTransforms;

        public float BigFireOffTime => bigFireOffTime;
        public float SmallFireOffTime => smallFireOffTime;
        public float TotalFireOffTime { get { return bigFireOffTime + smallFireOffTime; } }

        public override void Awake()
        {
            base.Awake();

            fireTransforms = new RectTransform[fires.Length];

            for (int i = 0; i < fires.Length; i++)
            {
                fireTransforms[i] = fires[i].GetComponent<RectTransform>();
            }
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            SpawnFire();

            Cursor.visible = false;
        }

        public override void Hide()
        {
            base.Hide();

            Cursor.visible = true;
        }

        private void SpawnFire()
        {
            int[] rndSpawnType = GetRndSpawnTypes();

            for (int i = 0; i < rndSpawnType.Length; i++)
            {
                fires[i].ResetObject();
                fireTransforms[i].anchoredPosition = GetRndSpawnPoint(Random.Range(0, 2));
                fires[i].gameObject.SetActive(true);
            }
        }

        private Vector2 GetRndSpawnPoint(int _num)
        {
            float minSpawnx = 0f;
            float maxSpawnx = 0f;
            float minSpawnY = 0f;
            float maxSpawnY = 0f;

            switch (_num)
            {
                case 0:
                    minSpawnx = 619f;
                    maxSpawnx = 1000f;
                    minSpawnY = 279f;
                    maxSpawnY = 625f;
                    break;
                case 1:
                    minSpawnx = 222f;
                    maxSpawnx = 540f;
                    minSpawnY = 535f;
                    maxSpawnY = 635f;
                    break;
                default:
                    minSpawnx = 619f;
                    maxSpawnx = 1000f;
                    minSpawnY = 279f;
                    maxSpawnY = 625f;
                    break;
            }

            float rndX = Random.Range(minSpawnx, maxSpawnx);
            float rndY = Random.Range(minSpawnY, maxSpawnY);

            return new Vector2(rndX, rndY);
        }
        private int[] GetRndSpawnTypes()
        {
            List<int> rndListNums = new List<int>() { 0, 1, 2, 3 };
            int[] returnRndNums = new int[3];
            for (int i = 0; i < returnRndNums.Length; i++)
            {
                int rndElement = Random.Range(0, rndListNums.Count);

                returnRndNums[i] = rndListNums[rndElement];

                rndListNums.RemoveAt(rndElement);
            }

            return returnRndNums;
        }

        public void CheckClear()
        {
            foreach (var fire in fires)
            {
                if (!fire.IsClear)
                    return;
            }

            MissionClear();
        }
    }
}