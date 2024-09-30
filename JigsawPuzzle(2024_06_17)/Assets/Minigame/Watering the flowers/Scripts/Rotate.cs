using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Newtonsoft.Json.Bson;

namespace Missons.Village
{
    public class Rotate : MonoBehaviour, IDragHandler
    {
        [SerializeField] float rotateSpeed;
        [SerializeField] bool isCanMove = true;

        [SerializeField] bool needToRotate;
        public bool IsCanMove => isCanMove;
        private void Start()
        {
            if (needToRotate)
            {
                float RndZ = Random.Range(0, 360f);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, RndZ));
                isCanMove = true;
            }
            else
            {
                isCanMove = false;
            }

        }
        public void OnDrag(PointerEventData eventData)
        {
            if (isCanMove)
            {
                float z = eventData.delta.x * Time.deltaTime * -rotateSpeed;
                transform.Rotate(0, 0, z, Space.World);

                Debug.Log("Is Drag");
            }            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MiniGameObject"))
            {
                isCanMove = false;
            }
        }
    }
}