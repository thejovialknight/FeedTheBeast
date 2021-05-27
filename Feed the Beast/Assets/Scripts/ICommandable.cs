using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandable
{
    void Command(Vector2 pos, Transform[] selected, int thisIndex);
}
