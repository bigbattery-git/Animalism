using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.WindowCleaning
{
    public class WindowCleaningManager : OVMissionOrigin
    {
        public bool isClear = false;
        public static WindowCleaningManager instance;
        public AudioSource audioSource;

        public override void Awake()
        {
            instance = this;
            base.Awake();
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            isClear = false;
        }
        public override void MissionClear()
        {
            base.MissionClear();
            GetComponentInChildren<WindowCleaningManager>().isClear = true;
        }
    }
}