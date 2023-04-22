using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceFade : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] float _targetVolume;
    [SerializeField] float _speed;

    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    IEnumerator FadeInRoutine()
    {
        float progress = 0;
        _source.volume = 0;
        _source.Play();
        while (progress < 1)
        {
            progress += Time.deltaTime * _speed;
            _source.volume = Mathf.Lerp(0, _targetVolume, progress * progress);
            yield return null;
        }
        _source.volume = _targetVolume;

        yield break;
    }
    IEnumerator FadeOutRoutine()
    {
        float progress = 0;
        float intialVolume = _source.volume;
        while (progress < 1)
        {
            progress += Time.deltaTime * _speed;
            _source.volume = Mathf.Lerp(intialVolume, 0, progress * progress);
            yield return null;
        }
        _source.volume = 0;

        yield break;
    }
}
