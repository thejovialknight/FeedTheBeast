using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{
    public Rect targetRect;
    public Collider2D col;

    void Awake() {
        col = GetComponent<Collider2D>();
    }  

    public Rect OffsetRect() {
        Rect offsetRect = targetRect;
        offsetRect.center = (Vector2)transform.position + targetRect.center;
        return offsetRect;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube(transform.position + (Vector3)targetRect.center, (Vector3)targetRect.size);
    }
}
