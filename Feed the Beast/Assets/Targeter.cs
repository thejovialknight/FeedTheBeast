using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour, ISelectable
{
    public TargetableObject target;
    public Transform reticleParent;
    public ReticleCorner[] reticles; // clockwise from top left

    public bool isSelected = false;
    public bool isHover = false;

    public bool SetTarget(TargetableObject target) {
        this.target = target;
        SetReticleVisible(true);
        SetReticleTargets();
        return true;
    }

    public void ClearTarget() {
        target = null;
    }

    void Start() {
        reticleParent.parent = null;
        SetReticleVisible(false);
    }

    void Update() {
        if((isSelected || isHover) && target != null)
            SetReticleVisible(true);
        else
            SetReticleVisible(false);
    }

    void SetReticleTargets() {
        reticles[3].SetTarget(new Vector3(target.targetRect.xMin, target.targetRect.yMin, transform.position.z), target.targetRect.center, target.transform);
        reticles[2].SetTarget(new Vector3(target.targetRect.xMax, target.targetRect.yMin, transform.position.z), target.targetRect.center, target.transform);
        reticles[1].SetTarget(new Vector3(target.targetRect.xMax, target.targetRect.yMax, transform.position.z), target.targetRect.center, target.transform);
        reticles[0].SetTarget(new Vector3(target.targetRect.xMin, target.targetRect.yMax, transform.position.z), target.targetRect.center, target.transform);
    }

    public void Select(int thisIndex) {
        isSelected = true;
    }

    public void Deselect() {
        isSelected = false;
    }

    public void Hover() {
        isHover = true;
    }

    public void HoverLeave() {
        isHover = false;
    }

    void SetReticleVisible(bool isVisible) {
        foreach(ReticleCorner reticle in reticles) {
            reticle.SetVisible(isVisible);
        }
    }
}
