using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.StainedGlassRotation
{
    public class LevelManager : MonoBehaviour
    {
        private Glass[] glasses;
        private float errorRange = 1f;

        [SerializeField] private MissionStaindglass manager;
        private void Awake()
        {
            glasses = new Glass[transform.childCount];

            glasses = GetComponentsInChildren<Glass>();
        }

        public void CheckClear()
        {
            foreach (var glass in glasses)
            {
                if (!glass.IsCorrectState) return;
            }

            foreach (var glass in glasses)
            {
                glass.HoldGlass();
            }

            StartCoroutine(MatchGlassesCoroutine());
        }

        private IEnumerator MatchGlassesCoroutine()
        {            
            int childCount = 0;
            while (true)
            {
                if (childCount == 3) break;

                float angle = MatchGlass(glasses[childCount]);

                if (angle < errorRange || 360 - angle < errorRange)
                {
                    glasses[childCount].transform.rotation = Quaternion.Euler(Vector3.zero);
                    childCount++;
                }

                yield return null;
            }

            manager.MissionClear();
        }

        private float MatchGlass(Glass glass)
        {
            float glassRotationZ = glass.transform.localEulerAngles.z;
            if(glassRotationZ - 180 > 0)
            {
                glass.transform.rotation = Quaternion.Euler(0,0, glassRotationZ + Time.deltaTime*15f);
            }
            else if(glassRotationZ - 180 < 0)
            {
                glass.transform.rotation = Quaternion.Euler(0, 0, glassRotationZ - Time.deltaTime*15f);
            }
            else
            {
                return 0;
            }

            return glass.transform.localEulerAngles.z;
        }
    }
}