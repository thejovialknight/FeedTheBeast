using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AIState
{
    public float cooldownToMove;
    public float cooldownToStop;

    bool isMoving = false;
    float timeTillAction = 0f;

    void Update() {
        
    }
}
