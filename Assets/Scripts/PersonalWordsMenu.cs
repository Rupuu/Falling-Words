using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class PersonalWordsMenu : MonoBehaviour
{
    public TMP_InputField directoryInputField;
    public TMP_InputField wordsInputField;
    public TextMeshProUGUI resultBox;
    private string filePath;
    private string[] wordsInputData;
    private string directoryName;
    public void GetWordsInput(string input)
    {
        wordsInputData = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }
    public void GetDirectoryName(string input)
    {
        directoryName = input;
        filePath = Application.streamingAssetsPath + "/WordsData/" + $"/{directoryName}";
    }
    public void SubmitData()
    {
        if (wordsInputData.Length == 0 || string.IsNullOrEmpty(directoryName))
        {
            resultBox.color = Color.red;
            resultBox.text = "There are empty fields!";
            return;
        }
        if (Directory.Exists(filePath))
        {
            resultBox.color = Color.red;
            resultBox.text = "Word list with this name exists!";
            return;
        }
        if (!EvaluateWordInput(wordsInputData))
        {
            resultBox.color = Color.red;
            resultBox.text = "Inputted words have invalid syntax" + '\n' +
            "Make sure words are not repeating, and there is atleast one translation.";
            return;
        }
        FileManager.CreateWordData(filePath,wordsInputData);

        resultBox.color = Color.green;
        resultBox.text = "Word list Added!";
    }
    private bool EvaluateWordInput(string[] wordsInput)
    {
        HashSet<string> uniqueWords = new HashSet<string>();

        foreach (var word in wordsInput)
        {
            string[] wordAndAnswer = word.Trim().Split('-', StringSplitOptions.RemoveEmptyEntries);
            uniqueWords.Add(wordAndAnswer[0]);

            if (wordAndAnswer.Length < 2)
            {
                return false;
            }
            // can add logic for further evaluation of the input using the created array
        }
        
        // if there are repeating words
        if (wordsInput.Length > uniqueWords.Count)
        {
            return false;
        }
        return true;
    }
    public void ClearFields()
    {
        directoryInputField.text = string.Empty;
        wordsInputField.text = string.Empty;
        resultBox.text = string.Empty;
        directoryName = string.Empty;
        wordsInputData = new string[0];
    }
}
