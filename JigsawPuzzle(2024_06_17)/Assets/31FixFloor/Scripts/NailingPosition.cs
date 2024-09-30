using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.FixFloor
{
    public class NailingPosition : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Nail nail;

        public FixFloorManager Manager { get; set; }

        public bool isReadyToNailing { get; private set; }

        public bool IsNailed { get { return nail.IsNailing; } }

        private void OnEnable()
        {
            nail.gameObject.SetActive(false);
            isReadyToNailing = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Manager.MissionState != MissionState.PutonNail) return;

            nail.gameObject.SetActive(true);
            

            if (!isReadyToNailing)
            {
                OVSoundRoot.Instance.Mission.ID32PuttingNail.Play();
                isReadyToNailing = true;
            }

            if (Manager.IsReadyToNailing())
            {
                Manager.Nailing();
            }
        }
    }
}