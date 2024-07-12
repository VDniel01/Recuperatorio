using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de tener esto para usar Text

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;
    public static int playerScore = 0;

    public Text scoreText; // Referencia al texto del puntaje

    public List<Controller_Target> targets;
    public List<Controller_Player> players;

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetConstraits();
        UpdateScoreUI(); // Inicializar el puntaje en la UI
    }

    void Update()
    {
        GetInput();
        CheckWin();
    }

    public static void AddScore(int score)
    {
        playerScore += score;
        FindObjectOfType<GameManager>().UpdateScoreUI(); // Actualizar la UI del puntaje
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + playerScore;
    }

    private void CheckWin()
    {
        int i = 0;
        foreach (Controller_Target t in targets)
        {
            if (t.playerOnTarget)
            {
                i++;
            }
        }
        if (i >= 7)
        {
            winCondition = true;
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (actualPlayer <= 0)
            {
                actualPlayer = 6;
                SetConstraits();
            }
            else
            {
                actualPlayer--;
                SetConstraits();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (actualPlayer >= 6)
            {
                actualPlayer = 0;
                SetConstraits();
            }
            else
            {
                actualPlayer++;
                SetConstraits();
            }
        }
    }

    private void SetConstraits()
    {
        foreach (Controller_Player p in players)
        {
            if (p == players[actualPlayer])
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
