using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PutCoals
{
    public class PutCoalsManager : OVMissionOrigin
    {
        private int putCount;

        private const int clearCount = 3;      
        IEnumerator spawnCoal;

        public float waitTime { get; private set; } = 3;
        public bool canSpawnCoal { get; private set; } = true;

        public void SpawnCoal()
        {
            spawnCoal = SpawnCoalCo();

            if(gameObject.activeInHierarchy)
            StartCoroutine(spawnCoal);
        }

        IEnumerator SpawnCoalCo()
        {
            canSpawnCoal = false;

            yield return new WaitForSeconds(waitTime);

            canSpawnCoal = true;
        }

        public override void Show()
        {
            base.Show();

            putCount = 0;
            canSpawnCoal = true;

             OVSoundRoot.Instance.Mission.ID29Firing.Play();
        }
        private void OnDisable()
        {
            if (spawnCoal != null)
                StopCoroutine(spawnCoal);
        }
        public void CountUp()
        {
            putCount++;

            if (putCount >= clearCount)
            {
                MissionClear();
            }
        }
    }
}