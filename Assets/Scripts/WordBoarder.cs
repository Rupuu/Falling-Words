// the class contains list of all the untyped words
// TODO: refference this class in the logic for the game over panel, and use the list of untyped words
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordBoarder : MonoBehaviour
{
    public WordManager wordManager;
    public List<string> untypedWords;

    // logic for when the words fall out of screen
    //аdd logic for late answered, if a word is contained in untypedWords list and in correctly answered list, mark as late aswered word
    void OnCollisionEnter2D(Collision2D collidedWord)
    {
        untypedWords.Add(collidedWord.gameObject.name);

        Word matchedWord = wordManager.words.Find(x => x.word == collidedWord.gameObject.name);
        wordManager.words.Remove(matchedWord);

        Destroy(collidedWord.gameObject, 0.2f);
    }
}
