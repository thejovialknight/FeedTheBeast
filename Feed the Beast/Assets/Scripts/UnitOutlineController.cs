using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Possibly selected outline color changing to display health information?
public class UnitOutlineController : MonoBehaviour, ISelectable
{
    public SpriteRenderer outlineSprite;
    public Color maxHealthOutline;
    public Color highHealthOutline;
    public Color midHealthOutline;
    public Color lowHealthOutline;
    public Color deselectedOutline;

    public float midHealthThreshold = 0.5f;
    public float lowHealthThreshold = 0.25f;

    Health health;
    bool isSelected = false;

    void Awake() {
        health = GetComponent<Health>();
    }

    void Update() {
        if(isSelected) {
            SetSelectedColor();
        }
    }

    void SetSelectedColor() {
        if(health.health == health.maxHealth)
            outlineSprite.color = maxHealthOutline;
        else
            outlineSprite.color = highHealthOutline;

        if(health.health <= midHealthThreshold)
            outlineSprite.color = midHealthOutline;
            
        if(health.health <= lowHealthThreshold)
            outlineSprite.color = lowHealthOutline;
    }

    public void Select(int thisIndex) {
        isSelected = true;
    }

    public void Deselect() {
        outlineSprite.color = deselectedOutline;
        isSelected = false;
    }

    public void Hover(){
        if(!isSelected)
            SetSelectedColor();
    }

    public void HoverLeave() {
        if(!isSelected)
            outlineSprite.color = deselectedOutline;
    }
}
