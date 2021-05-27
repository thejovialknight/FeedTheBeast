using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    Selector selector;

    void Awake() {
        selector = GetComponent<Selector>();
    }

    public virtual void Command(Vector2 pos) {
        ICommandable[] commandables = selector.GetSelectorComponents<ICommandable>();

        for(int i = 0; i < commandables.Length; i++) {
            commandables[i].Command(pos, selector.selected.ToArray(), i);
        }
    }
}
