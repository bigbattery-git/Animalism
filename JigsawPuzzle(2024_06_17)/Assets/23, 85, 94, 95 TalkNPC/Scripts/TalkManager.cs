using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.TalkNPC
{
    public class TalkManager : MonoBehaviour
    {
        [SerializeField] private OVMissionOrigin origin;
        [SerializeField] private TalkData talkData;

        [Header("Talk Button")]
        [SerializeField] private TalkButton[] talkButton;

        [Header("Speech Bubble")]
        [SerializeField] private Text speechBubble;

        private int talkSequence;

        private bool canClick;

        private Coroutine coroutine;
        private void Awake()
        {
            foreach(var talk in talkButton)
            {
                talk.SetManager(this);
            }
        }
        private void OnEnable()
        {
            if(coroutine != null) StopCoroutine(coroutine);

            talkSequence = 0;
            coroutine = StartCoroutine(SetText(talkSequence));
        }

        private IEnumerator SetText(int _talkSequence)
        {
            // ������ �ʱ�ȭ
            foreach(var talk in talkButton)
            {
                talk.SetTextID(0, null);
            }

            // ��ǳ�� ���� ���忡 Ÿ�ڱ� ȿ�� �ֱ�
            string currentText = null;
            float typingSpeed = 0.1f;
            
            for(int i = 0; i< talkData.talkingData[_talkSequence].talkBubbleData.Length; i++)
            {
                currentText += talkData.talkingData[_talkSequence].talkBubbleData[i];
                speechBubble.text = currentText;
                yield return new WaitForSeconds(typingSpeed);
            }

            // �������� ���� �־��ֱ�
            List<int> rndList = new List<int>() { 0, 1, 2 };

            for(int i = 0; i< talkButton.Length; i++)
            {
                int rnd = UnityEngine.Random.Range(0, rndList.Count);

                int buttonID = talkData.talkingData[_talkSequence].talkSelectData[rndList[rnd]].selectID;
                string buttonText = talkData.talkingData[_talkSequence].talkSelectData[rndList[rnd]].selectText;

                talkButton[i].SetTextID(buttonID, buttonText);

                rndList.RemoveAt(rnd);
            }

            canClick = true;
        }
        private IEnumerator SetWorngText(int _talkSequence)
        {
            // ��ǳ�� ���� ���忡 Ÿ�ڱ� ȿ�� �ֱ�
            string currentText = null;
            float typingSpeed = 0.1f;

            for (int i = 0; i < talkData.talkingData[talkSequence].talkBubbleWorngData.Length; i++)
            {
                currentText += talkData.talkingData[talkSequence].talkBubbleWorngData[i];
                speechBubble.text = currentText;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        private IEnumerator SetAllCorrectText()
        {
            // ��ǳ�� ���� ���忡 Ÿ�ڱ� ȿ�� �ֱ�
            string currentText = null;
            float typingSpeed = 0.1f;

            for (int i = 0; i < talkData.talkFinishMissionData.Length; i++)
            {
                currentText += talkData.talkFinishMissionData[i];
                speechBubble.text = currentText;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        public void SetNextText(int _talkButtonID)
        {
            if (!canClick) return;

            if(_talkButtonID != talkData.talkingData[talkSequence].correctID)
            {
                coroutine = StartCoroutine(SetWorngText(talkSequence));
                origin.MissionFailed();

                canClick = false;
                return;
            }

            talkSequence++;

            if (talkSequence == talkData.talkingData.Length)
            {
                coroutine = StartCoroutine(SetAllCorrectText());
                origin.MissionClear();

                canClick = false;
                return;
            }

            coroutine = StartCoroutine(SetText(talkSequence));
        }
    }
}