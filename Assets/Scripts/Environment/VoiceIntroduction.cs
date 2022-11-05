using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceIntroduction : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioClip;

    private bool _isPlaying;
    private void Start()
    {
        _isPlaying = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_isPlaying) {
            AudioManager.instance.AudioPlay(_audioClip);
            _isPlaying = true;
        }
    }
}
