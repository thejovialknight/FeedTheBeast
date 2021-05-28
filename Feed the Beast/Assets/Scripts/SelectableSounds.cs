using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableSounds : MonoBehaviour, ISelectable
{
    public RandomSoundPool selectedClips;
    public RandomSoundPool hoveredClips;

    AudioController controller;

    void Awake() {
        controller = Camera.main.GetComponent<AudioController>();
    }

    public void Select(int thisIndex) {
        if(thisIndex == 0)
            controller.PlayClip(selectedClips.RandomClip());
    }

    public void Deselect() {

    }

    public void Hover() {
        controller.PlayClip(hoveredClips.RandomClip());
    }

    public void HoverLeave() {
        controller.PlayClip(hoveredClips.RandomClip());
    }

}
