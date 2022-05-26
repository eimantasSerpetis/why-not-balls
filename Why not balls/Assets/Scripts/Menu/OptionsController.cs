using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    AudioManager audioManager;
    public Slider volumeSlider;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        volumeSlider.value = audioManager.globalVolume;
    }

    public void updateVolume()
    {
        audioManager.UpdateVolumes(volumeSlider.value);
    }

}
