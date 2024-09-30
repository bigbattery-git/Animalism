using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

namespace Missons.Village.FindJewel
{
    public class FindJewelManager : OVMissionOrigin
    {
        [SerializeField] private RectTransform[] rectTransforms;
        private Vector3[] startTransforms;
        public bool isClear;
        [SerializeField] private GameObject jewelObject;

        public override void Awake()
        {
            base.Awake();
            SetStartTransforms();

            Jewel.OnClickedJewelHandler -= MissionClear;
            Jewel.OnClickedJewelHandler += MissionClear;
        }
        public override void MissionClear()
        {
            base.MissionClear();

            GetComponentInChildren<FindJewelManager>().isClear = true;
        }
        private void OnEnable()
        {
            ResetTransforms();
            isClear = false;
            jewelObject.SetActive(true);
        }
        private void SetStartTransforms()
        {
            startTransforms = new Vector3[rectTransforms.Length];
            for(int i = 0; i< rectTransforms.Length; ++i)
            {
                startTransforms[i] = rectTransforms[i].localPosition;
            }
        }
        private void ResetTransforms()
        {
            for(int i = 0; i< rectTransforms.Length; ++i)
            {
                rectTransforms[i].localPosition = startTransforms[i];
            }
        }
    }
}