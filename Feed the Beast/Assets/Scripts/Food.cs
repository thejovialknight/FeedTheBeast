using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject pickedUp;

    public void Pickup() {
        GameObject.Instantiate(pickedUp, transform.position, transform.rotation);
        GameObject.Destroy(gameObject);
    }
}
