using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

// here it can be used a database from which the words can be extracted
public class WordGenerator : MonoBehaviour
{
    private static Dictionary<string, string[]> wordDict = new Dictionary<string, string[]>();
    private static string filePath = Application.streamingAssetsPath + "/WordsData/" + "/CustomLevel/" + "/test.txt";

    public static void SetDatabase()
    {
        List<string> fileData = File.ReadAllLines(filePath).ToList();

        foreach (var data in fileData)
        {
            string[] wordData = data.Split(':');

            wordDict.Add(wordData[0],wordData[1].Split(","));
        }
    }
    public static KeyValuePair<string, string[]> GetRandomWordData()
    {
        if (wordDict.Count == 0)
        {
            return new KeyValuePair<string, string[]>("!#@#$", new string[] { string.Empty });
        }
        var randomWordData = wordDict.ElementAt(Random.Range(0, wordDict.Count));
        wordDict.Remove(randomWordData.Key);
        return randomWordData;
    }
}
