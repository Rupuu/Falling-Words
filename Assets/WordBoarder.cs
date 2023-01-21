// the class contains list of all the untyped words
    // TODO: refference this class in the logic for the game over panel, and use the list of untyped words
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordBoarder : MonoBehaviour
{
        public List<string> untypedWords;

        // logic for when the words fall out of screen
        void OnCollisionEnter2D(Collision2D other) {
            untypedWords.Add(other.gameObject.name);
            Destroy(other.gameObject);
        }
}
