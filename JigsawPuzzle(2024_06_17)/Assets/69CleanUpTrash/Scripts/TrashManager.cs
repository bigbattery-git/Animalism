using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missons.Village.CleanUpTrash
{
    public class TrashManager : MonoBehaviour
    {
        [SerializeField] private Trash[] trashes;
        [SerializeField] private RectTransform layerTransform;
        [SerializeField] private Canvas canvas;

        [SerializeField] private OVMissionOrigin origin;

        [SerializeField] private GasPool gaspool;
        private void Awake()
        {
            foreach (var trash in trashes)
            {
                trash.canvas = canvas;
                trash.layerRectTransform = layerTransform;
                trash.manager = this;
            }
        }

        private void OnEnable()
        {
            foreach(var trash in trashes)
            {
                trash.gameObject.SetActive(true);
            }
        }

        public void CheckClear()
        {
            for(int i = 0; i< trashes.Length; i++)
            {
                if (trashes[i].gameObject.activeInHierarchy) return;
            }

            origin.MissionClear();
        }

        public void OnDisableTrash(Vector2 _vec)
        {
            gaspool.GetGasEffect(_vec);
        }
    }
}