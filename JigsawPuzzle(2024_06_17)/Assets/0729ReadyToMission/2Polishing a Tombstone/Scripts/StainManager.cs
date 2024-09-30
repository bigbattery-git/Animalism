using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.PolishingATombstone
{
    public class StainManager : MonoBehaviour
    {
        [Range(0, 7)]
        [SerializeField] private int activeStainCount;

        [SerializeField] private PolishingATombstoneManager manager;
        private GameObject[] stains;
        private void Awake()
        {
            stains = new GameObject[transform.childCount];

            for(int i = 0; i < stains.Length; i++)
            {
                stains[i] = transform.GetChild(i).gameObject;
            }
        }
        private void OnEnable()
        {
            foreach(GameObject sta in stains)
            {
                sta.SetActive(false);
            }

            SetActiveChildRandom(activeStainCount);
        }
        private void SetActiveChildRandom(int _activeStainCount)
        {
            List<GameObject> stain = new List<GameObject>();
            for (int i = 0; i < transform.childCount; ++i)
            {
                GameObject obj = transform.GetChild(i).gameObject;
                stain.Add(obj);
            }
            for (int i = 0; i < _activeStainCount; ++i)
            {
                int rnd = Random.Range(0, stain.Count);
                stain[rnd].gameObject.SetActive(true);
                stain.RemoveAt(rnd);
            }
        }
        public void CheckClear()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeInHierarchy)
                    return;
            }
            manager.MissionClear();
        }
    }
}