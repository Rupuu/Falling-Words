using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    public WordDisplay SpawnWord()
    {
        //see new wave spawner methods
        Vector3 randomPosition = new Vector3(Random.Range(-2.5f,2.5f), 6.5f);
        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);

        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
