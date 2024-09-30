using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CakeCutting
{
    public class SlidePoint : MonoBehaviour
    {
        private RectTransform rectTransform;
        private bool isTurn;
        private bool canCutting;

        private CutLine cutLine;
        public float turnSpeed { get; set; }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            rectTransform.rotation = Quaternion.identity;
            cutLine = null;
            isTurn = false;
        }
        private void Update()
        {
            if (isTurn)
            {
                transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
            }
        }
        public void SetTurn(bool _isTurn) => isTurn = _isTurn;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CutLine _cutLine = collision.GetComponent<CutLine>();

            if (_cutLine != null)
            {                
                if (!_cutLine.IsCutted)
                {
                    Debug.Log("컷 할 준비에요");
                    cutLine = _cutLine;
                    canCutting = true;
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            ResetCutLine();
        }
        public void ResetCutLine()
        {
            canCutting = false;
        }
        public void CheckCutLine()
        {
            if(canCutting)
            {
                cutLine.SetCutLine();
            }
            else
            {
                if(cutLine != null)
                {
                    cutLine.SliceLine.ResetCutLines();
                    cutLine = null;
                }
                transform.rotation = Quaternion.identity;
            }
        }
    }
}