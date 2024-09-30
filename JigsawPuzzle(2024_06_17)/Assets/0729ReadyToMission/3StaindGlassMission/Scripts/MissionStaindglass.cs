using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine;

namespace Missons.Village.StainedGlassRotation
{    
    public class MissionStaindglass : OVMissionOrigin
    {
        [SerializeField] private LevelManager[] levelManagers;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            foreach(var levelManager in levelManagers)
            {
                levelManager.gameObject.SetActive(false);
            }

            int rnd = UnityEngine.Random.Range(0, levelManagers.Length);
            for (int i = 0; i < levelManagers.Length; i++)
            {
                if (i == rnd)
                {
                    levelManagers[i].gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}