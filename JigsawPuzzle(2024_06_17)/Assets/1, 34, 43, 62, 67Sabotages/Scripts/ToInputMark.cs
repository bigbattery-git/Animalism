using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missons.Village.Sabotage_Trashbox
{
    public class ToInputMark : MonoBehaviour
    {
        [SerializeField] private OVMissionOrigin manager;
        
        [SerializeField] private Sprite[] marks;                      // ����� ��Ŀ��
        [SerializeField] private Image[] images;                      // ���� �̹�����

        [SerializeField] private Mark[] markGameObjects;              // ��ũ Ŭ���� ������Ʈ�� ������ �ִ� ģ����
        public bool CanClick => canClick;
        // �����
        private Color activeColor = new Color(1, 1, 1, 1);            // Ȱ��ȭ�� �����ܵ�
        private Color inactiveColor = new Color(0.5f, 0.5f, 0.5f, 1); // ��Ȱ��ȭ�� �����ܵ�
        private Color nullColor = new Color(1, 1, 1, 0);              // �Ҵ�ȵ� �����ܵ�

        private int[] correctNum = new int[4];                        // ����
        private int[] inputNum;                                       // �Է¹��� �����ܵ�

        private bool canClick;                                        // ��ư Ŭ�� ���� ����
        private int inputCount = 0;                                   // ��ư Ŭ�� ī��Ʈ

        private int level = 1;                                        // �纸Ÿ�� ����
        private const int TotalClearLevel = 4;                        // �� Ŭ���� ����

        private Coroutine activeInputMark;                           // ��ũ ������� ������ �ϴ� �ڷ�ƾ ���� ����
        private void Awake()
        {
            // Mark�� toInputMark ������ �������� ����
            foreach(Mark mark in markGameObjects)
            {
                mark.SetToInputMark(this);
            }
        }
        private void OnEnable()
        {
            // �̼��� ���� �� �ڷ�ƾ ���������� ������ �ϱ�
            if(activeInputMark != null)
            {
                StopCoroutine(activeInputMark);
            }


            SetRandomNums();
            ResetMission();
        }

        /// <summary>
        /// �÷��̾ Mark�� Ŭ������ �� �����ϴ� �Լ�
        /// </summary>
        /// <param name="_markID">Ŭ���� ��ũ ��ȣ</param>
        public void OnClickMark(int _markID)
        {
            // Ŭ�� �ȵ� �� �Լ� ���� X
            if (!canClick) return;

            // inputCount���� inputNum�� _markID�� ����
            inputNum[inputCount] = _markID;

            // inputCount���� ��ũ ��ġ�ǿ� _markID���� ��ũ ��ġ
            SetImage(images[inputCount], _markID);

            // inputCount ����
            inputCount++;

            // ���� inputCount��°�� �� markID�� correctNum�� ��ȣ�� �ٸ��� �̼� ���� ó�� �� �̼� ����
            for(int i = 0; i< inputCount; i++)
            {
                if (inputNum[i] != correctNum[i])
                {
                    canClick = false;
                    inputCount = 0;
                    ResetMission();
                    
                    return;
                }
                else
                {
                    // images[i].color = inactiveColor;
                }
            }

            // ���� �Է� ������ ����(�ݺ� Ƚ��) �̻��̸� ���� ��
            if(inputCount >= level)
            {
                level++;

                // ������ �� Ŭ���� �������� ������ ��ư Ŭ�� X, �̼� Ŭ����
                if(level > TotalClearLevel)
                {
                    canClick = false;

                    manager.MissionClear();
                    return;
                }
                // �װ� �ƴ϶�� ���� �� �� �� ���� �� �̼� ����
                else
                {
                    canClick = false;
                    inputCount = 0;

                    activeInputMark =  StartCoroutine(ActiveInputMark(level));
                }
            }
        }

        /// <summary>
        /// �ش� �̼� �ʱ�ȭ �Լ�
        /// </summary>
        public void ResetMission()
        {
            
            // ����, ��ư �Է� ��, ��ȣ �ʱ�ȭ 
            level = 1;
            inputCount = 0;
            inputNum = null;

            // ��ũ �̹��� �ʱ�ȭ
            for (int i = 0; i < correctNum.Length; i++)
            {
                images[i].sprite = marks[correctNum[i]];
            }

            SetImages(nullColor);

            // �ڷ�ƾ ����
            activeInputMark = StartCoroutine(ActiveInputMark(level));            
        }

        /// <summary>
        /// ��ũ �������� ����
        /// </summary>
        private void SetRandomNums()
        {
            List<int> numBox = new List<int>();

            for (int i = 0; i < marks.Length; i++)
            {
                numBox.Add(i);
            }

            for (int i = 0; i < correctNum.Length; i++)
            {
                int randomNum = UnityEngine.Random.Range(0, numBox.Count);

                correctNum[i] = numBox[randomNum];

                numBox.RemoveAt(randomNum);
            }
        }
        private IEnumerator ActiveInputMark(int activeMark)
        {
            inputNum = new int[activeMark];

            if (activeMark == 1)
                yield return new WaitForSeconds(2f);

            else
            {
                yield return new WaitForSeconds(1f);
                SetImages(nullColor);
                yield return new WaitForSeconds(1f);
            }                          

            for (int i = 0; i<activeMark; i++)
            {
                images[i].color = activeColor;
                if (i == activeMark - 1)
                {
                    canClick = true;
                    yield return new WaitForSeconds(0.5f);
                    images[i].color = nullColor;
                    break;
                }
                yield return new WaitForSeconds(0.5f);

                images[i].color = nullColor;

                yield return new WaitForSeconds(1f);
            }
        }

        private void SetImages(Color _color)
        {
            foreach(var image in images)
            {
                image.color = _color;
            }
        }

        private void SetImage(Image _image, int _markNum)
        {
            _image.color = activeColor;
            _image.sprite = marks[_markNum];
        }
    }
}