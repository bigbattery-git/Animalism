using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.MakeBlueprint
{
    public class MakeBlueprintManager : OVMissionOrigin
    {
        [SerializeField] private PuzzleManager[] puzzleManagers;

        public override void Awake()
        {
            base.Awake();

            foreach (var manager in puzzleManagers)
                manager.origin = this;
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            Init();
        }

        private void Init()
        {
            int rndNum = Random.Range(0, puzzleManagers.Length);

            foreach (var manager in puzzleManagers)
                manager.gameObject.SetActive(false);

            puzzleManagers[rndNum].gameObject.SetActive(true);
        }
    }
}