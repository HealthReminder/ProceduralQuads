using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] string _sceneName;
    public void LoadLevel()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
