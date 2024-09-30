using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClassifyingGrains
{
    public class GrainSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] grains;
        [SerializeField] int spawnGrainCount;

        [SerializeField] RectTransform trayRectTransform;
        [SerializeField] private OVMissionOrigin origin;
        [SerializeField] private Canvas canvas;
        private void OnEnable()
        {
            SpawnGrain(spawnGrainCount);
        }
        private void OnDisable()
        {
            for(int i = 0; i<transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        private void SpawnGrain(int _spawnGrainCount)
        {
            for(int i = 0; i< _spawnGrainCount; ++i)
            {
                int rnd = Random.Range(0, grains.Length);
                Grain obj = Instantiate(grains[rnd], this.transform).GetComponent<Grain>();

                obj.origin = this.origin;
                obj.canvas = this.canvas;

                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.anchorMax = new Vector2(0.5f, 0.5f);
                rect.anchorMin = new Vector2(0.5f, 0.5f);

                rect.anchoredPosition = SetStartPosition(trayRectTransform);                

                obj.transform.localScale = Vector3.one;
            }
        }
        private Vector2 SetStartPosition(RectTransform _trayRectTransform)
        {
            float width = _trayRectTransform.rect.width - 150;
            float height = _trayRectTransform.rect.height - 150;

            // float rndWidth = Random.Range(-width / 2, width / 2);
            // float rndHeight = Random.Range(-height / 2, height / 2);

            float rndWidth = Random.Range(-width/2, width/2);
            float rndHeight = Random.Range(-height/2, height/2);

            float targetX = _trayRectTransform.anchoredPosition.x + rndWidth;
            float targetY = _trayRectTransform.anchoredPosition.y + rndHeight;

            return new Vector2(targetX, targetY);
        }
    }
}