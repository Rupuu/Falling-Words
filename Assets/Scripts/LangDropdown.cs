using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LangDropdown : MonoBehaviour
{
    public TMP_Dropdown langDropdown;
    void Start()
    {
        langDropdown.onValueChanged.AddListener(delegate{
            ChangeLang();
        });
    }

    public void ChangeLang(){
        WordGenerator.chosenLang = langDropdown.options[langDropdown.value].text;
        Debug.Log(WordGenerator.chosenLang);
    }
}
