using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// here it can be used a database from which the words can be extracted
public class WordGenerator : MonoBehaviour
{
    private static Dictionary<string, string[]> wordDict = new Dictionary<string, string[]>();
    public static void FillDict()
    {
        wordDict.Add("parent", new string[] { "родител", "настойник" });
        wordDict.Add("еxpert", new string[] { "експерт", "професионалист" });
        wordDict.Add("walk", new string[] { "разходка", "ходене", "вървене" });
        wordDict.Add("morning", new string[] { "сутрин", "утро" });
        wordDict.Add("imagination", new string[] { "въображение", "фантазия" });
        wordDict.Add("story", new string[] { "история", "разказ" });
        wordDict.Add("precious", new string[] { "скъпо", "ценно","скъп", "скъпoценнен"});
        wordDict.Add("place", new string[] { "място", "площад", "селище" });
        wordDict.Add("doctor", new string[] { "доктор", "лекар" });
        wordDict.Add("bubble", new string[] { "балон", "мехур" });
        wordDict.Add("civil", new string[] { "граждански", "цивилен", "вървене" });
        wordDict.Add("coal", new string[] { "въглища", "въглени" });
        
        wordDict.Add("dummy1", new string[] { "1"});
        wordDict.Add("dummy2", new string[] { "2"});
        wordDict.Add("dummy3", new string[] { "3"});
        wordDict.Add("dummy4", new string[] { "4"});
        wordDict.Add("dummy5", new string[] { "5"});
        wordDict.Add("dummy6", new string[] { "6"});
        wordDict.Add("dummy7", new string[] { "7"});
        wordDict.Add("dummy8", new string[] { "8"});
    }
    public static KeyValuePair<string, string[]> GetRandomWordData()
    {
        if(wordDict.Count == 0){
            return new KeyValuePair<string, string[]>("!#@#$",new string[]{string.Empty});
        }
        var randomWordData = wordDict.ElementAt(Random.Range(0, wordDict.Count));
        wordDict.Remove(randomWordData.Key);
        return randomWordData;
    }
}
