using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

namespace Missons.Village.HandingOverLostItems
{
    public class HandingOverLostItemsManager : OVMissionOrigin
    {
        [SerializeField] private LostObject[] lostObjects;

        [SerializeField] private Sprite[] lostObjectBate;
        [SerializeField] private Sprite lostObjectCorrect;

        [SerializeField] private RectTransform layerTransform;

        private Canvas canvas;

        private bool isCanMove = false;
        public bool IsCanMove => isCanMove;
        public override void Awake()
        {
            base.Awake();

            canvas = GetComponent<Canvas>();
        }

        [ContextMenu("Override Show")]
        public override void Show()
        {
            base.Show();
            Init();
            isCanMove = true;
        }
        private void Init()
        {
            List<int> fakeObjectSpriteNums = OVMissionUtility.GetRndNumNoOverrap(0, lostObjectBate.Length, 2).ToList();

            int correctObjectNum = Random.Range(0, 3);

            for(int i = 0; i<lostObjects.Length; i++)
            {
                if(i == correctObjectNum)
                {
                    lostObjects[i].Setup(this, canvas, layerTransform, true, lostObjectCorrect);
                }
                else
                {
                    lostObjects[i].Setup(this, canvas, layerTransform, false, lostObjectBate[fakeObjectSpriteNums[0]]);

                    fakeObjectSpriteNums.RemoveAt(0);
                }

                lostObjects[i].Init();
            }
        }

        public bool CheckMissionClear(bool _isCorrectObject)
        {
            if (_isCorrectObject)
            {
                isCanMove = false;
                MissionClear();

                return true;
            }

            return false;
        }
    }
}