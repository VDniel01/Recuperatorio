﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public Text gameOverText;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManager.gameOver)
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                gameOverText.text = "Game Over";
                gameOverText.gameObject.SetActive(true);
            }
        }
        if (GameManager.winCondition)
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                gameOverText.text = "You Win";
                gameOverText.gameObject.SetActive(true);
            }
        }
    }
}
