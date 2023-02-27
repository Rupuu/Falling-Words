using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// here is used a database from which the words are being extracted
public class WordGenerator : MonoBehaviour
{
    public static Dictionary<string, string[]> BaseWordsDict = new Dictionary<string, string[]>();
    public static int AllWordsCount;

    public static KeyValuePair<string, string[]> GetRandomWordData()
    {
        if (BaseWordsDict.Count == 0)
        {
            return new KeyValuePair<string, string[]>("!#@#$", new string[] { string.Empty });
        }
        var randomWordData = BaseWordsDict.ElementAt(Random.Range(0, BaseWordsDict.Count));
        BaseWordsDict.Remove(randomWordData.Key);
        return randomWordData;
    }
}
