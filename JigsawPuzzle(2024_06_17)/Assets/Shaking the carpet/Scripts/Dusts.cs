using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ShakingTheCarpet
{
    public class Dusts : MonoBehaviour
    {
        List<GameObject> dust = new List<GameObject>();
        int beforeActivedGameobject = -1;
        private void Start()
        {
            Init();
        }
        private void Init()
        {
            AddDustAtList();
        }
        private void AddDustAtList()
        {
            for(int i = 0; i<transform.childCount; ++i)
            {
                dust.Add(transform.GetChild(i).gameObject);
            }
        }
        public void ActiveDust()
        {
            List<int> rnd = new List<int>();
            for(int i = 0; i<transform.childCount; ++i)
            {
                if (i == beforeActivedGameobject) continue;
                rnd.Add(i);
            }

            int rndNum = rnd[Random.Range(0, rnd.Count)];
            dust[rndNum].SetActive(true);

            beforeActivedGameobject = rndNum;
        }
    }
}