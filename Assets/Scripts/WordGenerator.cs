using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// here is used a database from which the words are being extracted
public class WordGenerator : MonoBehaviour
{
    public static Dictionary<string, string[]> baseWordsDict = new Dictionary<string, string[]>();
    public static int allWordsCount;

    public static KeyValuePair<string, string[]> GetRandomWordData()
    {
        if (baseWordsDict.Count == 0)
        {
            return new KeyValuePair<string, string[]>("!#@#$", new string[] { string.Empty });
        }
        var randomWordData = baseWordsDict.ElementAt(Random.Range(0, baseWordsDict.Count));
        baseWordsDict.Remove(randomWordData.Key);
        return randomWordData;
    }
}
