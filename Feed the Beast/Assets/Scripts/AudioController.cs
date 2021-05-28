using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip, float volume) {
        source.PlayOneShot(clip, volume);
    }

    public void PlayClip(AudioClip clip) {
        PlayClip(clip, 1f);
    }
}
