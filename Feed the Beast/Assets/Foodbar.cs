using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodbar : MonoBehaviour, ISelectable
{
    public Animator[] animators;

    FoodInventory inventory;
    Animator animator;
    bool isSelected = false;

    void Awake() {
        inventory = GetComponent<FoodInventory>();
    }

    void OnEnable() {
        inventory.OnHealthChanged += OnHealthChanged;
    }

    void OnDisable() {
        inventory.OnHealthChanged -= OnHealthChanged;
    }

    void OnHealthChanged() {
        if(isSelected) 
            SetFoodLevel();
    }

    public void SetFoodLevel() {
        for(int i = 0; i < animators.Length; i++) {
            if((inventory.food) < i) {
                animators[i].SetBool("Filled", false);
                animators[i].SetBool("Biggest", false);
            }

            if((inventory.food) > i) {
                animators[i].SetBool("Filled", true);
            }

            if((inventory.food) == i) {
                animators[i].SetBool("Biggest", true);
            }
        }
    }

    public void ShowFood() {
        SetFoodLevel();

        foreach(Animator animator in animators) {
            animator.SetBool("Selected", true);
        }
    }

    public void HideFood() {
        foreach(Animator animator in animators) {
            animator.SetBool("Selected", false);
        }
    }

    public void Select(int thisIndex) {
        isSelected = true;
        ShowFood();
    }

    public void Deselect() {
        HideFood();
        isSelected = false;
    }

    public void Hover(){
        if(!isSelected) {
            ShowFood();
        }
    }

    public void HoverLeave() {
        if(!isSelected) {
            HideFood(); 
        }
    }
}
