using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleCorner : MonoBehaviour
{
    public float scaleSpeed = 5f;
    public float moveSpeed = 5f;
    public bool isVisible = false;

    Vector3 desiredPositionOffset;
    Vector3 centerPositionOffset;
    Vector3 targetPosition;
    Transform target;
    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        Vector3 desiredScale;
        Vector3 desiredPos;

        if(target != null) {
            targetPosition = target.position + centerPositionOffset;
        }

        if(isVisible) {
            desiredScale = Vector3.one;
            desiredPos = targetPosition + desiredPositionOffset;
        }
        else {
            desiredScale = Vector3.zero;
            desiredPos = targetPosition + desiredPositionOffset;
        }
        transform.position = Vector3.Lerp(transform.position, desiredPos, moveSpeed * Time.deltaTime);
    }

    public void SetTarget(Vector3 posOff, Vector3 centerPosOff, Transform targ) {
        desiredPositionOffset = posOff;
        centerPositionOffset = centerPosOff;
        target = targ;

        transform.position = target.position + centerPositionOffset + desiredPositionOffset;
    }

    public void SetVisible(bool isVisible) {
        this.isVisible = isVisible;
        animator.SetBool("isVisible", isVisible);
    }
}
