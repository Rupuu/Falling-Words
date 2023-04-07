using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LangDropdownController : MonoBehaviour
{
    private List<string> defaultLangOptions = new List<string> { "English-A1", "English-B1","English-C1", "English-Random" };
    public TMP_Dropdown langDropdown;
    public Button deleteBtn;
    public TextMeshProUGUI deleteBtnTxt;
    void Start()
    {
        LoadLangDropdown();
        ChangeDeleteBtnState();

        langDropdown.onValueChanged.AddListener(delegate
        {
            ChangeLang();
        });
    }

    public void ChangeLang()
    {
        PlayerPrefs.SetString("chosenLang", langDropdown.options[langDropdown.value].text);

        ChangeDeleteBtnState();
    }

    public void LoadLangDropdown()
    {
        FileManager.FillLangDropdown(langDropdown);

        langDropdown.RefreshShownValue();

        langDropdown.value = langDropdown.options
            .FindIndex(x => x.text == PlayerPrefs.GetString("chosenLang"));
    }

    public void DeleteOption()
    {
        FileManager.DeleteLangDropdownOption(langDropdown);

        FileManager.FillLangDropdown(langDropdown);
        langDropdown.RefreshShownValue();

        langDropdown.value = 0;
        PlayerPrefs.SetString("chosenLang", langDropdown.options[0].text);
    }

    // disables the delete button if the current chosen language matches one of the defaults
    private void ChangeDeleteBtnState()
    {

        if (defaultLangOptions.Contains(PlayerPrefs.GetString("chosenLang")))
        {
            deleteBtn.enabled = false;

            Color transparrent = Color.white;
            transparrent.a = 0;
            deleteBtn.image.color = transparrent;

            deleteBtnTxt.color = Color.red;
        }
        else
        {
            deleteBtn.enabled = true;
            deleteBtn.image.color = Color.black;
            deleteBtnTxt.color = Color.white;
        }
    }
}
