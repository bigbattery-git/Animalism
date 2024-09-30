using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutOutFire
{
    public enum FireSpawnType { LeftDown, LeftUp, RightDown, RightUp }
    public class PutOutFireManager : OVMissionOrigin
    {
        [SerializeField] private float bigFireOffTime;
        [SerializeField] private float smallFireOffTime;

        [SerializeField] private Fire[] fires;
                         private RectTransform[] fireTransforms;

        public float BigFireOffTime => bigFireOffTime;
        public float SmallFireOffTime => smallFireOffTime;
        public float TotalFireOffTime { get { return bigFireOffTime + smallFireOffTime; } }

        public override void Awake()
        {
            base.Awake();

            fireTransforms = new RectTransform[fires.Length];

            for(int i = 0; i < fires.Length; i++)
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

            for(int i = 0; i< rndSpawnType.Length; i++)
            {
                fires[i].ResetObject();
                fireTransforms[i].anchoredPosition = GetRndSpawnPoint((FireSpawnType)rndSpawnType[i]);
                fires[i].gameObject.SetActive(true);
            }
        }

        private Vector2 GetRndSpawnPoint(FireSpawnType _spawnType)
        {
            float minSpawnx = 0f;
            float maxSpawnx = 0f;
            float minSpawnY = 0f;
            float maxSpawnY = 0f;

            switch (_spawnType)
            {
                case FireSpawnType.LeftDown:
                    minSpawnx = 133f;
                    maxSpawnx = 497f;
                    minSpawnY = 232f;
                    maxSpawnY = 332f;
                    break;
                case FireSpawnType.LeftUp:
                    minSpawnx = 133f;
                    maxSpawnx = 497f;
                    minSpawnY = 637f;
                    maxSpawnY = 537f;
                    break;
                case FireSpawnType.RightDown:
                    minSpawnx = 732f;
                    maxSpawnx = 1099f;
                    minSpawnY = 232f;
                    maxSpawnY = 332f;
                    break;
                case FireSpawnType.RightUp:
                    minSpawnx = 732f;
                    maxSpawnx = 1099f;
                    minSpawnY = 637f;
                    maxSpawnY = 537f;
                    break; ;
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