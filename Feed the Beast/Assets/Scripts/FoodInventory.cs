using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventory : MonoBehaviour
{
    public int food = 0;
    public int maxFood = 3;

    void OnValidate() {
        OnHealthChanged?.Invoke();
    }

    public bool TryAdd() {
        if(food < maxFood) {
            food++;
            OnHealthChanged?.Invoke();
            return true;
        }

        return false;
    }

    public delegate void ChangedEvent();
    public event ChangedEvent OnHealthChanged;
}
