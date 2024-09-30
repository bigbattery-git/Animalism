using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.PutCoals
{
    public class CoalSpawner : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private PutCoalsManager manager;

        [SerializeField] private GameObject coal;
        [SerializeField] private Canvas canvas;

        private RectTransform rectTransform;

        
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (manager.canSpawnCoal)
            {
                Coal obj = Instantiate(coal, this.rectTransform.position, Quaternion.identity).GetComponent<Coal>();
                obj.canvas = this.canvas;
                obj.transform.SetParent(this.transform);                
                obj.transform.localScale = Vector3.one;

                OVSoundRoot.Instance.Mission.ID29PuttingCoal.Play();
            }
        }
    }
}
