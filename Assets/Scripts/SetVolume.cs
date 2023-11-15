using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;

    public Slider musicSlider;

    public Slider sfxSlider;

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }
    public void SetMasterLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public void SetMusicLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSFXLevel(float sliderValue)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    public void BackButton()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        SceneManager.LoadScene(0);
    }
}