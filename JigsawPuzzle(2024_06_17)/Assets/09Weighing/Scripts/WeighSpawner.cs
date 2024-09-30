using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.weighing
{
    public class WeighSpawner : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Transform spawnTransform;
        [SerializeField] private GameObject weigh;

        [SerializeField] private Canvas canvas;

        [SerializeField] private WeighingManager manager;

        [SerializeField] private Transform setupTransform;
        [SerializeField] private Transform gDishTransform;

        [SerializeField] private RectTransform layerTransform;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (manager.IsClear) return;

            var obj = Instantiate(weigh, spawnTransform);
            var rect = obj.GetComponent<RectTransform>();
            var we = obj.GetComponent<Weigh>();

            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(0, 0);

            we.canvas = this.canvas;
            we.Manager = this.manager;
            we.SetupTransform = this.setupTransform;
            we.GDishTransform = this.gDishTransform;
            we.layerTransform = this.layerTransform;

            var mousepos = new Vector3(eventData.position.x, eventData.position.y, 0);

            if(canvas.renderMode == RenderMode.ScreenSpaceOverlay)
                rect.position = mousepos;
            else if(canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                Camera cam = canvas.worldCamera;
                rect.position = cam.ScreenToWorldPoint(mousepos);
            }
                
        }
    }
}