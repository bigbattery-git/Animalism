using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MatchCarpet
{
    public class MatchCarpetManager : OVMissionOrigin
    {
        [SerializeField] private PuzzleManager[] managers;

        public override void Awake()
        {
            base.Awake();

            foreach (var manager in managers)
            {
                manager.origin = this;
            }
        }

        [ContextMenu ("Override Show")]
        public override void Show()
        {
            base.Show();

            int num = Random.Range(0, managers.Length);

            foreach (var manager in managers)
                manager.gameObject.SetActive(false);

            managers[num].gameObject.SetActive(true);
        }
    }
}

