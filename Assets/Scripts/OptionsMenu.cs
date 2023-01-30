using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown langDropdown;
    public TMP_InputField directoryInputField;
    public TMP_InputField wordsInputField;
    public TextMeshProUGUI resultBox;
    public TextMeshProUGUI spawnDelayCounter;
    public TextMeshProUGUI fallSpeedCounter;
    public static float fallSpeed = 0.7f; //default value
    public static float spawnDelay = 2.0f; //default value
    private string filePath;
    private string[] wordsInputData;
    private string directoryName;
    void Start()
    {
        // setup listener for changed language
        langDropdown.onValueChanged.AddListener(delegate
        {
            ChangeLang();
        });
    }

    public void ChangeLang()
    {
        WordGenerator.chosenLang = langDropdown.options[langDropdown.value].text;
    }

    public void SetValue(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFallingSpeed(float speed)
    {
        fallSpeed = speed;
        fallSpeedCounter.text = speed.ToString("F2");
    }

    public void SetSpawnDelay(float delay)
    {
        spawnDelay = delay;
        spawnDelayCounter.text = delay.ToString("F2");
    }

    public void GetWordsInput(string input)
    {
        wordsInputData = input.Split("\n",System.StringSplitOptions.RemoveEmptyEntries);
    }
    public void GetDirectoryName(string input)
    {
        directoryName = input;
        filePath = Application.streamingAssetsPath + "/WordsData/" + $"/{directoryName}";
    }

    public void CreateNewWordsData()
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
        Directory.CreateDirectory(filePath);

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "words.txt")))
        {
            foreach (string wordInput in wordsInputData)
            {
                outputFile.WriteLine(wordInput);
            }
            outputFile.Close();
        }
        langDropdown.options.Add(new TMP_Dropdown.OptionData(directoryName));

        resultBox.color = Color.green;
        resultBox.text = "Word list Added!";
    }

    public void ClearFields(){
        directoryInputField.text = string.Empty;
        wordsInputField.text = string.Empty;
        resultBox.text = string.Empty;
        directoryName = string.Empty;
        wordsInputData = new string[0];
    }
}
