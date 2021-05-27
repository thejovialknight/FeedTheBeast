using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventory : MonoBehaviour
{
    public int food = 0;
    public int maxFood = 3;

    public bool TryAdd() {
        if(food < maxFood) {
            food++;
            return true;
        }

        return false;
    }
}
