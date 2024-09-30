using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.StainedGlassRotation
{
    public class StaindglassManager : MonoBehaviour
    {
        private LevelManager[] levelManagers;

        private void Start()
        {
            levelManagers = GetComponentsInChildren<LevelManager> ();

            int rnd = Random.Range(0, levelManagers.Length);
            
            for(int i = 0; i< levelManagers.Length; i++)
            {
                if(i == rnd)
                {
                    levelManagers[i].gameObject.SetActive(true);
                }
                else
                {
                    levelManagers[i].gameObject.SetActive(false);
                }
            }
        }
    }
}