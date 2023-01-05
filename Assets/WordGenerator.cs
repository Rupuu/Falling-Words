using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// here it can be used a database from which the words can be extracted
public class WordGenerator : MonoBehaviour
{
    private static string[] wordlist = {"peace", "morning", "afternoon", "day", "precious",
     "pricy", "fun", "decorative", "imagination", "story", "door", "pit", "bed", "wood", "walk"};
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0,wordlist.Length);
        string randomWord = wordlist[randomIndex];

        return randomWord;
    }
}
