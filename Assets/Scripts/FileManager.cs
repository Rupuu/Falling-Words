using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;

public class FileManager : MonoBehaviour
{
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
        string filepath = Application.streamingAssetsPath + "/WordsData/";

        string[] folderNames = Directory.GetDirectories(filepath).Select(Path.GetFileName).ToArray();

        foreach (var name in folderNames)
        {
            if(dropdown.options.FindIndex(x=>x.text == name) != -1){
                continue;
            }
            dropdown.options.Add(new TMP_Dropdown.OptionData(name));
        }
        dropdown.RefreshShownValue();

        dropdown.value = dropdown.options
            .FindIndex(x => x.text == PlayerPrefs.GetString("chosenLang"));
    }
}
