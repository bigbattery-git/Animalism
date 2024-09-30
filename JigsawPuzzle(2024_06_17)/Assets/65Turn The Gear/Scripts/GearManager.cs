using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.TurnTheGear
{
    public enum GearColor { Red, Blue, MaxSize, None}
    public class GearManager : MonoBehaviour
    {
        [Header("Gears")]
        [SerializeField] private GameObject gear0;
        [SerializeField] private GameObject gear1;
        [SerializeField] private GameObject gear2;

        [Header("Manager")]
        [SerializeField] private TurnTheGearManager manager;
        public GearColor GearColor0 { get; private set; }
        public GearColor GearColor1 { get; private set; }
        public GearColor GearColor2 { get; private set; }

        // 같은 기어인지 체크
        private bool isCorrectLeftGear;
        private bool isCorrectRightGear;

        // 회전중인지 판별
        private bool isTurning = false;
        private void Update()
        {
            isCorrectLeftGear = GearColor0 == manager.QuestionColor && GearColor0 == GearColor1;
            isCorrectRightGear = GearColor2 == manager.QuestionColor && GearColor1 == GearColor2;

            manager.TurnOnLittleLeftLamp(isCorrectLeftGear);
            manager.TurnOnLittleRightLamp(isCorrectRightGear);
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        public void Init()
        {
            SetRandomGearColor();
            isTurning = false;
        }
        private void SetRandomGearColor()
        {
            
            int[] gearRotations = new int[] {0, 45, 90, 135, 180, 225, 270, 315};

            TurnGearManually(gear0, gearRotations[Random.Range(0, gearRotations.Length)]);
            TurnGearManually(gear1, gearRotations[Random.Range(0, gearRotations.Length)]);
            TurnGearManually(gear2, gearRotations[Random.Range(0, gearRotations.Length)]);
            SetGearColor();

            if(manager.QuestionColor == GearColor0)
            {
                if (manager.QuestionColor == GearColor.Blue)               
                    TurnGearManually(gear0, gearRotations[1]);                
                else
                    TurnGearManually(gear0, gearRotations[0]);
            }
            if(manager.QuestionColor == GearColor2)
            {
                if (manager.QuestionColor == GearColor.Blue)
                    TurnGearManually(gear0, gearRotations[2]);
                else
                    TurnGearManually(gear2, gearRotations[0]);
            }

            SetGearColor();
        }

        private void TurnGearManually(GameObject _gear, int _gearRotations)
        {
            _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _gearRotations));
        }
        #region Gear0 Turn
        public void TurnGear0Left()
        {
            if (isTurning) return;

            if (manager.IsClear) return;

            TurnGearLeft(gear0);

            if(GearColor0 != GearColor.None)
            {
                if (GearColor0 != GearColor1)
                {
                    TurnGearRight(gear1);
                }
                else
                {
                    TurnGearLeft(gear1);
                }
            }

        }
        public void TurnGear0Right()
        {
            if (isTurning) return;

            if (manager.IsClear) return;

            TurnGearRight(gear0);

            if (GearColor0 != GearColor.None)
            {
                if (GearColor0 != GearColor1)
                {
                    TurnGearLeft(gear1);
                }
                else
                {
                    TurnGearRight(gear1);
                }
            }

        }
        #endregion
        #region Gear1 Turn
        public void TurnGear1Left()
        {
            if (manager.IsClear) return;

            TurnGearLeft(gear1);

            if (GearColor0 != GearColor1)
            {
                TurnGearRight(gear0);

                if (GearColor1 != GearColor2)
                {
                    TurnGearRight(gear2);
                }
            }
        }
        public void TurnGear1Right()
        {
            if (manager.IsClear) return;

            TurnGearRight(gear1);

            if (GearColor0 != GearColor1)
            {
                TurnGearLeft(gear0);

                if (GearColor1 != GearColor2)
                {
                    TurnGearLeft(gear2);
                }
            }
        }
        #endregion
        #region Gear2 Turn
        public void TurnGear2Left()
        {
            if (isTurning) return;

            if (manager.IsClear) return;

            TurnGearLeft(gear2);

            if (GearColor2 != GearColor.None)
            {
                if (GearColor2 != GearColor1)
                {
                    TurnGearRight(gear1);
                }
                else
                {
                    TurnGearLeft(gear1);
                }
            }

        }
        public void TurnGear2Right()
        {
            if (isTurning) return;

            if (manager.IsClear) return;

            TurnGearRight(gear2);

            if (GearColor2 != GearColor.None)
            {
                if (GearColor2 != GearColor1)
                {
                    TurnGearLeft(gear1);
                }
                else
                {
                    TurnGearRight(gear1);
                }
            }

        }
        #endregion
        private void TurnGearLeft(GameObject _gear)
        {
            /*
            float z = _gear.transform.rotation.eulerAngles.z;
            _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z + 45f));
            */

            StartCoroutine(TurnGearLeftCo(_gear));
            OVSoundRoot.Instance.Mission.ID74TurningGear.Play();
        }
        private void TurnGearRight(GameObject _gear)
        {
            /*
            float z = _gear.transform.rotation.eulerAngles.z;
            _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z - 45f));
            */
            StartCoroutine(TurnGearRightCo(_gear));
            OVSoundRoot.Instance.Mission.ID74TurningGear.Play();
        }

        private IEnumerator TurnGearLeftCo(GameObject _gear)
        {
            isTurning = true;

            float z = _gear.transform.rotation.eulerAngles.z;
            float turnTime = 0;

            while(turnTime < 1)
            {
                float currentZ = Mathf.Lerp(z, z + 45f, turnTime);
                turnTime += Time.deltaTime * 3f;

                _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentZ));

                yield return null;
            }

            _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z + 45f));

            isTurning = false;

            SetGearColor();

            manager.CheckClear();
        }

        private IEnumerator TurnGearRightCo(GameObject _gear)
        {
            isTurning = true;

            float z = _gear.transform.rotation.eulerAngles.z;
            float turnTime = 0;

            while (turnTime < 1)
            {
                float currentZ = Mathf.Lerp(z, z - 45f, turnTime);
                turnTime += Time.deltaTime * 3f;

                _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentZ));

                yield return null;
            }

            _gear.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z - 45f));

            isTurning = false;

            SetGearColor();

            manager.CheckClear();
        }
        private void SetGearColor()
        {
            float gear0z = gear0.transform.rotation.eulerAngles.z;
            float gear1z = gear1.transform.rotation.eulerAngles.z;
            float gear2z = gear2.transform.rotation.eulerAngles.z;

            if (Mathf.RoundToInt(gear0z) % 180 == 0)
            {
                GearColor0 = GearColor.Blue;
            }
            else if(Mathf.RoundToInt(gear0z) == 360-45 || Mathf.RoundToInt(gear0z) == 135)
            {
                GearColor0 = GearColor.None;
            }
            else
            {
                GearColor0 = GearColor.Red;
            }

            if (Mathf.RoundToInt(gear1z) % 90 == 0)
            {
                GearColor1 = GearColor.Blue;
            }
            else
            {
                GearColor1 = GearColor.Red;
            }

            if (Mathf.Abs(Mathf.RoundToInt(gear2z)) % 180 == 90 && Mathf.RoundToInt(gear2z) != 0)
            {
                GearColor2 = GearColor.Red;
            }
            else if (Mathf.RoundToInt(gear2z) == 45 || Mathf.RoundToInt(gear2z) == 180 + 45)
            {
                GearColor2 = GearColor.None;
            }
            else
            {
                GearColor2 = GearColor.Blue;
            }
        }
        private void Debugs()
        {
            Debug.Log("GearColor0 : " + GearColor0);
            Debug.Log("GearColor1 : " + GearColor1);
            Debug.Log("GearColor2 : " + GearColor2);
        }
    }
}