using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Toggle soundToggle;

    private void Start()
    {
        LoadData();
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
    public void RefreshSound()
    {
        if (soundToggle.isOn)
        {
            mixer.SetFloat("SoundVolume", -80f);
        }
        else
        {
            mixer.SetFloat("SoundVolume", 0);
        }
    }
    public void SaveData()
    {
        if (soundToggle.isOn)
            PlayerPrefs.SetInt("Volume", 0);
        else
            PlayerPrefs.SetInt("Volume", 1);

    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            if(PlayerPrefs.GetInt("Volume") == 0)
                soundToggle.isOn = true;
            else
                soundToggle.isOn = false;
            RefreshSound();
        }
    }
}
