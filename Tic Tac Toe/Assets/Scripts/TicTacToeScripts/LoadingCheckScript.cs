using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCheckScript : MonoBehaviour
{
    public GameObject Title;
    public TextMeshProUGUI EndingTitle;
    public GameObject EndingUI;
    void Start()
    {
        MainLogicScript.Instance.CheckBoard();
        MainLogicScript.Instance.ImageChange();
        if (MainLogicScript.gameEnd == 1)
        {
            if (MainLogicScript.turn == 0)
                MainLogicScript.turn = 1;
            else
                MainLogicScript.turn = 0;
            EndingTitle.text = $"Player {MainLogicScript.turn + 1} win!";
            Title.SetActive(false);
            EndingUI.SetActive(true);

            MainLogicScript.turn = 1;
            MainLogicScript.gameEnd = 0;
            MainLogicScript.Instance.KillSelf();
        }
        else if (MainLogicScript.gameEnd == 2)
        {
            EndingTitle.text = $"You're tied!";
            Title.SetActive(false);
            EndingUI.SetActive(true);

            MainLogicScript.turn = 1;
            MainLogicScript.gameEnd = 0;
            MainLogicScript.Instance.KillSelf();
        }
        else
        {
            Title.SetActive(true);
            EndingUI.SetActive(false);
        }
    }
}
