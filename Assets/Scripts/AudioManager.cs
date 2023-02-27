using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip keyPress, backspacePress, correctAnswerSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Update()
    {
        audioMixer.SetFloat("mixerVolume", PlayerPrefs.GetFloat("mixerVolume"));
    }

    public void PlayClip(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayKeyPress(){
        effectSource.PlayOneShot(keyPress);
    }
    public void PlayBackspacePress(){
        effectSource.PlayOneShot(backspacePress);
    }

    public void PlayCorrectAnswer(){
        effectSource.PlayOneShot(correctAnswerSound);
    }
}
