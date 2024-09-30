using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTestScript : MonoBehaviour
{
    private Animator[] animators;
    private SpriteRenderer[] renderers;
    private bool isWalk = false;
    // Start is called before the first frame update
    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isWalk = isWalk == true ? false : true;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            FlipGraphics();
        }

        foreach(Animator animator in animators)
        {
            animator.SetBool("IsWalk", isWalk);
        }
    }

    private void FlipGraphics()
    {
        foreach(SpriteRenderer renderer in renderers)
        {
           if(renderer.flipX == true)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }
        }
    }
}
