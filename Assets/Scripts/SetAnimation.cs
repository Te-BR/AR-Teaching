using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    public int State;
    private bool setTimer = false;
    public Animator Animator;
    public AnimationClip MasterClip;
    private float animationTimer;
    public float manualOverride = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Animator == null)
        {
            try
            {
                // Your code that may throw exceptions
                Animator = GameObject.FindGameObjectWithTag("Fine").GetComponent<Animator>();
            }
            catch (System.Exception ex)
            {
                // Handle the exception without logging it to the console
                //Debug.Log("An error occurred, but it's handled.");
            }
            
        }else{

            if(setTimer == false){
                GetTimer();
                setTimer = true;
            }

        }
    }
    
    public void GetTimer(){
        AnimationClip[] clips = Animator.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            if(MasterClip.name == clip.name){
                animationTimer = clip.length;
            }
        }
    }

    public void PlayAnimation()
    {

        Animator.SetInteger("Animation", State);
        StartCoroutine(WaitAnimationEnd(animationTimer));
    }


    IEnumerator WaitAnimationEnd(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime + manualOverride);
        Animator.SetInteger("Animation", 0);
    }
}
