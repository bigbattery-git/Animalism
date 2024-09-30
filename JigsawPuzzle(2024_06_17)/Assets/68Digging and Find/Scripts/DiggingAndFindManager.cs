using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.DiggingAndFinding
{
    public class DiggingAndFindManager : OVMissionOrigin
    {        
        public bool IsClear { get; private set; }

        [Header("===========================================")]
        [SerializeField] private Transform blocksTransform;
        [SerializeField] private Sprite[] blockSprites;
        [SerializeField] private GameObject jewelObject;

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();

            IsClear = false;

            Block[] blocks = blocksTransform.GetComponentsInChildren<Block>(true);

            foreach (Block block in blocks)
            {
                block.gameObject.SetActive(true);
                block.Init(blockSprites[Random.Range(0, blockSprites.Length)], this);
            }

            jewelObject.SetActive(true);

            jewelObject.GetComponent<RectTransform>().anchoredPosition =
                blocks[Random.Range(0, blocks.Length)].GetComponent<RectTransform>().anchoredPosition;

            Cursor.visible = false;
        }

        public override void Hide()
        {
            base.Hide();

            Cursor.visible = true;
        }
        public override void MissionClear()
        {
            base.MissionClear();

            IsClear = true;
        }
    }
}