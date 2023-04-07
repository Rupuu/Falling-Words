using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;

public class FileManager : MonoBehaviour
{
    static string wordsDataFilePath = Application.streamingAssetsPath + "/WordsData/";
    public static void CreateWordData(string filePath, string[] wordData)
    {
        Directory.CreateDirectory(filePath);

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "words.txt")))
        {
            foreach (string word in wordData)
            {
                outputFile.WriteLine(word);
            }
            outputFile.Close();
        }
    }
    public static void FillLangDropdown(TMP_Dropdown dropdown)
    {
        string[] folderNames = Directory.GetDirectories(wordsDataFilePath).Select(Path.GetFileName).ToArray();

        dropdown.options.Clear();
        foreach (var name in folderNames)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(name));
        }
    }
    public static void DeleteLangDropdownOption(TMP_Dropdown dropdown)
    { 
        //delete the option folder with the words
        string filePath = Path.Combine(wordsDataFilePath, PlayerPrefs.GetString("chosenLang"));

        if (!Directory.Exists(filePath))
        {
            return;
        }
        Directory.Delete(filePath, true);

        // delete meta files of folder if there are any
        filePath = Path.Combine(wordsDataFilePath, $"{PlayerPrefs.GetString("chosenLang")}.meta");

        if(!File.Exists(filePath))
        {
            return;
        }
        File.Delete(filePath);
    }
    public static void SetDatabase()
    {
        string filePath = Application.streamingAssetsPath + "/WordsData/" + $"/{PlayerPrefs.GetString("chosenLang")}/" + "/words.txt";
        List<string> fileData = File.ReadAllLines(filePath).ToList();

        foreach (var data in fileData)
        {
            string[] wordData = data.Split('-');

            WordGenerator.BaseWordsDict.Add(wordData[0], wordData[1].Split(','));
        }
        WordGenerator.AllWordsCount = WordGenerator.BaseWordsDict.Count;
    }
}
