using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizingTheKeys
{
    public class KeyManager : MonoBehaviour
    {
        [SerializeField] private OVMissionOrigin origin;
        private Key[] keys;

        private void Awake()
        {
            keys = GetComponentsInChildren<Key>();
        }

        public void CheckClear()
        {
            for(int i  = 0; i < keys.Length; i++)
            {
                if (!keys[i].IsInPosition)
                {
                    return;
                }
            }

            origin.MissionClear();
        }
    }
}