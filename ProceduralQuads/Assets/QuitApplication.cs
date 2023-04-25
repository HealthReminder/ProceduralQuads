using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle quitting of game in all platforms
/// </summary>
public class QuitApplication : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        StartCoroutine(QuitWithDelay());
#endif
    }
    /// <summary>
    /// Delayed operation to make sure other processes are done
    /// </summary>
    IEnumerator QuitWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Application Ended.");
        Application.Quit();
    }
}
