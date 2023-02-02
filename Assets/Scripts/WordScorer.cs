using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScorer : MonoBehaviour
{
    public List<Word> untypedWords;
    public List<Word> correctWords;

    public int OverallCountOfWords()
    {
        return untypedWords.Count + correctWords.Count;
    }
}
