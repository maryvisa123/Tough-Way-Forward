using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string NowSceneName; 
    public string NextName; 

  
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NowSceneName);
    }

   
    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NextName);
    }

   
    public void LoadStartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

 
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
