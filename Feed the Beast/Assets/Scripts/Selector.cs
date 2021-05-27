using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public List<Transform> selected = new List<Transform>();
    public List<Transform> hovered = new List<Transform>();

    public void UpdateHover(Collider2D[] cols) {
        List<Transform> transforms = new List<Transform>();
        foreach(Collider2D col in cols) {
            transforms.Add(col.transform);
        }

        UpdateHover(transforms);
    }

    public void UpdateHover(List<Transform> newHovered) {
        foreach(ISelectable selectable in GetSelectableDifference(hovered, newHovered)) {
            selectable.Hover();
        }

        foreach(ISelectable selectable in GetSelectableDifference(newHovered, hovered)) {
            selectable.HoverLeave();
        }

        hovered = newHovered;
    }

    public ISelectable[] GetSelectableDifference(List<Transform> compareSet, List<Transform> complimentSet) {
        List<ISelectable> selectables = new List<ISelectable>();

        foreach(Transform hoverTransform in complimentSet) {
            ISelectable[] currentSelectables = hoverTransform.GetComponents<ISelectable>();
            if(currentSelectables != null) {
                if(!compareSet.Contains(hoverTransform)) {
                    foreach(ISelectable selectable in currentSelectables) {
                        selectables.Add(selectable);
                    }
                }
            }
        }

        return selectables.ToArray();
    }

    public void ClearHovers() {
        foreach(ISelectable hover in GetSelectorComponents<ISelectable>(hovered)) {
            hover.HoverLeave();
        }

        hovered = new List<Transform>();
    }

    public void ClearSelections() {
        foreach(ISelectable selectable in GetSelectorComponents<ISelectable>()) {
            selectable.Deselect();
        }

        selected = new List<Transform>();
    }

    public void Select(Transform selection) {
        ClearHovers();
        ISelectable[] selectables = selection.GetComponents<ISelectable>();

        if(selectables != null) {
            foreach(ISelectable selectable in selectables) {
                selectable.Select(selected.Count);
            }

            selected.Add(selection);
        }
    }

    public T[] GetSelectorComponents<T>() {
        return GetSelectorComponents<T>(selected);
    }

    public T[] GetSelectorComponents<T>(List<Transform> transforms) {
        List<T> components = new List<T>();
        foreach(Transform selection in transforms) {
            T[] selectionComponents = selection.GetComponents<T>();
            if(selectionComponents != null) {
                components.AddRange(selectionComponents);
            }
        }

        return components.ToArray();
    }
}
