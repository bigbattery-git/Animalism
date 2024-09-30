using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.ConnectingPipe
{
    public class ConnectingPipesManager : OVMissionOrigin
    {
        [SerializeField] private PipeManager[] pipeManagers;

        public override void Awake()
        {
            base.Awake();
            foreach (var manager in pipeManagers)
                manager.Manager = this;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            int rnd = Random.Range(0, pipeManagers.Length);

            foreach (var manager in pipeManagers)
                manager.gameObject.SetActive(false);

            pipeManagers[rnd].gameObject.SetActive(true);
        }
    }
}