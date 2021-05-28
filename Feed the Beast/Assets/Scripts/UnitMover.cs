using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMover : MonoBehaviour, ICommandable
{
    [Header("State")]
    public MoverState state = MoverState.Idle;
    public Vector2 point;

    [Header("Settings")]
    public float speed = 16f;
    public float accelerationLerp = 4f;
    public float stoppingDistance = 4f;
    public float targetUpdateRate = 0.2f;
    public GameObject pointIndicator;

    public RandomSoundPool pointClip;

    Vector3 previousTargetPosition;
    float timeTillTargetUpdate = 0f;

    Rigidbody2D rb;
    AdvancedAnimator animator;
    NavMeshAgent agent;
    AudioController controller;
    Targeter targeter;

    public void Command(Vector2 pos, Transform[] selected, int thisIndex) {
        // Search for target at pos
        targeter.ClearTarget();
        Collider2D[] hits = Physics2D.OverlapPointAll(pos);
        foreach(Collider2D hit in hits) {
            TargetableObject targetable = hit.GetComponent<TargetableObject>();

            // Set the target
            if(targetable != null) {
                targeter.SetTarget(targetable);
            }
        }

        // Move to point if no target is found
        if(targeter.target == null) {
            agent.SetDestination((Vector3)pos);
            GameObject.Instantiate(pointIndicator, (Vector3)pos, transform.rotation);
        }

        if(thisIndex == 0) 
                controller.PlayClip(pointClip.RandomClip());
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<AdvancedAnimator>();
        agent = GetComponent<NavMeshAgent>();
        controller = Camera.main.GetComponent<AudioController>();
        targeter = GetComponent<Targeter>();
    }

    void Start() {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update() {
        if(targeter.target != null) {
            MoveToTarget();
        }

        Animate();
    }

    void Animate() {
        animator.SetFloat("Velocity", agent.velocity.magnitude);
        animator.SetXScale(Mathf.Sign(agent.velocity.x));
    }

    void MoveToTarget() {
        if(!agent.hasPath) {
            // OnReachedTarget();
        }

        timeTillTargetUpdate -= Time.deltaTime;

        if(timeTillTargetUpdate <= 0f && previousTargetPosition != targeter.target.transform.position) {
            agent.SetDestination(targeter.target.transform.position);
            previousTargetPosition = targeter.target.transform.position;
        }
    }

    void OnReachedTarget() {
        previousTargetPosition = Vector3.zero;
        timeTillTargetUpdate = 0f;
        targeter.ClearTarget();
    }
}

public enum MoverState {
    Idle,
    Moving
}