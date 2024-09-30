using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Missons.Village.ConnectingPipe
{
    public class PipeManager : MonoBehaviour
    {
        private Pipe[] pipes;
        private List<Pipe> currentPipes = new List<Pipe>();
        public ConnectingPipesManager Manager { get; set; }
        public bool IsClear { get; private set; }
        private void Awake()
        {
            pipes = GetComponentsInChildren<Pipe>();

            GetCorrectPipe();
            foreach(var p in pipes)
            {
                p.PipeManager = this;
            }
        }
        private void OnEnable()
        {
            IsClear = false;
        }
        private void GetCorrectPipe()
        {
            var pipe = from p in pipes
                       where p.IsCorrectPipe == true
                       select p;

            foreach(var p in pipe)
                currentPipes.Add(p);
        }

        public void CheckClear()
        {
            foreach(var pipe in currentPipes)
            {
                if (pipe.PipeStateIndex != 0) return;
            }

            Manager.MissionClear();
            IsClear = true;
        }
    }
}