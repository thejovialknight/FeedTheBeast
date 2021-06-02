using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    public AIState initialState;
    public AIState state;

    public void SetState(AIState newState) {
        if(state != null)
            state.Exit();

        state = newState;
        state.Enter();
    }

    void Start() {
        SetState(initialState);
    }

    void Update() {
        if(state != null)
            state.Tick();
    }
}
