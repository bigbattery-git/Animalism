using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Missons.Village.ConnectingPipe
{
    public enum PipeState { Line, Bent, Cross}
    public class Pipe : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private PipeState state;        
        [SerializeField] private bool isCorrectPipe;

        public PipeManager PipeManager { get; set; }
        public int PipeStateIndex { get; private set; } = 0;
        public bool IsCorrectPipe => isCorrectPipe;
        private void OnEnable()
        {
            int rnd = Random.Range(0, 10);

            for (int i = 0; i < rnd; i++)
            {
                switch (state)
                {
                    case PipeState.Line:
                        LineState();
                        break;
                    case PipeState.Bent:
                        BentState();
                        break;
                    case PipeState.Cross:
                        break;
                }
            }
        }

        private void LineState()
        {            
            PipeStateIndex++;

            if (PipeStateIndex >= 2)
                PipeStateIndex = 0;

            float currentRotationZ = transform.rotation.eulerAngles.z;
            // transform.rotation = Quaternion.AngleAxis(currentRotationZ + 90, Vector3.forward);
            transform.rotation = Quaternion.Euler(0, 0, currentRotationZ + 90f);
        }
        private void BentState()
        {
            PipeStateIndex++;

            if (PipeStateIndex >= 4)
                PipeStateIndex = 0;

            float currentRotationZ = transform.rotation.eulerAngles.z;
            // transform.rotation = Quaternion.AngleAxis(currentRotationZ + 90, Vector3.forward);
            transform.rotation = Quaternion.Euler(0, 0, currentRotationZ + 90f);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (PipeManager.IsClear) return;

            switch (state)
            {
                case PipeState.Line:
                    LineState();
                    break;

                case PipeState.Bent:
                    BentState();
                    break;
            }

            if (isCorrectPipe && PipeStateIndex == 0)
                PipeManager.CheckClear();
        }
    }
}