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
    public static void RefillLangDropdown(TMP_Dropdown dropdown)
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
        string filePath = Path.Combine(wordsDataFilePath, PlayerPrefs.GetString("chosenLang"));

        if (!Directory.Exists(filePath))
        {
            return;
        }
        Directory.Delete(filePath, true);
    }
}
