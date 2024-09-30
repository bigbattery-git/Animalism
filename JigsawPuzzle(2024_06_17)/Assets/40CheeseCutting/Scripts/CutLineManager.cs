using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CakeCutting
{
    public class CutLineManager : MonoBehaviour
    {
        [SerializeField] private CakeCuttingManager origin;
        [SerializeField] private SlidePoint point;
        [SerializeField] private Knife knife;

        private SliceLine[] sliceLines;
        [SerializeField] private Cake cake;
        private int sliceStage;

        private void Awake()
        {
            sliceLines = GetComponentsInChildren<SliceLine>(true);
        }

        private void OnEnable()
        {
            sliceStage = 0;
            GoNextCutLine();
        }
        public void GoNextCutLine()
        {           
            if(sliceStage == sliceLines.Length)
            {
                origin.MissionClear();
                knife.canTurn = false;
                return;
            }
            
            for (int i = 0; i< sliceLines.Length; i++)
            {
                if(i == sliceStage)
                {
                    sliceLines[i].gameObject.SetActive(true);
                }
                else
                {
                    sliceLines[i].gameObject.SetActive(false);
                }
            }
            cake.SetCakeSprite(sliceStage);
            point.turnSpeed = origin.TurnSpeeds[sliceStage];

            sliceStage++;
            point.transform.rotation = Quaternion.identity;            
        }
    }
}