using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;
    private void Start()
    {
        AddWord();
        AddWord();
        AddWord();
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        Debug.Log(word.word);

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeAnswerLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                // create method that iterates through the answers, gets a letter as a parameter
                // return the answer if it maches
                // makes the chosenAnswerIndex the current chosen aswer
                
                    // activeWordAnswer = GetAnswer(letter)
                    // if(activeWordAnswer != null)
                    //{
                    // hasActiveWord = true;
                    // type the first letter
                    //
                    // break;
                    //}
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeAnswerLetter();
                    break;
                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}


