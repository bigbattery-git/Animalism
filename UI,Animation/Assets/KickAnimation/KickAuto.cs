using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAuto : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        AnimationClip clip = animator.runtimeAnimatorController.animationClips[0];
        AnimationEvent evt = new AnimationEvent();
        evt.functionName = nameof(OnExitEvent);
        evt.time = clip.length;
        clip.AddEvent(evt);
    }
}
public class OnExitEvent
{

}
