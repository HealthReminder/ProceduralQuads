using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelBehaviour : MonoBehaviour
{
    public string sceneName = "Default";
    public ScreenTransition ScreenTransition;
    public AudioSource WinAudio;
    public void GoToNextLevel()
    {
        StartCoroutine(EndLevelRoutine());
    }
    IEnumerator EndLevelRoutine()
    {
        WinAudio.Play();
        ScreenTransition.FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sceneName);
        yield break;
    }
}
