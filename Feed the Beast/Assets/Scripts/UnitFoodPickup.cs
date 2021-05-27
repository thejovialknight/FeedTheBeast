using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFoodPickup : MonoBehaviour
{
    public float pickupRange = 6f;
    public LayerMask foodMask;

    FoodInventory inventory;

    void Awake()
    {
        inventory = GetComponent<FoodInventory>();
    }

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pickupRange, foodMask);
        foreach(Collider2D hit in hits) {
            Food food = hit.GetComponent<Food>();
            if(food != null) {
                if(inventory.TryAdd())
                    food.Pickup();
            }
        }
    }
}
