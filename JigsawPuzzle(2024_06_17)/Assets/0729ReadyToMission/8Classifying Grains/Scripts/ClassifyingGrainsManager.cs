using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ClassifyingGrains
{
    public class ClassifyingGrainsManager : OVMissionOrigin
    {
        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            OVSoundRoot.Instance.Mission.ID8SprayingBeans.Play();
        }
    }
}