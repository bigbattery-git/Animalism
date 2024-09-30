using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Missons.Village.TakeBottle
{
    public class NotePad : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void SetText(List<MedicationInfo> _info)
        {
            if(_info.Count == 2)
            {
                text.text = $"{_info[0].medicationName}\n{_info[1].medicationName}";
            }
            else if(_info.Count == 1)
            {
                text.text = $"{_info[0].medicationName}";
            }
            else if(_info.Count == 0)
            {
                text.text = null;
            }
        }
        public void OnClickWrongBottleText()
        {
            text.text = "Wrong\nBottle!!";
        }
    }
}