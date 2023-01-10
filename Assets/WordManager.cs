using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;
    private StringBuilder currentInputWord;
    public WordSpawner wordSpawner;
    private void Start()
    {
        currentInputWord = new StringBuilder();
        //detele later:
        WordGenerator.FillDict(); // hard coded to fill up dummy database.
        AddWord();
        AddWord();
        AddWord();
    }

    public void AddWord()
    {
        var wordData = WordGenerator.GetRandomWordData();
        Word word = new Word(wordData.Key,wordData.Value, wordSpawner.SpawnWord());

        Debug.Log(word.word);
        words.Add(word);
    }

    public void InputLetter(char input)
    {
        //on backspace
        if (input == '\b')
        {
            if(currentInputWord.Length > 0){
                currentInputWord.Length--;
                Debug.Log(currentInputWord.ToString());
            }
        }
        //on enter
        else if (input == '\r')
        {
            bool foundAnswer = false;
            foreach (Word word in words)
            {
                foreach (string answer in word.asnwers)
                {
                    if (currentInputWord.ToString() == answer)
                    {
                        Debug.Log("Correct!!");
                        foundAnswer = true;
                        //uncomment to delete the word from list
                            // words.Remove(word);
                        word.display.RemoveWord();
                        break;
                    }
                }
                if (foundAnswer)
                {
                    break;
                }
            }
            currentInputWord.Clear();
        }
        else
        {
            currentInputWord.Append(input);
            Debug.Log(currentInputWord.ToString());
        }
    }
}


