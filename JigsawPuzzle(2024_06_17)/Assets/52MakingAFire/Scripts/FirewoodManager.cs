using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MakeAFire
{
    public class FirewoodManager : MonoBehaviour
    {
        private MakingAFireManager manager;

        [SerializeField] private FirewoodObject[] firewoodObjects;
        [SerializeField] private RectTransform firewoodRect;

        [SerializeField] private RectTransform spawnFirewoodPoint;
         
        [SerializeField] private float firewoodDistance = 50f;
        public Vector2 FirewoodRect
        {
            get { return firewoodRect.anchoredPosition; }
        }
        public float FirewoodDistance => firewoodDistance;
        public void AwakeInit(MakingAFireManager _manager, RectTransform _layerTransform, Canvas _canvas)
        {
            manager = _manager;

            foreach (var firewood in firewoodObjects)
                firewood.Init(this, _layerTransform, _canvas);
        }

        public void ShowInit()
        {
            foreach(var firewood in firewoodObjects)
            {
                SetRandomSpawnFirewood(firewood.GetComponent<RectTransform>());
                firewood.IsReadyToNext = false;
                firewood.gameObject.SetActive(true);
            }
        }

        public void HideFirewood()
        {
            foreach (var firewood in firewoodObjects)
                firewood.gameObject.SetActive(false);
        }
        private void SetRandomSpawnFirewood(RectTransform _rectTransform)
        {
            float spawnRangeX = spawnFirewoodPoint.sizeDelta.x / 2;
            float spawnRangeY = spawnFirewoodPoint.sizeDelta.y / 2;

            float rndSpawnPointx = Random.Range(-spawnRangeX, spawnRangeX);
            float rndSpawnPointy = Random.Range(-spawnRangeY, spawnRangeY);

            _rectTransform.anchoredPosition = spawnFirewoodPoint.anchoredPosition + new Vector2(rndSpawnPointx, rndSpawnPointy);
        }

        public void CheckClear()
        {
            foreach (var firewood in firewoodObjects)
                if (!firewood.IsReadyToNext) return;

            manager.MakeFire();
        }
    }
}