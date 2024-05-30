using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
       AudioListener.volume = volumeSlider.value;
        save();

    }
    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
