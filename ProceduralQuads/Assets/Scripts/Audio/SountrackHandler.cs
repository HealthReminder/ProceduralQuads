using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SountrackHandler : MonoBehaviour
{
    [SerializeField] private string _soundtrackName;
    [SerializeField] private float _fadeInSpeed = 1.0f;
    [SerializeField] private float _fadeOutSpeed = 1.0f;
    public void Play()
    {
        FindObjectOfType<SoundtrackManager>().PlaySoundtrack(_soundtrackName, _fadeOutSpeed, _fadeInSpeed);
    }
    public void Stop()
    {
        FindObjectOfType<SoundtrackManager>().StopSoundtrack(_fadeOutSpeed);
    }
}
