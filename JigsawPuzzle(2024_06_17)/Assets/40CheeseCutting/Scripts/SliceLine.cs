using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CakeCutting
{
    public class SliceLine : MonoBehaviour
    {
        private CutLine[] cutLines;

        [SerializeField] private CutLineManager cutLineManager;
        private void Awake()
        {
            cutLines = GetComponentsInChildren<CutLine>();
        }
        private void OnEnable()
        {
            ResetCutLines();
        }
        public void ResetCutLines()
        {
            foreach (CutLine cut in cutLines)
                cut.ResetCutLine();
        }
        public void CheckClear()
        {
            foreach(CutLine cut in cutLines)
            {
                if (!cut.IsCutted)
                    return;
            }

            cutLineManager.GoNextCutLine();
        }
    }
}