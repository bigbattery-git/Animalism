using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.WipeDownTheVanity
{
    public class StainManager : MonoBehaviour
    {
        [SerializeField] private Stain[] stains;
        [SerializeField] private WipeDownTheVanityManager manager;
        private void OnEnable()
        {
            foreach(var st in stains)
            {
                st.SetDefaultStain();
                st.gameObject.SetActive(true);                
            }
        }

        public void CheckClear()
        {
            foreach(var st in stains)
            {
                if (st.gameObject.activeInHierarchy)
                    return;
            }

            manager.MissionClear();
        }
    }
}