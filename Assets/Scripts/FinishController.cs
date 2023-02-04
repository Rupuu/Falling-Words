using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishController : MonoBehaviour
{
    public GameObject finishMenuUI;
    public TextMeshProUGUI untypedWords;
    public TextMeshProUGUI correctWords;
    public WordScorer wordScorer;
    public void FinishGame()
    {
        FillTextBoxes();
        finishMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    private void FillTextBoxes()
    {
        foreach (var word in wordScorer.untypedWords)
        {
            string[] answers = word.asnwers;
            untypedWords.text += $"{word.word}: {string.Join(", ", answers)}\n";
        }
        untypedWords.text.TrimEnd();

        foreach (var word in wordScorer.correctWords)
        {
            string[] answers = word.asnwers;
            correctWords.text += $"{word.word}: {string.Join(", ", answers)}\n";
        }
        correctWords.text.TrimEnd();
    }
}
