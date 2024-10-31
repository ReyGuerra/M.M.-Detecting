using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";


    public void ChangeAnimationState(string newState){
        if (AnimatorIsPlaying("JumpingFacingForward"))
        {
            return;
        }
        if(currentState == newState){
            return;
        }

        currentState = newState;
        animator.Play(currentState);
    }

    bool AnimatorIsPlaying(string stateName){
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimationState("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
