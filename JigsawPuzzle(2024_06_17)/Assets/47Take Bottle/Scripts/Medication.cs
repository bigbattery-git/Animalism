using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.TakeBottle
{
    [System.Serializable]
    public struct MedicationInfo
    {
        public int medicationID;
        public string medicationName;
    }
    public class Medication : MonoBehaviour, IPointerClickHandler
    {
        public static Action<MedicationInfo> OnClickMedication;
        public MedicationInfo medicationInfo;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (OnClickMedication != null) OnClickMedication.Invoke(medicationInfo);
        }
    }
}