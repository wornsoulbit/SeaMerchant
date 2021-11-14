using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChange : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("level1Audio"))
        {
            PlayerPrefs.SetFloat("level1Audio", 1);
            Load();
        }else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("level1Audio");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("level1Audio", volumeSlider.value);
    }

}
