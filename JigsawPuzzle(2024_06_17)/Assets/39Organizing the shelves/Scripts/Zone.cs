using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.OrganizingTheShelves
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private int zoneID;
        [SerializeField] private bool isInPlace;
        public int ZoneID => zoneID;
        public bool IsInPlace { get { return isInPlace; } set { isInPlace = value; } }
    }
}