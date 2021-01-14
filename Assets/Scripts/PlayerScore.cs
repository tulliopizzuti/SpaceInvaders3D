using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private static int score;
    private static int lives;
    private readonly static int SCORE1 = 10;
    private readonly static int SCORE2 = 20;
    private readonly static int SCORE3 = 20;
    private readonly static int SCORE4 = 25;
    private readonly static int SCORE5 = 30;
    private readonly static int SCORE0 = 50;

    static void Init()
    {
        score = 0;
        lives = 3;

    }

    public static void ReduceLives()
    {
        lives -= 1;
        if (lives <= 0)
        {
            Debug.Log("Perso");
            Time.timeScale = 0;
        }

    }

    public static void ScoreCounter(string enemy)
    {
        switch (enemy)
        {
            case "1":
                score += SCORE1;
                break;
            case "2":
                score += SCORE2;
                break;
            case "3":
                score += SCORE3;
                break;
            case "5":
                score += SCORE5;
                break;
            case "0":
                score += SCORE0;
                break;
            default:
                score += 0;
                break;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
