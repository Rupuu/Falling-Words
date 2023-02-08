using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    private float wordDelay;
    private float nextWordTime = 0f;

    private void Start() {
        wordDelay = PlayerPrefs.GetFloat("spawnDelay");       
    }
    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            // wordDelay *= 0.99f; //makes the words fall faster by time
        }
    }
}
