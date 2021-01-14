using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score;
    private int lives;
    private readonly static int SCORE1 = 10;
    private readonly static int SCORE2 = 20;
    private readonly static int SCORE3 = 20;
    private readonly static int SCORE4 = 25;
    private readonly static int SCORE5 = 30;
    private readonly static int SCORE0 = 50;
    public Text scoreText;
    public Text livesText;

    private static PlayerScore instance;


    void Awake()
    {
        instance = this;
    }

    public static PlayerScore GetInstancePlayerScore()
    {
        
        return instance;
    }

    public PlayerScore()
    {
        Init();
    }

    void Init()
    {
        score = 0;
        lives = 3;
        UpdateUI();
    }
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void ReduceLives()
    {
        lives -= 1;
        UpdateUI();
        if (lives <= 0)
        {
            Debug.Log("Perso");
            Time.timeScale = 0;
        }

    }

    public void ScoreCounter(string enemy)
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
            case "4":
                score += SCORE4;
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
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();

        }
        if (livesText != null)
        {
            livesText.text = lives.ToString();

        }
    }



}
