using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAnimator : MonoBehaviour
{
    public List<Animator> animators = new List<Animator>();
    public List<Animator> oneShotAnimators = new List<Animator>();

    // One shot animators must be a set of triggers with a root state that is returned to at the conclusion of the oneshot.
    public void PlayOneShot(string trigger) {
        if(oneShotAnimators.Count > 0) {
            StartCoroutine(PlayOneShotCoroutine(trigger));
        } else {
            Debug.LogError("No One Shot Animators!");
        }
    }

    public void SetSpeed(float speed)
    {
        foreach (Animator animator in animators)
        {
            animator.speed = speed;
        }
    }

    public void SetVisible(bool isVisible)
    {
        foreach (Animator animator in animators)
        {
            animator.GetComponent<SpriteRenderer>().enabled = isVisible;
        }
    }

    public void SetXScale(float xScale)
    {
        foreach (Animator animator in animators)
        {
            animator.transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }

    public void SetFloat(string key, float value)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetFloat(key, value);
            }
        }
    }

    public void SetBool(string key, bool value)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetBool(key, value);
            }
        }
    }

    public void SetTrigger(string key)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.SetTrigger(key);
            }
        }
    }

    public void ResetTrigger(string key)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                animator.ResetTrigger(key);
            }
        }
    }

    public float GetFloat(string key)
    {
        foreach (Animator animator in animators)
        {
            if (animator.runtimeAnimatorController != null)
            {
                return animator.GetFloat(key);
            }
        }

        return 0f;
    }

    IEnumerator PlayOneShotCoroutine(string trigger) {
        foreach (Animator animator in animators)
        {
            animator.GetComponent<SpriteRenderer>().enabled = false;
        }

        foreach (Animator animator in oneShotAnimators)
        {
            animator.GetComponent<SpriteRenderer>().enabled = true;
            animator.SetTrigger(trigger);
        }

        // Whilst we wait to move to the new triggered animation
        while(oneShotAnimators[0].GetCurrentAnimatorStateInfo(0).IsName("Root")) {
            yield return null;
        }

        // Whilst the first animator in oneShotAnimators isn't finished
        while(!oneShotAnimators[0].GetCurrentAnimatorStateInfo(0).IsName("Root")) {
            yield return null;
        }

        foreach (Animator animator in oneShotAnimators)
        {
            animator.GetComponent<SpriteRenderer>().enabled = false;
        }

        foreach (Animator animator in animators)
        {
            animator.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
