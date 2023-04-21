using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public static SoundtrackManager Instance; // Singleton pattern
    public float Volume = 1.0f;

    [SerializeField] private AudioSource _audioSourceA;
    [SerializeField] private AudioSource _audioSourceB;
    [System.Serializable]
    public struct Soundtrack
    {
        public string Name;
        public AudioClip Clip;
    }
    [SerializeField] private Soundtrack[] _availableSoundtracks;
    private int currentSource;

    private void Awake()
    {
        _audioSourceA.volume = 0;
        _audioSourceB.volume = 0;

        // Singleton pattern
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    public void StopSoundtrack(float fadeOut = 1.0f)
    {
        if (currentSource == 0)
            StartCoroutine(FadeOutRoutine(_audioSourceA, fadeOut));
        else
            StartCoroutine(FadeOutRoutine(_audioSourceB, fadeOut));

        currentSource = (currentSource == 0) ? 1 : 0;
    }
    public void PlaySoundtrack(string name, float fadeOut = 1.0f, float fadeIn = 1.0f)
    {
        AudioClip clip = null;
        for (int i = 0; i < _availableSoundtracks.Length; i++)
        {
            if (name == _availableSoundtracks[i].Name)
                clip = _availableSoundtracks[i].Clip;
        }

        if (!clip)
        {
            Debug.LogError($"Soundtrack of name: {name} does not exist.");
            return;
        }

        if (currentSource == 0)
        {
            StartCoroutine(FadeOutRoutine(_audioSourceA, fadeOut));
            StartCoroutine(FadeInRoutine(_audioSourceB, clip, fadeIn));
        }
        else
        {
            StartCoroutine(FadeOutRoutine(_audioSourceB, fadeOut));
            StartCoroutine(FadeInRoutine(_audioSourceA, clip, fadeIn));
        }
        currentSource = (currentSource == 0) ? 1 : 0;

    }
    IEnumerator FadeInRoutine(AudioSource source, AudioClip clip, float speed)
    {
        float progress = 0;
        source.volume = 0;
        source.clip = clip;
        source.Play();
        while (progress < 1)
        {
            source.volume = Mathf.Lerp(0, Volume, progress);
            progress += Time.deltaTime * speed;
            yield return null;
        }
        source.volume = Volume;

        yield break;
    }
    IEnumerator FadeOutRoutine(AudioSource source, float speed)
    {
        float progress = 0;
        float initialVolume = source.volume;
        while (progress < 1)
        {
            source.volume = Mathf.Lerp(initialVolume, 0, progress);
            progress += Time.deltaTime * speed;
            yield return null;
        }
        source.volume = 0;
        source.Stop();
        source.clip = null;
        yield break;
    }
}
