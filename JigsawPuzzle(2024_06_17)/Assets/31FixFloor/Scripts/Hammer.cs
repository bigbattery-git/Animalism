using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.FixFloor
{
    public class Hammer : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        public FixFloorManager Manager { get; set; }

        private RectTransform rectTransform;
        private Image image;

        [SerializeField] private Sprite hammer;
        [SerializeField] private Sprite hammerPress;

        private bool isClick;

        [SerializeField] private bool isReverse;

        private bool canActive;
        private Collider2D collision;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            StopAllCoroutines();
            collision = null;
            isClick = false;
            image.sprite = hammer;
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        private void Update()
        {
            OVMissionUtility.ObjectMoveFromMouse(rectTransform, canvas);
            if (canActive)
            {
                if(Input.GetMouseButtonDown(0) && !isClick)
                {                    
                    StartCoroutine(HandleMouseClick(collision));
                    if (isReverse)
                    {
                        collision.gameObject.SetActive(false);                        
                    }
                }
            }
        }

        private IEnumerator HandleMouseClick(Collider2D collision)
        {
            isClick = true;
            image.sprite = hammerPress;

            if (!isReverse)
            {
                collision.GetComponent<Nail>().Nailing();
                OVSoundRoot.Instance.Mission.ID32Hammering.Play();
            }
            else
            {
                OVSoundRoot.Instance.Mission.ID32PullingOutNail.Play();
            }
                yield return new WaitForSeconds(Manager.HammeringTime);
           
            isClick = false;
            image.sprite = hammer;

            if (isReverse) collision.GetComponentInParent<BrokenBoard>().CheckNailClear();
            if (!isReverse) Manager.MissionClear();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            canActive = true;
            this.collision = collision;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            canActive = false;
        }
    }
}