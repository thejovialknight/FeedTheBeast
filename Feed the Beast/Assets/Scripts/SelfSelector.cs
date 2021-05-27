using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSelector : Selector
{
    void Start() {
        Select(transform);
    }
}
