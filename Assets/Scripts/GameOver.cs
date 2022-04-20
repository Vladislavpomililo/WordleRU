using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverWindow;
    [SerializeField] private Text cellWin;

    public static bool activGameOver;

    private void Start()
    {
        activGameOver = false;
    }

    private void Update()
    {
        if (activGameOver == true)
        {
            GameOverWindow();
        }
    }

    public void GameOverWindow()
    {
        gameOverWindow.SetActive(true);
        cellWin.text = scriptDB.word;
    }
}
