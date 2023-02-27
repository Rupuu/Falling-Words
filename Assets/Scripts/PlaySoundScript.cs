using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    public void Play(){
        AudioManager.Instance.PlayClip(clip);
    }
}
