using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldDisplay : MonoBehaviour
{
    public TextMeshProUGUI inputField;

    public void SetInputText(string text)
    {
        inputField.text = text;
    }
    public void ChangeInputAnswerColor(bool result)
    {
        if (result)
        {
            inputField.color = Color.green;
        }
        else
        {
            inputField.color = Color.red;
        }
    }
    
    public void ResetAfterDelay(){
        Invoke(nameof(ResetInput), 0.2f);
    }

    private void ResetInput()
    {
        inputField.color = Color.white;
        inputField.text = string.Empty;
    }

}
