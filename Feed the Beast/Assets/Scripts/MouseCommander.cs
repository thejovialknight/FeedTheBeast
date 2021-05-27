using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCommander : Commander
{
    void Update() {
        if(Input.GetButtonDown("Action")) {
            Command((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
