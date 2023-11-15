using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    public AudioMixerGroup group;

}
