using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.DiggingAndFinding
{
    public class Jewel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private DiggingAndFindManager manager;
 
        public void OnPointerClick(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID79MovingTrash.Play();

            manager.MissionClear();

            gameObject.SetActive(false);
        }
    }
}