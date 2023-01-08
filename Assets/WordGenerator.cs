using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// here it can be used a database from which the words can be extracted
public class WordGenerator : MonoBehaviour
{
    private static Dictionary<string,string[]> wordDict = new Dictionary<string, string[]>();
    public static void FillDict(){
        wordDict.Add("parent", new string[]{"родител","настоиник"});
        wordDict.Add("еxpert", new string[]{"експерт","професионалист"});
        wordDict.Add("walk", new string[]{"разходка","ходене", "вървене"});
        wordDict.Add("morning", new string[]{"сутрин","утро"});
        wordDict.Add("imagination", new string[]{"въображение","фантазия"});
        wordDict.Add("story", new string[]{"история","разказ"});
        wordDict.Add("precious", new string[]{"скъпоценен","ценен", "скъп"});
        wordDict.Add("place", new string[]{"място","площад", "селище"});
    }
    public static Word GetRandomWord()
    {
        var randomWord = wordDict.ElementAt(Random.Range(0,wordDict.Count));
        wordDict.Remove(randomWord.Key);

        return new Word(randomWord.Key,randomWord.Value);
    }
}
