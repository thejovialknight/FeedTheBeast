using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : AIState
{
    public float patrolRange = 64f;
    public float cooldownToMove = 3f;

    PatrolState state = PatrolState.Idle;
    float timeTillAction = 0f;
    Vector2 targetPos;

    Commander commander;

    void Awake() {
        commander = GetComponent<Commander>();
    }

    public override void Tick() {
        if(state == PatrolState.Idle) {
            timeTillAction -= Time.deltaTime;

            if(timeTillAction <= 0f) {
                ChooseNewPoint();
            }
        } else if(Vector3.Distance(transform.position, (Vector3)targetPos) < 8f) {
            state = PatrolState.Idle;
            timeTillAction = cooldownToMove;
        }
        
    }

    void ChooseNewPoint() {
        targetPos = Random.insideUnitCircle * patrolRange;
        commander.Command(targetPos);
        state = PatrolState.Moving;
    }
}

public enum PatrolState {
    Idle,
    Moving
}