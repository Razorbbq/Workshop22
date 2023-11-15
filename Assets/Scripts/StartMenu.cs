using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume", 0.75f)) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.75f)) * 20);
        mixer.SetFloat("SFXVol", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume", 0.75f)) * 20);
    }
    private void ClickSound()
    {
        FindObjectOfType<SoundManager>().Play("Click");
    }

    public void StartButton()
    {
        ClickSound();
        SceneManager.LoadScene(1);
    }

    public void OptionsButton()
    {
        ClickSound();
        SceneManager.LoadScene(2);
    }
    public void QuitButton()
    {
        ClickSound();
        Debug.Log("Quit");
        Application.Quit();
    }

}
