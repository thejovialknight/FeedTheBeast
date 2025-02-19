using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomSoundPool
{
    public AudioClip[] clips;

    public bool Ready() {
        return(clips.Length > 0);
    }
    public AudioClip RandomClip() {
        return clips[Random.Range(0, clips.Length)];
    }
}
