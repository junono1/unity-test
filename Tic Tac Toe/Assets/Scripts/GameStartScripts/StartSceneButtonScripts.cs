using UnityEngine;
using UnityEngine.SceneManagement;


public class StartSceneButtonScripts : MonoBehaviour
{
    [SerializeField]
    public void GameStart()
    {
        SceneManager.LoadScene("TicTacToeScene");
    }
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }
}
