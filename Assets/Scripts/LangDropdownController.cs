using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LangDropdownController : MonoBehaviour
{
    public TMP_Dropdown langDropdown;
    void Start()
    {
        LoadLangDropdown();

        langDropdown.onValueChanged.AddListener(delegate
        {
            ChangeLang();
        });
    }

    public void ChangeLang()
    {
        PlayerPrefs.SetString("chosenLang", langDropdown.options[langDropdown.value].text);
    }

    public void LoadLangDropdown()
    {
        FileManager.RefillLangDropdown(langDropdown);

        langDropdown.RefreshShownValue();

        langDropdown.value = langDropdown.options
            .FindIndex(x => x.text == PlayerPrefs.GetString("chosenLang"));
    }

    public void DeleteOption()
    {
        FileManager.DeleteLangDropdownOption(langDropdown);

        FileManager.RefillLangDropdown(langDropdown);
        langDropdown.RefreshShownValue();

        langDropdown.value = 0;
        PlayerPrefs.SetString("chosenLang",langDropdown.options[0].text);
    }
}
