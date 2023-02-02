using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private StringBuilder currentInputWord;
    public WordSpawner wordSpawner;
    public WordScorer wordScorer;
    public FinishController controller;
    public InputFieldDisplay inputDisplay;
    private void Start()
    {
        currentInputWord = new StringBuilder();

        WordGenerator.SetDatabase();
    }

    public void AddWord()
    {
        var wordData = WordGenerator.GetRandomWordData();
        if (wordData.Key == "!#@#$")
        {
            if (wordScorer.OverallCountOfWords() == WordGenerator.allWordsCount)
            {
                controller.FinishGame();
            }
            return;
        }
        Word word = new Word(wordData.Key, wordData.Value, wordSpawner.SpawnWord());

        words.Add(word);
    }

    public void InputLetter(char input)
    {
        //on backspace
        if (input == '\b')
        {
            if (currentInputWord.Length > 0)
            {
                currentInputWord.Length--;
                inputDisplay.SetInputText(currentInputWord.ToString());
            }
        }
        //on enter
        else if (input == '\r')
        {
            bool result = checkCorrectAnswerAndRemove();
            inputDisplay.ChangeInputAnswerColor(result);

            inputDisplay.ResetAfterDelay();
            currentInputWord.Clear();
        }
        else
        {
            currentInputWord.Append(input);
            inputDisplay.SetInputText(currentInputWord.ToString());
        }
    }
    public bool checkCorrectAnswerAndRemove()
    {
        foreach (Word word in words)
        {
            foreach (string answer in word.asnwers)
            {
                if (currentInputWord.ToString() == answer)
                {
                    word.display.RemoveWord();
                    wordScorer.correctWords.Add(word);
                    words.Remove(word);
                    return true;
                }
            }
        }
        return false;
    }
}


