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
        if(inventory.food == 0) {
            HideFood();
        } else {
            ShowFood();
        }

        for(int i = 0; i < animators.Length; i++) {
            animators[i].SetBool("Filled", false);
            animators[i].SetBool("Biggest", false);

            if((inventory.food - 1) > i) {
                animators[i].SetBool("Filled", true);
            }

            if((inventory.food - 1) == i) {
                animators[i].SetBool("Filled", true);
                animators[i].SetBool("Biggest", true);
            }
        }
    }

    public void ShowFood() {
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
        SetFoodLevel();
    }

    public void Deselect() {
        HideFood();
        isSelected = false;
    }

    public void Hover(){
        if(!isSelected) {
            ShowFood();
            SetFoodLevel();
        }
    }

    public void HoverLeave() {
        if(!isSelected) {
            HideFood(); 
        }
    }
}
