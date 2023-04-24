using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] internal AudioMixer mixer;  // Reference to the Audio Mixer
    private AudioMixerSnapshot _snapshot;
    internal void SetMasterVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); // Convert the volume value to decibels

    }

    internal void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);

    }

    internal void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);

    }
    public void SaveSnapshot(string snapshotName)
    {
        // Create a new snapshot and save the current mixer parameters
        AudioMixerSnapshot snapshot = mixer.FindSnapshot(snapshotName);
        if (snapshot == null)
        {
            snapshot = mixer.CreateSnapshot(snapshotName);
        }
        snapshot.TransitionTo(0);
        snapshot.name = snapshotName;
    }
    public void LoadSnapshot(string snapshotName, float transitionTime)
    {
        // Transition to the specified snapshot over the specified transition time
        AudioMixerSnapshot snapshot = mixer.FindSnapshot(snapshotName);
        if (snapshot != null)
        {
            snapshot.TransitionTo(transitionTime);
        }
    }
}

public class AudioGUI : AudioController
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    public void ChangeMusicVolume()
    {
        SetMusicVolume(_musicSlider.value);
    }
    public void ChangeSFXVolume()
    {
        SetSFXVolume(_sfxSlider.value);
    }

    private void Awake()
    {
        LoadSnapshot("Default", 0);
        mixer.GetFloat("MusicVolume", out float v);
        _musicSlider.value = v;
        mixer.GetFloat("SFXVolume", out v);
        _musicSlider.value = v;
    }

    [ContextMenu("Save Configuration")]
    public void SaveConfiguration()
    {
        SaveSnapshot("Default");

    }
    [ContextMenu("Load Default")]
    public void LoadConfiguration()
    {
        LoadSnapshot("Default", 0.5f);

    }
}