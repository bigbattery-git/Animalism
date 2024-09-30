using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.BreakCoal
{
    public class Coal : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject[] effects;
        [SerializeField] private GameObject brokenCoal;
        private int breakCount;

        [SerializeField] private BreakCoalManager manager;

        private void OnEnable()
        {
            DeactiveEffects();
            brokenCoal.SetActive(false);
        }
        public void DeactiveEffects()
        {
            breakCount = 0;
            foreach (var effect in effects)
            {
                if(effect.activeInHierarchy == true)
                    effect.SetActive(false);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OVSoundRoot.Instance.Mission.ID28BreakingCoal.Play();

            if (breakCount < effects.Length)
            effects[breakCount].SetActive(true);

            breakCount++;
            if (breakCount == effects.Length)
            {
                brokenCoal.SetActive(true);
                manager.MissionClear();

                this.gameObject.SetActive(false);
            }
        }
    }

}