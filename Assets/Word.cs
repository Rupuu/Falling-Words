using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex; 
    //private int chosenAsnwerIndex;
       // the position in the answer array
       // can modify the wordTyped to be: wordTyped = (typeIndex >= answers[chosenAnswerIndex].lenght)

    public Word(string _word)
    {
        word = _word;
        typeIndex = 0;
        //chosenAnswerIndex = -1;
    }

    public char GetNextLetter(){
        return word[typeIndex];
    }

    public void TypeAnswerLetter(){
        typeIndex++;
    }

    public bool WordTyped(){
        //if(chosenAnswerIndex != -1)
        bool wordTyped = (typeIndex >= word.Length);
        return wordTyped;
    }
}
