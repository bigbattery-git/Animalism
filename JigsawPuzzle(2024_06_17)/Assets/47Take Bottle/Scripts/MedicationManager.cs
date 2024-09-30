using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.TakeBottle
{
    public class MedicationManager : MonoBehaviour
    {
        [SerializeField] private TakeBottleManager manager;

        [Header("-----------------------------------------------")]
        [SerializeField] private Button arrowLeft;
        [SerializeField] private Button arrowRight;

        [SerializeField] private GameObject[] medicationGroup;

        [SerializeField] private Medication[] medications;
        private int activeMedicationID = 0;

        private List<MedicationInfo> medicationInfos;
        private const int CorrectMedicationCount = 2;

        [SerializeField] private NotePad notePad;

        private bool canClick = true;
        private Coroutine onClickWorngButton;
        private void Awake()
        {
            arrowLeft.onClick.AddListener(() => ActiveMedication(true));
            arrowRight.onClick.AddListener(() => ActiveMedication(false));

            Medication.OnClickMedication += OnClickMedication;
        }

        private void OnEnable()
        {
            canClick = true;

            ResetMedication();
            SetCorrectMedications();            
        }
        private void OnDisable()
        {
            if(onClickWorngButton != null)
                StopCoroutine(onClickWorngButton);
        }
        private void ActiveMedication(bool _isLeft)
        {
            if (!canClick) return;

            switch (_isLeft)
            {
                case true:
                    activeMedicationID--;
                    if(activeMedicationID < 0)
                    {
                        activeMedicationID = medicationGroup.Length - 1;
                    }
                    break;
                case false:
                    activeMedicationID++;
                    if(activeMedicationID >= medicationGroup.Length)
                    {
                        activeMedicationID = 0;
                    }
                    break;
            }

            for(int i = 0; i< medicationGroup.Length; i++)
            {
                if(i == activeMedicationID)
                {
                    medicationGroup[i].SetActive(true);                    
                }
                else
                {
                    medicationGroup[i].SetActive(false);
                }
            }
        }
        public void ResetMedication()
        {
            activeMedicationID = medicationGroup.Length;
            ActiveMedication(false);
        }

        private void OnClickMedication(MedicationInfo _info)
        {
            if (!canClick) return;

            if (IsCorrectMedication(_info))
            {
                OVSoundRoot.Instance.Mission.ID51TakingBottle.Play();

                if (medicationInfos.Count == 0)
                {
                    canClick = false;
                    manager.MissionClear();
                }
            }

            else
            {
                onClickWorngButton = StartCoroutine(OnClickWorngBottle());
            }
        }
        private bool IsCorrectMedication(MedicationInfo _info)
        {
            for (int i = 0; i < medicationInfos.Count; i++)
            {
                if (_info.medicationID == medicationInfos[i].medicationID)
                {
                    medications[medicationInfos[i].medicationID].gameObject.SetActive(false);

                    medicationInfos.RemoveAt(i);

                    notePad.SetText(medicationInfos);

                    return true;
                }
            }
            return false;
        }
        private void SetCorrectMedications()
        {
            medicationInfos = new List<MedicationInfo>();

            List<int> rndID = new List<int>();
            
            for(int i = 0; i<medications.Length; i++)
            {
                rndID.Add(i);
            }

            for(int i = 0; i<CorrectMedicationCount; i++)
            {
                int a = Random.Range(0, rndID.Count);

                medicationInfos.Add(medications[rndID[a]].medicationInfo);
                rndID.RemoveAt(a);
            }

            notePad.SetText(medicationInfos);

            foreach(var med in medications)
                med.gameObject.SetActive(true);
        }

        private IEnumerator OnClickWorngBottle()
        {
            notePad.OnClickWrongBottleText();
            canClick = false;


            yield return new WaitForSeconds(3f);

            SetCorrectMedications();
            canClick = true;
        }
    }
}