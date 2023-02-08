using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LangDropdown : MonoBehaviour
{
    public int count;
    public TMP_Dropdown langDropdown;
    void Start()
    {
        LoadLangDropdown();
        
        langDropdown.onValueChanged.AddListener(delegate{
            ChangeLang();
        });
    }

    public void ChangeLang(){
        PlayerPrefs.SetString("chosenLang", langDropdown.options[langDropdown.value].text);
    }

    public void LoadLangDropdown(){
        FileManager.FillLangDropdown(langDropdown);
    }
}
