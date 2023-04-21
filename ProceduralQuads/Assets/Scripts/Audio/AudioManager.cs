using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public struct AudioSet
    {
        public string Name;
        public AudioClip[] Sounds;
    }
    public static AudioManager Instance;
    [SerializeField] private int _sourceCount;
    [SerializeField] private AudioSource _sourcePrefab;
    [SerializeField] private AudioSet[] _availableSets;
    Pooling<AudioSource> _pool;

    private void Awake()
    {
        Instance = this;
        _pool = new Pooling<AudioSource>(_sourcePrefab, _sourceCount, transform, 0);
    }
    /// <summary>
    /// Spawns a new audio source in the world
    /// </summary>
    /// <param name="setName">Set from which audioclip will be pulled from</param>
    /// <param name="volume">Audio Source volume</param>
    /// <param name="position">Audio Source position in 3D world</param>
    /// <param name="pitchRange">Audio Source pitch variantion range</param>
    public void SpawnSound(string setName, float volume, Vector3 position, float pitchDefault = 1, float pitchRange = 0, int priority = 128)
    {
        AudioClip newClip = GetRandomClipFromSet(setName);

        AudioSource pooledSource = _pool.GetFromPool(position, Quaternion.identity);
        pooledSource.gameObject.SetActive(false);
        pooledSource.Stop();
        //pooledSource.loop = false;
        pooledSource.clip = newClip;
        pooledSource.volume = volume;
        pooledSource.priority = priority;
        pooledSource.pitch = pitchDefault + Random.Range(-pitchRange, pitchRange);
        pooledSource.gameObject.SetActive(true);
        pooledSource.Play();
        pooledSource.GetComponent<ReturnToPool>().Invoke("Return", pooledSource.clip.length + 1.0f);
    }
    /// <summary>
    /// Gets a random audio clip from an audio set
    /// </summary>
    /// <param name="setName">Name of the audio set</param>
    /// <returns>Random clip from audio set</returns>
    private AudioClip GetRandomClipFromSet(string setName)
    {
        AudioClip result = null;
        for (int i = 0; i < _availableSets.Length; i++)
        {
            if (_availableSets[i].Name == setName)
            {
                int r = Random.Range(0, _availableSets[i].Sounds.Length);
                result = _availableSets[i].Sounds[r];
            }
        }
        return result;
    }
    /// <summary>
    /// Return a pooled object to the pool.
    /// It is called by each Audio Source when needed
    /// </summary>
    /// <param name="t">Audio Source transform</param>
    public void ReturnToPool(Transform t)
    {
        _pool.ReturnToPool(t.GetComponent<AudioSource>());
    }
}