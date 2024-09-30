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
        
        [SerializeField] private Sprite[] marks;                      // 사용할 마커들
        [SerializeField] private Image[] images;                      // 사용될 이미지들

        [SerializeField] private Mark[] markGameObjects;              // 마크 클래스 컴포넌트를 가지고 있는 친구들
        public bool CanClick => canClick;
        // 색깔들
        private Color activeColor = new Color(1, 1, 1, 1);            // 활성화된 아이콘들
        private Color inactiveColor = new Color(0.5f, 0.5f, 0.5f, 1); // 비활성화된 아이콘들
        private Color nullColor = new Color(1, 1, 1, 0);              // 할당안된 아이콘들

        private int[] correctNum = new int[4];                        // 정답
        private int[] inputNum;                                       // 입력받은 아이콘들

        private bool canClick;                                        // 버튼 클릭 가능 여부
        private int inputCount = 0;                                   // 버튼 클릭 카운트

        private int level = 1;                                        // 사보타지 레벨
        private const int TotalClearLevel = 4;                        // 총 클리어 레벨

        private Coroutine activeInputMark;                           // 마크 순서대로 나오게 하는 코루틴 저장 변수
        private void Awake()
        {
            // Mark에 toInputMark 변수를 본인으로 지정
            foreach(Mark mark in markGameObjects)
            {
                mark.SetToInputMark(this);
            }
        }
        private void OnEnable()
        {
            // 미션이 켜질 때 코루틴 켜져있으면 꺼지게 하기
            if(activeInputMark != null)
            {
                StopCoroutine(activeInputMark);
            }


            SetRandomNums();
            ResetMission();
        }

        /// <summary>
        /// 플레이어가 Mark를 클릭했을 때 실행하는 함수
        /// </summary>
        /// <param name="_markID">클릭한 마크 번호</param>
        public void OnClickMark(int _markID)
        {
            // 클릭 안될 시 함수 실행 X
            if (!canClick) return;

            // inputCount번의 inputNum이 _markID로 설정
            inputNum[inputCount] = _markID;

            // inputCount번의 마크 배치판에 _markID번의 마크 배치
            SetImage(images[inputCount], _markID);

            // inputCount 증가
            inputCount++;

            // 만약 inputCount번째에 들어갈 markID와 correctNum의 번호가 다르면 미션 실패 처리 및 미션 리셋
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

            // 만약 입력 개수가 레벨(반복 횟수) 이상이면 레벨 업
            if(inputCount >= level)
            {
                level++;

                // 레벨이 총 클리어 레벨보다 높으면 버튼 클릭 X, 미션 클리어
                if(level > TotalClearLevel)
                {
                    canClick = false;

                    manager.MissionClear();
                    return;
                }
                // 그게 아니라면 레벨 업 한 것 적용 후 미션 시작
                else
                {
                    canClick = false;
                    inputCount = 0;

                    activeInputMark =  StartCoroutine(ActiveInputMark(level));
                }
            }
        }

        /// <summary>
        /// 해당 미션 초기화 함수
        /// </summary>
        public void ResetMission()
        {
            
            // 레벨, 버튼 입력 수, 번호 초기화 
            level = 1;
            inputCount = 0;
            inputNum = null;

            // 마크 이미지 초기화
            for (int i = 0; i < correctNum.Length; i++)
            {
                images[i].sprite = marks[correctNum[i]];
            }

            SetImages(nullColor);

            // 코루틴 시작
            activeInputMark = StartCoroutine(ActiveInputMark(level));            
        }

        /// <summary>
        /// 마크 랜덤으로 고르기
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