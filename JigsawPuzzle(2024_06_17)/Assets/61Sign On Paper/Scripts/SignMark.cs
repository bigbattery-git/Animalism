using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.SignOnPaper
{
    public class SignMark : MonoBehaviour
    {
        private Image m_image;
        private bool isClear;
        [SerializeField] private OVMissionOrigin origin;
        [SerializeField] private float fillTime = 5f;
        private void Awake()
        {
            m_image = GetComponent<Image>();
        }
        private void OnEnable()
        {
            m_image.fillAmount = 0;
            isClear = false;
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (isClear) return;

            if (collision.CompareTag("MiniGameObject"))
            {
                m_image.fillAmount += Time.deltaTime / fillTime;

                if (!OVSoundRoot.Instance.Mission.ID70Signing.isPlaying)
                {
                    OVSoundRoot.Instance.Mission.ID70Signing.Play();
                }

                if(m_image.fillAmount >= 1) 
                {
                    origin.MissionClear();
                    isClear = true;
                }
            }
        }
    }
}