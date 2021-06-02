using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public TargetableObject target;

    public bool SetTarget(TargetableObject target) {
        this.target = target;
        OnTargetSet?.Invoke();
        return true;
    }
    public void ClearTarget() {
        target = null;
    }

    public delegate void TargetSetEvent();
    public event TargetSetEvent OnTargetSet;
}
