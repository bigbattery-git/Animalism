using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomAnimation : MonoBehaviour
{
    [SerializeField] private int animationCount;
    [SerializeField] private float animationChangeTime;

    private Animator animator;
    private int beforeAnimationNum = -1;
    private float animationChangeTimeCount = 0;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            animationChangeTimeCount += Time.deltaTime;

            if(animationChangeTimeCount > animationChangeTime)
            {
                SetRndAnimation();
                animationChangeTimeCount = 0;
            }            
        }
    }

    private void SetRndAnimation()
    {
        List<int> rndList = new List<int>();
        for(int i = 0; i<animationCount; i++)
        {
            if (beforeAnimationNum == i) continue;
            rndList.Add(i);
        }

        int animationNum = rndList[Random.Range(0, rndList.Count)];

        animator.SetInteger("AnimationState", animationNum);
        animator.SetTrigger("AnimationAction");

        beforeAnimationNum = animationNum;
    }
    /*
    private bool isIdle
    {
        get
        {
            return animator.GetBool("IsIdle");
        }

        set
        {
            animator.SetBool("IsIdle", value);
        }
    }

    private int currentAnimationIdx
    {
        get
        {
            return animator.GetInteger("AnimationState");
        }

        set
        {
            animator.SetInteger("AnimationState", value);
        }
    }

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();

        currentAnimationIdx = Random.Range(0, animationCount);

        isIdle = true;
    }*/
    #region 안쓰는 것
    /*
    IEnumerator SetRandomAnimaion()
    {
            // animationChangeTime 후 에니메이션 종료
            yield return new WaitForSeconds(animationChangeTime);
            animator.SetTrigger("AnimationEnd");

            yield return null;

            // sameAnimationCount와 겹치지 않는 변수 할당
            int currentAnimationCount = 0;
            do
            {
            currentAnimationCount = Random.Range(0, animationCount);
            }
            while (sameAnimationCount == currentAnimationCount);

            // 같은 번호 할당 막기위해 sameAnimationCount에 animationCount 할당. 이후 실행
            sameAnimationCount = currentAnimationCount;
            animator.SetInteger("AnimationState", currentAnimationCount);
    }*/
    #endregion
    #region 안쓰는 것 2
    /*
    public void EndIdle()
    {
        isIdle = false;
    }
    
    public void Play0()
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 1) currentAnimationIdx = animationCount - 1;

        isIdle = true;
    }

    public void Play1()
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 1) currentAnimationIdx = 0;

        isIdle = true;
    }
    public void Play2()
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 2) currentAnimationIdx = 1;

        isIdle = true;
    }
    public void Play3()
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 3) currentAnimationIdx = 2;

        isIdle = true;
    }
    public void Play4()
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 4) currentAnimationIdx = 3;

        isIdle = true;
    }
    public void Play5()
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 5) currentAnimationIdx = 4;

        isIdle = true;
    }
    public void Play6() 
    {
        currentAnimationIdx = Random.Range(0, animationCount);

        if (currentAnimationIdx == 6) currentAnimationIdx = 5;

        isIdle = true;
    }
    */
    #endregion
}