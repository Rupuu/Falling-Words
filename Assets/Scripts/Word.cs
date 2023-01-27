using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    public string[] asnwers;

    public WordDisplay display;

    public Word(string _word, string[] _asnwers, WordDisplay _display)
    {
        word = _word;
        asnwers = _asnwers;

        display = _display;
        display.SetWord(word);
    }

}
