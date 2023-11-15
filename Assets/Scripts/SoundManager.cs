using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    private AudioSource audioSource;

    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(string name)
    {
        Sound sound = null;
        for(int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].Name == name)
            {
                sound = sounds[i];
                break;
            }
        }
        if(sound == null)
        {
            Debug.Log("Couldn't find sound: " + name);
            return;
        }


        audioSource.clip = sound.clip;
        audioSource.volume = sound.volume;
        audioSource.outputAudioMixerGroup = sound.group;
        audioSource.Play();

    }


}


