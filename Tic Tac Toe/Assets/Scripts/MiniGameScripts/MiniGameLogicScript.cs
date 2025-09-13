using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameLogicScript : MonoBehaviour
{
    public int playerChoice;
    public int enemyChoice;
    public RawImage playerImage;
    public RawImage enemyImage;
    public Texture nothing;
    public Texture rock;
    public Texture scissors;
    public Texture paper;
    Dictionary<(int, int), string> outcome;
    

    private void Awake()
    {
        playerImage.texture = nothing;
        enemyImage.texture = nothing;
        enemyChoice = UnityEngine.Random.Range(0, 3);
        outcome = new Dictionary<(int, int), string>()
        {
            { (0, 1), "win" },
            { (1, 2), "win" },
            { (2, 0), "win" },
            { (1, 0), "lose" },
            { (2, 1), "lose" },
            { (0, 2), "lose" },
            { (0, 0), "tie" },
            { (1, 1), "tie" },
            { (2, 2), "tie" },
        };
    }

    public void EnemyImageChange()
    {
        if (enemyChoice == 0)
            enemyImage.texture = rock;
        else if (enemyChoice == 1)
            enemyImage.texture = scissors;
        else if (enemyChoice == 2)
            enemyImage.texture = paper;
    }

    public void Rock()
    {
        EnemyImageChange();
        playerImage.texture = rock;
        playerChoice = 0;
        Invoke("Judgement", 1);
    }

    public void Scissors()
    {
        EnemyImageChange();
        playerImage.texture = scissors;
        playerChoice = 1;
        Invoke("Judgement", 1);
    }

    public void Paper()
    {
        EnemyImageChange();
        playerImage.texture = paper;
        playerChoice = 2;
        Invoke("Judgement", 1);
    }

    public void Judgement()
    {
        if (outcome[(playerChoice, enemyChoice)] == "win")
            Win();
        else if (outcome[(playerChoice, enemyChoice)] == "lose")
            Lose();
        else if (outcome[(playerChoice, enemyChoice)] == "tie")
            Tie();
    }

    public void Tie()
    {
        enemyImage.texture = nothing;
        playerImage.texture = nothing;
        enemyChoice = UnityEngine.Random.Range(0, 3);
    }

    public void Win()
    {
        MainLogicScript.isMiniGameWin = true;
        MainLogicScript.Instance.BoardUpdate();
        MainLogicScript.Instance.MiniGameEnd();
    }

    public void Lose()
    {
        MainLogicScript.isMiniGameWin = false;
        MainLogicScript.Instance.BoardUpdate();
        MainLogicScript.Instance.MiniGameEnd();
    }
}
