using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    private float wordDelay = 2.0f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if(Time.time >= nextWordTime){
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            // wordDelay *= 0.99f; //makes the words fall faster by the time
        }
    }
}
