using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider spawnDelaySlider;
    public Slider fallSpeedSlider;
    public TMP_Dropdown langDropdown;
    public TextMeshProUGUI spawnDelayCounter;
    public TextMeshProUGUI fallSpeedCounter;
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("mixerVolume");

        fallSpeedSlider.value = PlayerPrefs.GetFloat("fallSpeed");
        fallSpeedCounter.text = PlayerPrefs.GetFloat("fallSpeed").ToString("F2");

        spawnDelaySlider.value = PlayerPrefs.GetFloat("spawnDelay");
        spawnDelayCounter.text = PlayerPrefs.GetFloat("spawnDelay").ToString("F2");
    }
    void Update()
    {
        fallSpeedCounter.text = PlayerPrefs.GetFloat("fallSpeed").ToString("F2");
        spawnDelayCounter.text = PlayerPrefs.GetFloat("spawnDelay").ToString("F2");
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("mixerVolume", volume);
    }
    public void SetFallingSpeed(float speed)
    {
        PlayerPrefs.SetFloat("fallSpeed", speed);
    }
    public void SetSpawnDelay(float delay)
    {
        PlayerPrefs.SetFloat("spawnDelay", delay);
    }
}
