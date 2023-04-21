using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private string _setName;   // Name of the set on AudioManager that will be played
    [SerializeField] private float _volumeMultiplier;   // Multiplies the impact volume
    [SerializeField] private float _pitchDefault = 1;   // Default pitch of audio source
    [SerializeField] private float _pitchRange = 0;     // Pitch range from which a random pitch variation is selected
    public void PlaySound(float vol)
    {
        AudioManager.Instance.SpawnSound(
            _setName,                                   // Set name
            _volumeMultiplier * vol / 10,   // Volume by multiplier and impact magnitude
            transform.position,                           // Impact position
            _pitchDefault,                              // Default pitch
            _pitchRange,                                // Pitch variation range
            (int)Mathf.Lerp(0, 256, vol)          // Priority by impact magnitude
            );
    }
}