using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fallSpeed = 0.5f;

    public void SetWord(string word){
        text.text = word; 
    }

    public void RemoveWord(){
        //add effects here
            //try this mathod in update() method so it can change every frame (scuffed)
            // if(value from outside == true) *do the effect in update()*
        Destroy(gameObject);
    }

    private void Update() {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}
