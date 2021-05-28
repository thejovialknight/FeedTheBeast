using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 96f;
    public float lerpSpeed = 5f;

    Vector3 target;

    void Start() {
        target = transform.position;
    }

    void Update() {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        target += new Vector3(xMove, yMove, 0f).normalized * speed * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, target, lerpSpeed * Time.deltaTime);
    }
}
