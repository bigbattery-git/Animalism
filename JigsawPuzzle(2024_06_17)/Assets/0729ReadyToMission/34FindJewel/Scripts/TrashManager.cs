using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.FindJewel
{
    public class TrashManager : MonoBehaviour
    {
        public bool IsClear => manager.isClear;
        public FindJewelManager manager;
    }
}