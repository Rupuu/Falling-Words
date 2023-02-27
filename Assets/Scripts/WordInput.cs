using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;
    void Update()
    {
        if (PauseController.GameIsPaused)
        {
            return;
        }

        foreach (char letter in Input.inputString)
        {
            wordManager.InputLetter(letter);
        }
    }
}
