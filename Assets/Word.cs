using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    public string[] asnwers;

    public Word(string _word, string[] _asnwers)
    {
        word = _word;
        asnwers = _asnwers;
    }
}
