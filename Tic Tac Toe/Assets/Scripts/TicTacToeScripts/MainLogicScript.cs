using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLogicScript : MonoBehaviour
{
    public static MainLogicScript Instance;
    public static int turn = 1;
    public static bool isMiniGameWin;
    public bool isMiniGamePlaying;
    public static int gameEnd = 0;
    int[,] gameBoard;
    public string[] buttonList;
    Dictionary<string, int[]> buttonLocationList;
    public static string button;
    Image image;
    public Sprite nothing_image;
    public Sprite x_image;
    public Sprite o_image;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (turn == 0)
            turn = 1;
        else
            turn = 0;
        gameBoard = new int[3, 3] 
        {
            {-11, -12, -13 },
            {-14, -15, -16 },
            {-17, -18, -19 }
        };
        buttonLocationList = new Dictionary<string, int[]>()
        {
            {"LeftTop", new int[] {0, 0 } },
            {"LeftMiddle", new int[] {0, 1 } },
            {"LeftBottom", new int[] {0, 2 } },
            {"CenterTop", new int[] {1, 0 } },
            {"CenterMiddle", new int[] {1, 1 } },
            {"CenterBottom", new int[] {1, 2 } },
            {"RightTop", new int[] {2, 0 } },
            {"RightMiddle", new int[] {2, 1 } },
            {"RightBottom", new int[] {2, 2 } }
        };
        buttonList = buttonLocationList.Keys.ToArray();
    }

    public void ButtonClick()
    {
        MiniGameStart();
    }

    public void MiniGameStart()
    {
        SceneManager.LoadScene("MiniGameScene");
    }

    public void MiniGameEnd()
    {
        SceneManager.LoadScene("TicTacToeScene");
    }

    public void BoardUpdate()
    {
        if (isMiniGameWin == true)
            gameBoard[buttonLocationList[button][0], buttonLocationList[button][1]] = turn;
    }

    public void ImageChange()
    {
        for (int i=0; i<9; i++)
        {
            image = GameObject.Find(buttonList[i]).GetComponent<Image>();
            if (gameBoard[buttonLocationList[buttonList[i]][0], buttonLocationList[buttonList[i]][1]] == 0)
            {
                image.sprite = o_image;
            }
            else if (gameBoard[buttonLocationList[buttonList[i]][0], buttonLocationList[buttonList[i]][1]] == 1)
            {
                image.sprite = x_image;
            }
            else
                image.sprite = nothing_image;
        }
    }

    public void CheckBoard()
    {
        for(int i=0; i<3; i++)
        {
            if (gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                gameEnd = 1;
            else if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
                gameEnd = 1;
        }
        if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
            gameEnd = 1;
        else if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])
            gameEnd = 1;

        int temp = 0;
        for(int i=0; i<3; i++)
        {
            for (int j = 0; j < 3; j++)
                temp += gameBoard[i, j];
        }
        if (temp >= 0 && gameEnd == 0)
            gameEnd = 2;
    }

    public void KillSelf()
    {
        Destroy(this.gameObject);
    }
}
