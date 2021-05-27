using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Possibly selected outline color changing to display health information?
public class UnitOutlineController : MonoBehaviour, ISelectable
{
    public SpriteRenderer outlineSprite;
    public Color selectedOutline;
    public Color deselectedOutline;

    bool isSelected = false;

    public void Select(int thisIndex) {
        outlineSprite.color = selectedOutline;
        isSelected = true;
    }

    public void Deselect() {
        outlineSprite.color = deselectedOutline;
        isSelected = false;
    }

    public void Hover(){
        if(!isSelected)
            outlineSprite.color = selectedOutline;
    }

    public void HoverLeave() {
        if(!isSelected)
            outlineSprite.color = deselectedOutline;
    }
}
