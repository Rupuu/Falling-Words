using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldDisplay : MonoBehaviour
{
    public TextMeshProUGUI inputField;

    public void InputFieldTextUpdate(string text)
    {
        inputField.text = text;
    }
    public void ChangeInputAnswerColorAndReset(bool result)
    {
        if (result)
        {
            inputField.color = Color.green;
        }
        else
        {
            inputField.color = Color.red;
        }
        Invoke("ResetInput",0.2f);
    }
    private void ResetInput()
    {
        inputField.color = Color.white;
        inputField.text = string.Empty;
    }
}
