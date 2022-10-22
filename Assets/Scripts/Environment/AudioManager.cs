using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;


    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
 
        audioSource = GetComponent<AudioSource>();
    }

    public void AudioPlay(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void AudioStop(AudioClip clip)
    {

    }
}
