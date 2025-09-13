using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButtonScript : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("TicTacToeScene");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameStartScene");
    }
}
