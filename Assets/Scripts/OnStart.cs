using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetString("chosenLang") == string.Empty)
        {
            PlayerPrefs.SetFloat("mixerVolume", 0);
            PlayerPrefs.SetFloat("spawnDelay", 2.0f);
            PlayerPrefs.SetFloat("fallSpeed", 0.7f);
            PlayerPrefs.SetString("chosenLang", "CustomLevel");
        }
    }
}
