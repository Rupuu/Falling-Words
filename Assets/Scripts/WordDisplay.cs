using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float fallSpeed;

    //sets the word to text component
    public void SetWord(string word)
    {
        text.text = word;
        gameObject.name = word;
        fallSpeed = PlayerPrefs.GetFloat("fallSpeed");
    }

    //stop the movement & destroys the text component that the word is related to
    public void RemoveWord()
    {
        //add an animation, sprites atc here
        text.color = Color.green;
        fallSpeed = 0f;

        Destroy(gameObject, 0.1f);
    }

    // moves the text component in a specific direction every frame
    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}
