using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool gameOver;

    public GameObject gameOverUI;

    [SerializeField]
    Text scoreTxt;

    float score;

    public void Awake()
    {
        gameOver = false;
        instance = this;
    }


    private void Update()
    {
        if (gameOver)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addScore(float scoreToAdd)
    {
        score += scoreToAdd;
        scoreTxt.text = score.ToString();
    }

}
